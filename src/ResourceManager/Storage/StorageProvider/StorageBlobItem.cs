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

namespace Microsoft.Azure.Commands.Storage.Provider
{
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;

    /// <summary>
    /// Azure storage blob object
    /// </summary>
    public class StorageBlobItem
    {
        /// <summary>
        /// Azure storage object name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// CloudBlob object
        /// </summary>
        public CloudBlob ICloudBlob { get; private set; }

        /// <summary>
        /// CloudBlob object
        /// </summary>
        public CloudBlobDirectory CloudBlobDirectory { get; private set; }

        /// <summary>
        /// CloudBlob object
        /// </summary>
        public CloudBlobContainer CloudBlobContainer { get; private set; }

        /// <summary>
        /// Azure storage blob type
        /// </summary>
        public BlobType BlobType { get; private set; }

        /// <summary>
        /// Azure storage blob Uri
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Azure storage blob object type: blob or Directory
        /// </summary>
        public BlobObjectType BlobObjectType { get; private set; }

        /// <summary>
        /// Blob length
        /// </summary>
        public long Length { get; private set; }

        /// <summary>
        /// Blob IsDeleted
        /// </summary>
        public bool IsDeleted { get; private set; }


        /// <summary>
        /// Blob content type
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// Blob last modified time
        /// </summary>
        public DateTimeOffset? LastModified { get; private set; }

        /// <summary>
        /// Blob snapshot time
        /// </summary>
        public DateTimeOffset? SnapshotTime { get; private set; }

        /// <summary>
        /// Azure storage blob constructor
        /// </summary>
        /// <param name="name">ICloud blob object relative Name in a sub dir</param>
        /// <param name="blob">ICloud blob object</param>
        public StorageBlobItem(string name, CloudBlob blob)
        {
            Name = name;
            ICloudBlob = blob;
            BlobObjectType = BlobObjectType.Blob;
            Uri = blob.Uri;
            BlobType = blob.BlobType;
            Length = blob.Properties.Length;
            ContentType = blob.Properties.ContentType;
            LastModified = blob.Properties.LastModified;
            SnapshotTime = blob.SnapshotTime;
            IsDeleted = blob.IsDeleted;
        }

        /// <summary>
        /// Azure storage blob Dir constructor
        /// </summary>
        /// <param name="name">ICloud blob object relative Name in a sub dir</param>
        /// <param name="blobDir">ICloud blob Directory</param>
        public StorageBlobItem(string name, CloudBlobDirectory blobDir)
        {
            Name = name;
            BlobObjectType = BlobObjectType.Directory;
            CloudBlobDirectory = blobDir;
            Uri = blobDir.Uri;
        }

        /// <summary>
        /// Azure storage blob container constructor
        /// </summary>
        /// <param name="name">ICloud blob object relative Name in a sub dir</param>
        /// <param name="blobDir">ICloud blob Directory</param>
        public StorageBlobItem(string name, CloudBlobContainer container)
        {
            Name = name;
            BlobObjectType = BlobObjectType.Container;
            CloudBlobContainer = container;
            Uri = container.Uri;
        }

        /// <summary>
        /// Azure storage Blob & blob Dir constructor, when the blob and dir has same Uri
        /// </summary>
        /// <param name="name">ICloud blob object relative Name in a sub dir</param>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="blobDir">ICloud blob Directory</param>
        public StorageBlobItem(string name, CloudBlob blob, CloudBlobDirectory blobDir)
        {
            //TODO: check blob and and Dir name are same

            Name = name;
            BlobObjectType = BlobObjectType.BlobAndDirectory;
            ICloudBlob = blob;
            CloudBlobDirectory = blobDir;
            Uri = blobDir.Uri;
            BlobType = blob.BlobType;
            Length = blob.Properties.Length;
            ContentType = blob.Properties.ContentType;
            LastModified = blob.Properties.LastModified;
            SnapshotTime = blob.SnapshotTime;
        }
    }

    public enum BlobObjectType
    {
        Container = 0,
        Blob = 1,
        Directory = 2,
        BlobAndDirectory = 3
    }
}
