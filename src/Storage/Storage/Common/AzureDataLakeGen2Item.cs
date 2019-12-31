// ----------------------------------------------------------------------------------
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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    //using Microsoft.Azure.Storage.Blob;
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using System.Threading;
    using global::Azure;
    using System.Collections.Generic;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class AzureDataLakeGen2Item : AzureStorageBase
    {
        /// <summary>
        /// File Properties
        /// </summary>
        public PSDataLakeFile File { get; set; }

        ///// <summary>
        ///// File Client
        ///// </summary>
        //public DataLakeFileClient FileClient { get; set; }

        /// <summary>
        /// Directory Properties
        /// </summary>
        public PSDataLakeDirectory Directory { get; private set; }

        ///// <summary>
        ///// Directory Client
        ///// </summary>
        //public DataLakeDirectoryClient DirectoryClient { get; set; }

        /// <summary>
        /// The Path of the item
        /// </summary>
        [Ps1Xml(Label = "Path", Target = ViewControl.Table, Position = 0, TableColumnWidth = 20)]
        public string Path { get; set; }

        /// <summary>
        /// CloudBlobDirectory object
        /// </summary>
        [Ps1Xml(Label = "IsDirectory", Target = ViewControl.Table, Position = 1, TableColumnWidth = 12)]
        public bool IsDirectory { get; private set; }

        /// <summary>
        /// Datalake Gen2 Item path Permissions
        /// </summary>
        [Ps1Xml(Label = "Permissions", Target = ViewControl.Table, ScriptBlock = "$_.Permissions.ToSymbolicString()", Position = 5, TableColumnWidth = 12)]
        public PathPermissions Permissions { get; set; }

        /// <summary>
        /// Datalake Gen2 Item ACL
        /// </summary>
        public PSPathAccessControlEntry[] ACL { get; set; }

        ///// <summary>
        ///// Azure storage blob type
        ///// </summary>
        //public BlobType BlobType { get; private set; }

        /// <summary>
        /// Blob length
        /// </summary>
        [Ps1Xml(Label = "Length", Target = ViewControl.Table, ScriptBlock = "if ($_.IsDirectory -eq $false) {$_.Length}", Position = 2, TableColumnWidth = 15)]
        public long Length { get; private set; }

        /// <summary>
        /// Blob content type
        /// </summary>
        [Ps1Xml(Label = "ContentType", Target = ViewControl.Table, Position = 3, TableColumnWidth = 30)]
        public string ContentType { get; private set; }

        /// <summary>
        /// Blob last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 4, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// The owner of the item
        /// </summary>
        [Ps1Xml(Label = "Owner", Target = ViewControl.Table, Position = 6, TableColumnWidth = 10)]
        public string Owner { get; set; }

        /// <summary>
        /// The Group of the item
        /// </summary>
        [Ps1Xml(Label = "Group", Target = ViewControl.Table, Position = 7, TableColumnWidth = 10)]
        public string Group { get; set; }

        ///// <summary>
        ///// Blob continuation token
        ///// </summary>
        //public BlobContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="blob">CloudBlockBlob blob object</param>
        public AzureDataLakeGen2Item(DataLakeFileClient fileClient)
        {
            Name = fileClient.Name;
            Path = fileClient.Path;
            File = (PSDataLakeFile)fileClient;
            //BlobType = blob.BlobType;
            Length = File.Properties.ContentLength;
            ContentType = File.Properties.ContentType;
            LastModified = File.Properties.LastModified;
            IsDirectory = false;
            //PathAccessControl acl = fileClient.GetAccessControl();
            Permissions = File.PathProperties.Permissions;
            ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(File.PathProperties.AccessControlList);
            Owner = File.PathProperties.Owner;
            Group = File.PathProperties.Group;
        }

        /// <summary>
        /// Azure DataLakeGen2 Item constructor
        /// </summary>
        /// <param name="blobDir">Cloud blob Directory object</param>
        public AzureDataLakeGen2Item(DataLakeDirectoryClient directoryClient)
        {
            Name = directoryClient.Name;
            Path = directoryClient.Path;
            Directory = (PSDataLakeDirectory)directoryClient;
            //BlobType = BlobType.Unspecified;
            Length = Directory.Properties.ContentLength;
            ContentType = Directory.Properties.ContentType;
            LastModified = Directory.Properties.LastModified;
            IsDirectory = true;
            //PathAccessControl acl = directoryClient.GetAccessControl();
            Permissions = Directory.PathProperties.Permissions;
            ACL = PSPathAccessControlEntry.ParsePSPathAccessControlEntrys(Directory.PathProperties.AccessControlList);
            Owner = Directory.PathProperties.Owner;
            Group = Directory.PathProperties.Group;
        }
    }

    public class PSDataLakeFile : DataLakeFileClient
    {
        /// <summary>
        /// File Properties
        /// </summary>
        public PathProperties Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = this.GetProperties();
                }
                return properties;
            }
        }
        private PathProperties properties;

        public IDictionary<string, string> Metadata {
            get
            {
                return this.Properties.Metadata;
            }
        }

        public PathAccessControl PathProperties
        {
            get
            {
                if (pathProperties == null)
                {
                    pathProperties = this.GetAccessControl();
                }
                return pathProperties;
            }
        }
        private PathAccessControl pathProperties;
    }
    public class PSDataLakeDirectory : DataLakeDirectoryClient
    {
        /// <summary>
        /// File Properties
        /// </summary>
        public PathProperties Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = this.GetProperties();
                }
                return properties;
            }
        }
        private PathProperties properties;

        public IDictionary<string, string> Metadata
        {
            get
            {
                return this.Properties.Metadata;
            }
        }

        public PathAccessControl PathProperties
        {
            get
            {
                if (pathProperties == null)
                {
                    pathProperties = this.GetAccessControl();
                }
                return pathProperties;
            }
        }
        private PathAccessControl pathProperties;
    }
}
