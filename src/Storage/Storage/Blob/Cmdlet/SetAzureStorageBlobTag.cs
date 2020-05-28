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
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Collections.Concurrent;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Azure.Storage.Blobs;
    using System.Collections;
    using System.Collections.Generic;

    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobTag", DefaultParameterSetName = NameParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class SetAzureStorageBlobTag : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobPipelineParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline paremeter set name
        /// </summary>
        private const string ContainerPipelineParmeterSet = "ContainerPipeline";

        /// <summary>
        /// blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSet)]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParmeterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(ParameterSetName = ContainerPipelineParmeterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        public string Blob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(HelpMessage = "Container name", Mandatory = true, Position = 1,
            ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(
            HelpMessage = "The tags to set on the blob. A blob can have up to 10 tags. Tag keys must be between 1 and 128 characters. Tag values must be between 0 and 256 characters. Valid tag key and value characters include lower and upper case letters, digits (0-9), space (' '), plus ('+'), minus ('-'), period ('.'), foward slash ('/'), colon (':'), equals ('='), and underscore ('_').", 
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag
        {
            get
            {
                return tag;
            }

            set
            {
                tag = value;
            }
        }

        private Hashtable tag = null;


        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            CloudBlob blob = null;

            switch (ParameterSetName)
            {
                case NameParameterSet:
                    blob = GetCloudBlobObject(ContainerName, BlobName);
                    break;
                case ContainerPipelineParmeterSet:
                    blob = GetCloudBlobObject(CloudBlobContainer, BlobName);
                    break;
                case BlobPipelineParameterSet:
                    blob = GetCloudBlobObject(CloudBlob);
                    break;
            }

            BlobClientOptions options = new BlobClientOptions();
            BlobClient blobClient = GetTrack2BlobClient(blob, Channel.StorageContext, options);

            IDictionary<string, string> blobTags = new Dictionary<string, string>();
            foreach (DictionaryEntry entry in tag)
            {
                string key = entry.Key.ToString();
                string value = entry.Value.ToString();
                
                blobTags.Add(key, value);
            }

            blobClient.SetTags(blobTags, CmdletCancellationToken);

            WriteObject(new AzureStorageBlob(blob, Channel.StorageContext));
        }        

        /// <summary>
        /// Get blob with copy status by name
        /// </summary>
        /// <param name="containerName">Container name</param>
        /// <param name="blobName">blob name</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobObject(string containerName, string blobName)
        {
            CloudBlobContainer container = Channel.GetContainerReference(containerName);
            return GetCloudBlobObject(container, blobName);
        }

        /// <summary>
        /// Get blob with copy status by CloudBlobContainer object
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobObject(CloudBlobContainer container, string blobName)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;

            NameUtil.ValidateBlobName(blobName);
            NameUtil.ValidateContainerName(container.Name);

            CloudBlob blob = GetBlobReferenceFromServerWithContainer(Channel, container, blobName, accessCondition, options, OperationContext);

            return GetCloudBlobObject(blob);
        }

        /// <summary>
        /// Get blob with copy status by CloudBlob object
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <returns>CloudBlob object</returns>
        private CloudBlob GetCloudBlobObject(CloudBlob blob)
        {
            NameUtil.ValidateBlobName(blob.Name);

            ValidateBlobType(blob);

            return blob;
        }   
    }
}
