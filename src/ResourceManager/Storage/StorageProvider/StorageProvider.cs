namespace Microsoft.Azure.Commands.Storage.Provider
{
    using Common.Authentication;
    using Common.Authentication.Abstractions;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Management.Automation.Provider;
    using System.Linq;
    using System.Collections;
    using System.Security;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Rest.Azure;
    using ResourceManager.Common.Tags;
    using System.Linq.Expressions;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using System.Reflection;
    using System.Globalization;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Commands.Management.Storage;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Commands.Management.Storage.Models;
    using Microsoft.WindowsAzure.Storage.Auth;

    #region KeyVaultProvider

    [CmdletProvider("Storage", ProviderCapabilities.ExpandWildcards)]
    public class StorageProvider : NavigationCmdletProvider, IContentCmdletProvider, ICmdletProviderSupportsHelp
    {
        #region Private Properties

        /// The separator used in path statements.
        private string pathSeparator = "\\";

        /// The separator used in BlobNameSeparator statements.
        private string BlobNameSeparator = "/";

        #endregion Private Properties

        #region Drive Manipulation

        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentNullException("drive"),
                           "NullDrive",
                           ErrorCategory.InvalidArgument,
                           null));

                return null;
            }
            if (String.IsNullOrEmpty(drive.Root) || File.Exists(drive.Root))
            {
                WriteError(new ErrorRecord(
                           new ArgumentException("drive.Root"),
                           "NoRoot",
                           ErrorCategory.InvalidArgument,
                           drive));

                return null;
            }

            StorageDriveInfo kvDriveInfo = new StorageDriveInfo(drive);
            isLoggedIn();

            return kvDriveInfo;
        }

        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentNullException("drive"),
                           "NullDrive",
                           ErrorCategory.InvalidArgument,
                           drive));

                return null;
            }

            StorageDriveInfo kvDriveInfo = drive as StorageDriveInfo;

            if (kvDriveInfo == null)
            {
                return null;
            }

            return kvDriveInfo;
        }

        #endregion Drive Manipulation

        #region DriveHelperMethods

        private void isLoggedIn()
        {
            var profile = AzureRmProfileProvider.Instance.Profile;
            if (profile == null || profile.DefaultContext == null || profile.DefaultContext.Account == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentException("You are not logged into Azure. Please run Connect-AzureRmAccount before creating a drive for this Azure Provider."),
                           "NotLoggedIn",
                           ErrorCategory.SecurityError,
                           profile));
            }
        }

        #endregion DriveHelperMethods

        #region Item Methods

        /// The Windows PowerShell engine calls this method when the 
        /// Get-Item cmdlet is run and the path to this provider is 
        /// specified. This method retrieves an item using the specified path.
        protected override void GetItem(string path)
        {
            isLoggedIn();

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                WriteItemObject(this.PSDriveInfo, path, true);
                return;
            }


            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;

            string[] namesFromPath = ChunkPath(path);

            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);


            if (container.Exists())
            {
                if (namesFromPath.Length == 1)
                {
                    WriteItemObject(new StorageBlobItem(container.Name, container), path + this.pathSeparator + container.Name, true);
                    return;
                }
            }
            else
            {
                throw new Exception(string.Format("the container {0} not exist.", container.Name));
            }

            // Item is a Blob ( TODO: BlobDir )
            string blobUri = container.Uri.ToString();
            for (int i = 1; i < namesFromPath.Length; i++)
            {
                blobUri = blobUri + "/" + namesFromPath[i];
            }
            ICloudBlob blob = blobClient.GetBlobReferenceFromServer(new Uri(blobUri));
            string destpath = (DynamicParameters as GetItemBlobDynamicParameters).DestFile;
            blob.DownloadToFile(destpath, FileMode.CreateNew);

            //WriteItemObject(blob, mergeBlobPathName(path, blob.Name), true);
            return;

        }

        /// The Windows PowerShell engine calls this method when the 
        /// Set-Item cmdlet is run and the path to this provider is 
        /// specified. This method sets the columns of a row using the 
        /// data specified by the values parameter.
        protected override void SetItem(string path, object values)
        {
            isLoggedIn();

            if (DynamicParameters == null)
            {
                throw new ArgumentException("Please provide the -ItemType parameter. Valid types are: 'Container', and 'Blob'");
            }

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                throw new PSNotSupportedException();
            }

            var namesFromPath = ChunkPath(path);

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;
            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);

            if (namesFromPath.Length == 1)
            {
                // TODO: can't set container
                //var dynamicParameters = DynamicParameters as NewItemContainerDynamicParameters;
                //container.Create();
            }
            else
            {
                var dynamicParameters = DynamicParameters as NewItemBlobDynamicParameters;
                string sourceFile = dynamicParameters.SourceFile;
                BlobType blobType = dynamicParameters.BlobType;

                string blobName = namesFromPath[1];
                for (int i = 2; i < namesFromPath.Length; i++)
                {
                    blobName = blobName + "/" + namesFromPath[i];
                }


                ICloudBlob blob;

                switch (blobType)
                {
                    case BlobType.BlockBlob:
                    case BlobType.Unspecified:
                        blob = container.GetBlockBlobReference(blobName);
                        break;
                    case BlobType.PageBlob:
                        blob = container.GetPageBlobReference(blobName);
                        break;
                    case BlobType.AppendBlob:
                        blob = container.GetAppendBlobReference(blobName);
                        break;
                    default:
                        throw new Exception();
                }
                if (!blob.Exists())
                {
                    //TODO: warning will create a new blob instead of modify exsiting one
                }

                blob.UploadFromFile(sourceFile);
            }
        }

        /// Tests to see if the specified item exists.
        protected override bool ItemExists(string path)
        {
            isLoggedIn();

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                return true;
            }

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;

            string[] namesFromPath = ChunkPath(path);

            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);

            if (container.Exists())
            {
                if (namesFromPath.Length == 1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }


            // As Blob Directory is Virutal directory, so always return true.
            return true;

            //string blobUri = container.Uri.ToString();
            //for (int i = 1; i < namesFromPath.Length; i++)
            //{
            //    blobUri = blobUri + "/" + namesFromPath[i];
            //}

            //try
            //{
            //    blobClient.GetBlobReferenceFromServer(new Uri(blobUri));
            //    return true;
            //}
            //catch (StorageException se)
            //{
            //    if (se.RequestInformation.HttpStatusCode == 404)
            //    {
            //        return false;
            //    }

            //    throw;
            //}
        }

        /// Tests to see if the specified path is syntactically valid.
        protected override bool IsValidPath(string path)
        {
            isLoggedIn();

            bool result = true;

            // Check to see if the path is null or empty.
            if (String.IsNullOrEmpty(path))
            {
                result = false;
            }

            string[] pathChunks = ChunkPath(path);

            foreach (string pathChunk in pathChunks)
            {
                if (pathChunk.Length == 0)
                {
                    result = false;
                }
            }

            return result;
        }

        #endregion Item Overloads

        #region ItemHelperMethods

        /// Checks to see if a given path is actually a drive name.
        private bool PathIsDrive(string path)
        {
            // Remove the drive name and first path separator.  If the 
            // path is reduced to nothing, it is a drive. Also, if it is
            // just a drive then there will not be any path separators.
            if (String.IsNullOrEmpty(
                         path.Replace(this.PSDriveInfo.Root, string.Empty)) ||
                         String.IsNullOrEmpty(
                         path.Replace(this.PSDriveInfo.Root + this.pathSeparator, string.Empty)) ||
                         String.IsNullOrEmpty(
                         path.Replace(NormalizePath(this.PSDriveInfo.Root), string.Empty)) ||
                         String.IsNullOrEmpty(
                         path.Replace(NormalizePath(this.PSDriveInfo.Root + this.pathSeparator), string.Empty)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Breaks up the path into individual elements.
        private string[] ChunkPath(string path)
        {
            // Normalize the path before splitting
            string normalPath = this.NormalizePath(path);

            // Return the path with the drive name and first path 
            // separator character removed, split by the path separator.
            string pathNoDrive = normalPath.Replace(
                                       this.PSDriveInfo.Root + this.pathSeparator,
                                       string.Empty);
            pathNoDrive = normalPath.Replace(
                                       this.PSDriveInfo.Root,
                                       string.Empty);
            pathNoDrive = normalPath.Replace(
                                       NormalizePath(this.PSDriveInfo.Root + this.pathSeparator),
                                       string.Empty);
            pathNoDrive = normalPath.Replace(
                                       NormalizePath(this.PSDriveInfo.Root),
                                       string.Empty);
            return pathNoDrive.Split(this.pathSeparator.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
        }


        /// GEt the blob prefix without driver name, contaienr name
        private string GetBlobPath(string path)
        {
            string[] namesFromPath = ChunkPath(path);
            if (namesFromPath.Length > 1)
            {
                string blobPath = namesFromPath[1];
                for (int i=2; i< namesFromPath.Length; i++)
                {
                    blobPath = blobPath + this.BlobNameSeparator + namesFromPath[i];
                }
                return blobPath;
            }
            return string.Empty;
        }

        /// Modifies the path ensuring that the correct path separator
        /// character is used.
        private string NormalizePath(string path)
        {
            string result = path;

            if (!String.IsNullOrEmpty(path))
            {
                result = path.Replace("/", this.pathSeparator);
            }

            return result;
        }

        #endregion Helper Methods

        #region Container Methods

        /// <summary>
        /// The Windows PowerShell engine calls this method when the Get-ChildItem 
        /// cmdlet is run. This provider returns either the tables in the database 
        /// or the rows of the table.
        /// </summary>
        /// <param name="path">The path to the parent item.</param>
        /// <param name="recurse">A Boolean value that indicates true to return all 
        /// child items recursively.
        /// </param>
        protected override void GetChildItems(string path, bool recurse)
        {
            isLoggedIn();

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                IEnumerable<CloudBlobContainer> containers = blobClient.ListContainers();
                foreach (CloudBlobContainer blobContainer in containers)
                {
                    WriteItemObject(new StorageBlobItem(blobContainer.Name, blobContainer), path + pathSeparator + blobContainer.Name, true);
                    if (recurse)
                    {
                        GetChildItems(path + blobContainer.Name, true);
                    }
                }
                return;
            }

            string[] namesFromPath = ChunkPath(path);

            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);
            CloudBlobDirectory blobdir = container.GetDirectoryReference("");
            for (int i =1; i< namesFromPath.Length; i++)
            {
                blobdir = blobdir.GetDirectoryReference(namesFromPath[i]);
            }

            IEnumerable<IListBlobItem> blobs = blobdir.ListBlobs(recurse);
            foreach (IListBlobItem blobItem in blobs)
            {
                if (blobItem is CloudBlob)
                {
                    CloudBlob blob = blobItem as CloudBlob;
                    WriteItemObject(new StorageBlobItem(GetBlobRelativeName(path, blob.Name), blob), mergeBlobPathName(path, blob.Name), false);
                }
                else
                {
                    CloudBlobDirectory blobDir = blobItem as CloudBlobDirectory;
                    WriteItemObject(new StorageBlobItem(GetBlobRelativeName(path, blobDir.Prefix), blobDir), mergeBlobPathName(path, blobDir.Prefix), false);
                }
            }
        }

        /// <summary>
        /// Returns the names of all the child items.
        /// </summary>
        /// <param name="path">The root path.</param>
        /// <param name="returnContainers">Parameter not used.</param>
        protected override void GetChildNames(
                                              string path,
                                              ReturnContainers returnContainers)
        {

            isLoggedIn();

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                IEnumerable<CloudBlobContainer> containers = blobClient.ListContainers();
                foreach (CloudBlobContainer blobContainer in containers)
                {
                    WriteItemObject(blobContainer.Name, path + pathSeparator + blobContainer.Name, true);
                }
                return;
            }

            string[] namesFromPath = ChunkPath(path);

            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);
            CloudBlobDirectory blobdir = container.GetDirectoryReference("");
            for (int i = 1; i < namesFromPath.Length; i++)
            {
                blobdir = blobdir.GetDirectoryReference(namesFromPath[i]);
            }

            IEnumerable<IListBlobItem> blobs = blobdir.ListBlobs(false, BlobListingDetails.All);
            foreach (IListBlobItem blobItem in blobs)
            {
                CloudBlob blob = blobItem as CloudBlob;
                WriteItemObject(GetBlobRelativeName(path, blob.Name), mergeBlobPathName(path, blob.Name), false);
            }
        }

        /// Determines if the specified path has child items.
        protected override bool HasChildItems(string path)
        {
            //return false;

            isLoggedIn();

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                IEnumerable<CloudBlobContainer> containers = blobClient.ListContainersSegmentedAsync("", ContainerListingDetails.None, 1, null, new BlobRequestOptions(), new OperationContext()).Result.Results;
                if (containers.Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            string[] namesFromPath = ChunkPath(path);

            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);
            //CloudBlobDirectory blobdir = container.GetDirectoryReference("");
            //for (int i = 1; i < namesFromPath.Length; i++)
            //{
            //    blobdir = blobdir.GetDirectoryReference(namesFromPath[i]);
            //}
            IEnumerable<IListBlobItem> blobs = container.ListBlobsSegmentedAsync(GetBlobPath(path) + this.BlobNameSeparator, false, BlobListingDetails.None, 1, null, new BlobRequestOptions(), new OperationContext()).Result.Results;

            if (blobs.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override string[] ExpandPath(string path)
        {
            throw new NotImplementedException();
        }

        /// The Windows PowerShell engine calls this method when the New-Item 
        /// cmdlet is run. This method creates a new item at the specified path.
        protected override void NewItem(string path, string type, object newItemValue)
        {
            isLoggedIn();
            
            if (DynamicParameters == null)
            {
                throw new ArgumentException("Please provide the -ItemType parameter. Valid types are: 'Container', and 'Blob'");
            }

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                throw new PSNotSupportedException();
            }

            var namesFromPath = ChunkPath(path);

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;
            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);

            if (namesFromPath.Length == 1)
            {
                var dynamicParameters = DynamicParameters as NewItemContainerDynamicParameters;
                container.Create();
            }
            else
            {
                var dynamicParameters = DynamicParameters as NewItemBlobDynamicParameters;
                string sourceFile = dynamicParameters.SourceFile;
                BlobType blobType = dynamicParameters.BlobType;

                string blobName = namesFromPath[1];
                for (int i = 2; i < namesFromPath.Length; i++)
                {
                    blobName = blobName + "/" + namesFromPath[i];
                }


                ICloudBlob blob;
                
                switch(blobType)
                {
                    case BlobType.BlockBlob:
                    case BlobType.Unspecified:
                        blob = container.GetBlockBlobReference(blobName);
                        break;
                    case BlobType.PageBlob:
                        blob = container.GetPageBlobReference(blobName);
                        break;
                    case BlobType.AppendBlob:
                        blob = container.GetAppendBlobReference(blobName);
                        break;
                    default:
                        throw new Exception();
                }
                if(blob.Exists())
                {
                    //TODO: check if want to overwrite
                }

                blob.UploadFromFile(sourceFile);
            }
        }

        /// The Windows PowerShell engine calls this method when the Copy-Item 
        /// cmdlet is run. This method copies an item at the specified path to 
        /// the location specified.
        protected override void CopyItem(string path, string copyPath, bool recurse)
        {
            throw new NotImplementedException();
        }

        /// The Windows PowerShell engine calls this method when the Remove-Item 
        /// cmdlet is run. This method removes (deletes) the item at the specified 
        /// path.
        protected override void RemoveItem(string path, bool recurse)
        {
            isLoggedIn();

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                throw new PSNotSupportedException();
            }

            var namesFromPath = ChunkPath(path);

            StorageDriveInfo storageDriveInfo = this.PSDriveInfo as StorageDriveInfo;
            CloudBlobClient blobClient = storageDriveInfo.BlobClient;
            CloudBlobContainer container = blobClient.GetContainerReference(namesFromPath[0]);

            if (namesFromPath.Length == 1)
            {
                var dynamicParameters = DynamicParameters as NewItemContainerDynamicParameters;
                container.Delete();
            }
            else
            {
                string blobUri = container.Uri.ToString();
                for (int i = 1; i < namesFromPath.Length; i++)
                {
                    blobUri = blobUri + "/" + namesFromPath[i];
                }
                ICloudBlob blob = blobClient.GetBlobReferenceFromServer(new Uri(blobUri));

                blob.Delete();
            }
        }

        #endregion Container Methods

        
        protected string mergeBlobPathName(string path, string blobName)
        {
            // output format is container, dir1, dir2 ...
            var namesFromPath = ChunkPath(path);

            string[] blobNameBlocks = blobName.Split(this.BlobNameSeparator.ToCharArray());

            int blobNameIndex = 0;

            for (int i=1; i< namesFromPath.Length; i++ )
            {
                if (namesFromPath[i] == blobNameBlocks[blobNameIndex])
                {
                    blobNameIndex++;
                }
                else
                {
                    throw new Exception();
                }
            }

            string blobpath = path;
            for (; blobNameIndex < blobNameBlocks.Length; blobNameIndex ++)
            {
                blobpath = blobpath + this.pathSeparator + blobNameBlocks[blobNameIndex];
            }
            return blobpath;
        }

        /// <summary>
        /// Get Blob relative name in a path
        /// </summary>
        protected string GetBlobRelativeName(string path, string blobName)
        {
            // output format is container, dir1, dir2 ...
            var namesFromPath = ChunkPath(path);

            if (namesFromPath.Length == 1)
            {
                return namesFromPath[0] + this.pathSeparator + blobName.Replace(this.BlobNameSeparator, this.pathSeparator);
            }

            string[] blobNameBlocks = blobName.Split(this.BlobNameSeparator.ToCharArray());

            int blobNameIndex = 0;

            for (int i = 1; i < namesFromPath.Length; i++)
            {
                if (namesFromPath[i] == blobNameBlocks[blobNameIndex])
                {
                    blobNameIndex++;
                }
                else
                {
                    throw new Exception();
                }
            }

            string blobRelativeName = "";
            for (; blobNameIndex < blobNameBlocks.Length; blobNameIndex++)
            {
                blobRelativeName = blobRelativeName + this.pathSeparator + blobNameBlocks[blobNameIndex];
            }
            if (blobRelativeName.Length >= 1)
            {
                blobRelativeName = blobRelativeName.Substring(1);
            }
            if (blobRelativeName.Length >= 1 && blobRelativeName.EndsWith(this.pathSeparator))
            {
                blobRelativeName = blobRelativeName.Substring(0, blobRelativeName.Length - 1);
            }

            return blobRelativeName;
        }
        #region Container Helper Methods


        #endregion Container Helper Methods

        #region Navigation Methods

        protected override bool IsItemContainer(string path)
        {
            isLoggedIn();

            return true;
        }

        //protected override string GetChildName(string path)
        //{
        //    if (String.IsNullOrEmpty(path))
        //    {
        //        throw new ArgumentException("Path null");
        //    }

        //    path = NormalizePath(path);
        //    path = path.TrimEnd('\\');
        //    string result = null;

        //    int separatorIndex = path.LastIndexOf(pathSeparator);

        //    if (separatorIndex == -1)
        //    {
        //        result = path;
        //    }

        //    result = path.Substring(separatorIndex + 1);

        //    return result;
        //}

        //protected override string GetParentPath(string path, string root)
        //{
        //    string parentPath = null;

        //    if (String.IsNullOrEmpty(path))
        //    {
        //        throw new ArgumentException("Path null");
        //    }

        //    if (root == null)
        //    {
        //        if (PSDriveInfo != null)
        //        {
        //            root = PSDriveInfo.Root;
        //        }
        //    }

        //    path = NormalizePath(path);
        //    path = path.TrimEnd('\\');
        //    string rootPath = String.Empty;

        //    if (root != null)
        //    {
        //        rootPath = NormalizePath(root);
        //    }

        //    if (String.Compare(
        //        path,
        //        rootPath,
        //        StringComparison.OrdinalIgnoreCase) == 0)
        //    {
        //        parentPath = String.Empty;
        //    }
        //    else
        //    {
        //        int lastIndex = path.LastIndexOf(pathSeparator);

        //        if (lastIndex != -1)
        //        {
        //            if (lastIndex == 0)
        //            {
        //                ++lastIndex;
        //            }

        //            parentPath = path.Substring(0, lastIndex);
        //        }
        //        else
        //        {
        //            parentPath = String.Empty;
        //        }
        //    }
        //    return parentPath;
        //}

        //protected override string MakePath(string parent, string child)
        //{
        //    string result = null;

        //    if (String.IsNullOrEmpty(parent) && String.IsNullOrEmpty(child))
        //    {
        //        result = String.Empty;
        //    }
        //    else if (String.IsNullOrEmpty(parent) &&
        //             !String.IsNullOrEmpty(child))
        //    {
        //        result = NormalizePath(child);
        //    }

        //    else if (!String.IsNullOrEmpty(parent) && String.IsNullOrEmpty(child))
        //    {
        //        var normalParent = NormalizePath(parent);
        //        if (normalParent.EndsWith(pathSeparator))
        //        {
        //            result = parent;
        //        }
        //        else
        //        {
        //            result = parent + pathSeparator;
        //        }
        //    }
        //    else
        //    {
        //        parent = NormalizePath(parent);
        //        child = NormalizePath(child);

        //        StringBuilder builder = new StringBuilder(parent, parent.Length + child.Length + 1);

        //        if (parent.EndsWith(pathSeparator))
        //        {
        //            if (child.StartsWith(pathSeparator))
        //            {
        //                builder.Append(child, 1, child.Length - 1);
        //            }
        //            else
        //            {
        //                builder.Append(child);
        //            }
        //        }
        //        else
        //        {
        //            if (child.StartsWith(pathSeparator))
        //            {
        //                if (parent.Length == 0)
        //                {
        //                    builder.Append(child, 1, child.Length - 1);
        //                }
        //                else
        //                {
        //                    builder.Append(child);
        //                }
        //            }
        //            else
        //            {
        //                if (parent.Length > 0 && child.Length > 0)
        //                {
        //                    builder.Append(pathSeparator);
        //                }
        //                builder.Append(child);
        //            }
        //        }

        //        result = builder.ToString();
        //    }

        //    return result;
        //}

        //protected override string NormalizeRelativePath(string path,
        //                                                    string basepath)
        //{
        //    return base.NormalizeRelativePath(path, basepath);
        //}

        //protected override void MoveItem(string path, string destination)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion Navigation Methods

        #region DynamicParameters

        //protected override object GetChildItemsDynamicParameters(string path, bool recurse)
        //{
        //    if (path != null)
        //    {
        //        if (this.PathIsDrive(path))
        //        {
        //            return new GetChildItemsVaultDynamicParameters();
        //        }
        //    }
        //    return null;
        //}

        //public class GetChildItemsVaultDynamicParameters
        //{
        //    [Parameter]
        //    public Hashtable Tag { get; set; }
        //}

        protected override object GetItemDynamicParameters(string path)
        {
            if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return null;
                }

                var namesFromPath = ChunkPath(path);
                if (namesFromPath.Length == 1)
                {
                    return new GetItemContainerDynamicParameters();
                }
                else
                {
                    return new GetItemBlobDynamicParameters();
                }
            }
            return null;
        }

        public class GetItemContainerDynamicParameters
        {
        }

        public class GetItemBlobDynamicParameters
        {
            [Parameter]
            public string DestFile { get; set; }
        }

        protected override object NewItemDynamicParameters(string path, string itemTypeName, object newItemValue)
        {
            if (itemTypeName != null)
            {
                if (itemTypeName.Equals("container", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemContainerDynamicParameters();
                }
                else if (itemTypeName.Equals("blob", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemBlobDynamicParameters();
                }
            }
            else if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return null;
                }

                var namesFromPath = ChunkPath(path);
                if (namesFromPath.Length == 1)
                {
                    return new NewItemContainerDynamicParameters();
                }
                else
                {
                    return new NewItemBlobDynamicParameters();
                }
            }
            return null;
        }

        public class NewItemContainerDynamicParameters
        {
        }

        public class NewItemBlobDynamicParameters
        {
            [Parameter]
            public string SourceFile { get; set; }

            [Parameter]
            public BlobType BlobType { get; set; }
        }

        protected override object SetItemDynamicParameters(string path, object value)
        {
            if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return null;
                }

                var namesFromPath = ChunkPath(path);
                if (namesFromPath.Length == 1)
                {
                    return new NewItemContainerDynamicParameters();
                }
                else
                {
                    return new NewItemBlobDynamicParameters();
                }
            }
            return null;
        }

        public class SetItemContainerDynamicParameters
        {
        }

        public class SetItemBlobDynamicParameters
        {
            [Parameter]
            public string SourceFile { get; set; }

            [Parameter]
            public BlobType BlobType { get; set; }
        }

        #endregion DynamicParameters

        #region Content Methods

        public IContentReader GetContentReader(string path)
        {
            isLoggedIn();

            if (!ItemExists(path))
            {
                throw new ArgumentException(string.Format("Item does not exist at path '{0}'", path));
            }

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                throw new NotImplementedException();
            }

            var namesFromPath = ChunkPath(path);

            StorageDriveInfo kvDriveInfo = this.PSDriveInfo as StorageDriveInfo;

            //var vaultObject = ListVaults(null, null).Where(v => v.VaultName.Equals(namesFromPath[0]));
            //if (vaultObject.Count() != 0)
            //{
            //    if (namesFromPath.Length == 3)
            //    {
            //        if (namesFromPath[1] == "Secrets")
            //        {
            //            return new KVReader(kvDriveInfo, namesFromPath[0], "secret", namesFromPath[2]);
            //        }
            //        else if (namesFromPath[1] == "Certificates")
            //        {
            //            return new KVReader(kvDriveInfo, namesFromPath[0], "certificate", namesFromPath[2]);
            //        }
            //        else if (namesFromPath[1] == "Keys")
            //        {
            //            return new KVReader(kvDriveInfo, namesFromPath[0], "key", namesFromPath[2]);
            //        }
            //    }
            //}
            throw new NotImplementedException();
        }

        public object GetContentReaderDynamicParameters(string path)
        {
            return null;
        }

        public IContentWriter GetContentWriter(string path)
        {
            isLoggedIn();

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                throw new NotImplementedException();
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            StorageDriveInfo kvDriveInfo = this.PSDriveInfo as StorageDriveInfo;

    
            throw new NotImplementedException();
        }

        public object GetContentWriterDynamicParameters(string path)
        {
            return null;
        }

        public void ClearContent(string path)
        {
        }

        public object ClearContentDynamicParameters(string path)
        {
            throw new NotImplementedException();
        }

        //public class KVReader : IContentReader
        //{
        //    private string _vaultName;
        //    private string _type;
        //    private string _name;
        //    private KVDriveInfo _kvDriveInfo;
        //    private bool _hasBeenRead;
        //    public KVReader(PSDriveInfo kvDriveInfo, string vaultName, string type, string name)
        //    {
        //        _vaultName = vaultName;
        //        _type = type;
        //        _name = name;
        //        _kvDriveInfo = kvDriveInfo as KVDriveInfo;
        //        _hasBeenRead = false;
        //    }

        //    public void Close()
        //    {
        //    }

        //    public void Dispose()
        //    {
        //    }

        //    public IList Read(long readCount)
        //    {
        //        if (_hasBeenRead)
        //        {
        //            return new List<string> { };
        //        }

        //        _hasBeenRead = true;
        //        if (_type.Equals("secret"))
        //        {
        //            var secret = _kvDriveInfo.KeyVaultDataServiceClient.GetSecret(_vaultName, _name, string.Empty);
        //            var secretValue = secret.SecretValueText;
        //            return new List<string> { secretValue };
        //        }
        //        else if (_type.Equals("certificate"))
        //        {
        //            PSKeyVaultCertificate certificate = _kvDriveInfo.KeyVaultDataServiceClient.GetCertificate(_vaultName, _name, string.Empty);
        //            var certificateBundle = certificate.Certificate;
        //            return new List<System.Security.Cryptography.X509Certificates.X509Certificate2> { certificateBundle };
        //        }
        //        else if (_type.Equals("key"))
        //        {
        //            var key = _kvDriveInfo.KeyVaultDataServiceClient.GetKey(_vaultName, _name, string.Empty);
        //            var keyBundle = key.Key;
        //            return new List<JsonWebKey> { keyBundle };
        //        }
        //        return new List<string> { };
        //    }

        //    public void Seek(long offset, SeekOrigin origin)
        //    {
        //    }
        //}

        //public class KVWriter : IContentWriter
        //{
        //    private string _vaultName;
        //    private string _type;
        //    private string _name;
        //    private KVDriveInfo _kvDriveInfo;
        //    public KVWriter(PSDriveInfo kvDriveInfo, string vaultName, string type, string name)
        //    {
        //        _vaultName = vaultName;
        //        _type = type;
        //        _name = name;
        //        _kvDriveInfo = kvDriveInfo as KVDriveInfo;
        //    }

        //    public void Close()
        //    {
        //    }

        //    public void Dispose()
        //    {
        //    }

        //    public void Seek(long offset, SeekOrigin origin)
        //    {
        //    }

        //    public IList Write(IList content)
        //    {
        //        if (_type.Equals("secret") && content.Count == 1)
        //        {
        //            var secretvalue = LanguagePrimitives.ConvertTo(content[0], typeof(SecureString)) as SecureString;
        //            if (secretvalue == null)
        //            {
        //                throw new ArgumentException("Value type must be equal to string");
        //            }
        //            var secret = _kvDriveInfo.KeyVaultDataServiceClient.GetSecret(_vaultName, _name, string.Empty);
        //            var newSecret = _kvDriveInfo.KeyVaultDataServiceClient.SetSecret(_vaultName, _name, secretvalue,
        //                new PSKeyVaultSecretAttributes(secret.Enabled, secret.Expires, secret.NotBefore, secret.ContentType, secret.Tags));
        //            return new List<PSKeyVaultSecret> { newSecret };
        //        }
        //        return new List<string> { };
        //    }
        //}

        #endregion

        #region MamlHelp

        string ICmdletProviderSupportsHelp.GetHelpMaml(string helpItemName, string path)
        {
            var ProviderHelpCommandXPath =
            "/msh:helpItems/command:command[command:details/command:verb='{0}' and command:details/command:noun='{1}']";
            var noun = string.Empty;
            var verb = string.Empty;

            if (!String.IsNullOrEmpty(helpItemName))
            {
                int index = 0;
                for (int i = 0; i < helpItemName.Length; i++)
                {
                    if (helpItemName[i].Equals('-'))
                    {
                        index = i;
                        break;
                    }
                }
                if (index > 0)
                {
                    verb = helpItemName.Substring(0, index);
                    noun = helpItemName.Substring(index + 1);
                }
            }
            else
            {
                return String.Empty;
            }

            if (String.IsNullOrEmpty(verb) || String.IsNullOrEmpty(noun))
            {
                return String.Empty;
            }

            XmlReader reader = null;
            var xmlPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml");
            XmlDocument document = new XmlDocument();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = null;
            reader = XmlReader.Create(xmlPath, settings);
            document.Load(reader);

            XmlNamespaceManager nsMgr = new XmlNamespaceManager(document.NameTable);
            nsMgr.AddNamespace("msh", "http://msh");
            nsMgr.AddNamespace("command", "http://schemas.microsoft.com/maml/dev/command/2004/10");

            string xpathQuery = String.Format(
                    CultureInfo.InvariantCulture,
                    ProviderHelpCommandXPath,
                    verb,
                    noun);

            XmlNode result = document.SelectSingleNode(xpathQuery, nsMgr);
            if (result != null)
            {
                return result.OuterXml;
            }

            return String.Empty;
        }

        #endregion MamlHelp
    }

    #endregion KeyVaultProvider

    #region StorageDriveInfo

    /// Any state associated with the drive is held here.
    internal class StorageDriveInfo : PSDriveInfo
    {
        private StorageManagementClientWrapper storageClientWrapper;
        private CloudStorageAccount storageAccount;
        private CloudBlobClient blobClient;

        public StorageDriveInfo(PSDriveInfo driveInfo)
               : base(driveInfo)
        {
        }

        public IStorageManagementClient StorageClient
        {
            get
            {
                if (storageClientWrapper == null)
                {
                    storageClientWrapper = new StorageManagementClientWrapper(AzureRmProfileProvider.Instance.Profile.DefaultContext);
                }
                return storageClientWrapper.StorageManagementClient;
            }
        }

        public CloudStorageAccount StorageAccount
        {
            get
            {
                if (storageAccount == null)
                {
                    IEnumerable<StorageAccount> accounts = StorageClient.StorageAccounts.List();
                    foreach (StorageAccount account in accounts)
                    {
                        if (account.Name == this.Root)
                        {
                            PSStorageAccount psAccount = new PSStorageAccount(account);
                            string key = StorageClient.StorageAccounts.ListKeys(psAccount.ResourceGroupName, psAccount.StorageAccountName).Keys[0].Value;
                            storageAccount = new CloudStorageAccount(new StorageCredentials(account.Name, key), true);
                        }
                    }
                    if (storageAccount == null)
                    {
                        throw new System.ArgumentException("The Strorage Account '{0}' not exist in current subscription.", this.Root);
                    }
                }
                return storageAccount;
            }
        }

        public CloudBlobClient BlobClient
        {
            get
            {
                if (blobClient == null)
                {
                    blobClient = this.StorageAccount.CreateCloudBlobClient();
                }
                return blobClient;
            }
        }
    }

    #endregion StorageDriveInfo
}