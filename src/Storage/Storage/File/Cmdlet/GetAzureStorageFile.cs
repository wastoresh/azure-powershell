﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using global::Azure;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Net;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFile", DefaultParameterSetName = Constants.ShareNameParameterSetName)]
    [OutputType(typeof(AzureStorageFile))]
    public class GetAzureStorageFile : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the files/directories would be listed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the files/directories would be listed.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the base folder where the files/directories would be listed.")]
        [ValidateNotNull]
        [Alias("CloudFileDirectory")]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Path to an existing file/directory.")]
        public string Path { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudFileDirectory baseDirectory;
            switch (this.ParameterSetName)
            {
                case Constants.DirectoryParameterSetName:
                    baseDirectory = this.Directory;
                    break;

                case Constants.ShareNameParameterSetName:
                    baseDirectory = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference();
                    break;

                case Constants.ShareParameterSetName:
                    baseDirectory = this.Share.GetRootDirectoryReference();
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            ShareDirectoryClient baseDirClient = AzureStorageFileDirectory.GetTrack2FileDirClient(baseDirectory, Channel.StorageContext, ClientOptions);

            if (string.IsNullOrEmpty(this.Path))
            {
                // TODO: open the options in listFileOptions in parameters
                ShareDirectoryGetFilesAndDirectoriesOptions listFileOptions = new ShareDirectoryGetFilesAndDirectoriesOptions();
                listFileOptions.Traits = ShareFileTraits.All;
                listFileOptions.IncludeExtendedInfo = true;
                Pageable<ShareFileItem> fileItems = baseDirClient.GetFilesAndDirectories(listFileOptions, this.CmdletCancellationToken);
                //string continuationToken = null;
                IEnumerable<Page<ShareFileItem>> fileitempages = fileItems.AsPages();
                foreach (var page in fileitempages)
                {
                    foreach (var file in page.Values)
                    {
                        if (!file.IsDirectory) // is file
                        {
                            ShareFileClient shareFileClient = baseDirClient.GetFileClient(file.Name);
                            WriteObject(new AzureStorageFile(shareFileClient, Channel.StorageContext, file)); // TODO
                        }
                        else // Dir
                        {
                            ShareDirectoryClient shareDirClient = baseDirClient.GetSubdirectoryClient(file.Name);
                            WriteObject(new AzureStorageFileDirectory(shareDirClient, Channel.StorageContext, file)); // TODO
                        }

                    }
                }
            }
            else
            {
                bool foundAFolder = true;
                //string[] subfolders = NamingUtil.ValidatePath(this.Path);

                //TODO: need validate sub folder path, like "dir1/dir2/dir3"
                ShareDirectoryClient targetDir = baseDirClient.GetSubdirectoryClient(this.Path);

                try
                {
                    ShareDirectoryProperties dirProperties = targetDir.GetProperties(this.CmdletCancellationToken).Value;
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 404)
                {
                    foundAFolder = false;
                }

                if (foundAFolder)
                {
                    WriteObject(new AzureStorageFileDirectory(targetDir, Channel.StorageContext, dirProperties)); // TODO
                    return;
                }

                //string[] filePath = NamingUtil.ValidatePath(this.Path, true);
                //TODO: need validate sub folder path, like "dir1/dir2/dir3/file"
                ShareFileClient targetFile = baseDirClient.GetFileClient(this.Path);

                ShareFileProperties fileProperties = targetFile.GetProperties(this.CmdletCancellationToken).Value;

                WriteObject(new AzureStorageFile(targetFile, Channel.StorageContext, fileProperties)); // TODO
            }


            //if (string.IsNullOrEmpty(this.Path))
            //{
            //    this.RunTask(async (taskId) =>
            //    {
            //        await this.Channel.EnumerateFilesAndDirectoriesAsync(
            //            baseDirectory,
            //            item => this.WriteListFileItemObject(taskId, this.Channel, item),
            //            this.RequestOptions,
            //            this.OperationContext,
            //            this.CmdletCancellationToken).ConfigureAwait(false);
            //    });
            //}
            //else
            //{
            //    this.RunTask(async (taskId) =>
            //    {
            //        bool foundAFolder = true;
            //        string[] subfolders = NamingUtil.ValidatePath(this.Path);
            //        CloudFileDirectory targetDir = baseDirectory.GetDirectoryReferenceByPath(subfolders);

            //        try
            //        {
            //            await this.Channel.FetchDirectoryAttributesAsync(
            //                targetDir,
            //                null,
            //                this.RequestOptions,
            //                this.OperationContext,
            //                this.CmdletCancellationToken).ConfigureAwait(false);
            //        }
            //        catch (StorageException se)
            //        {
            //            if (null == se.RequestInformation
            //                || (int)HttpStatusCode.NotFound != se.RequestInformation.HttpStatusCode)
            //            {
            //                throw;
            //            }

            //            foundAFolder = false;
            //        }

            //        if (foundAFolder)
            //        {
            //            WriteCloudFileDirectoryeObject(taskId, this.Channel, targetDir);
            //            return;
            //        }

            //        string[] filePath = NamingUtil.ValidatePath(this.Path, true);
            //        CloudFile targetFile = baseDirectory.GetFileReferenceByPath(filePath);

            //        await this.Channel.FetchFileAttributesAsync(
            //            targetFile,
            //            null,
            //            this.RequestOptions,
            //            this.OperationContext,
            //            this.CmdletCancellationToken).ConfigureAwait(false);

            //        WriteCloudFileObject(taskId, this.Channel, targetFile);
            //    });
            //}
        }
    }
}
