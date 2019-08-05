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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("Move", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlob"),OutputType(typeof(AzureStorageBlob))]
    public class MoveAzureStorageBlobCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// container pipeline
        /// </summary>
        private const string ContainerParameterSet = "ContainerPipeline";

        /// <summary>
        /// BlobDirectory pipeline
        /// </summary>
        private const string BlobParameterSet = "BlobPipeline";

        [Parameter(Mandatory = true, HelpMessage = "Source Azure Container Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNull]
        public CloudBlobContainer SrcCloudBlobContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Source Container name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Source Blob path", ParameterSetName = ManualParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Source Blob path", ParameterSetName = ContainerParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcPath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Blob Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public CloudBlob SrcCloudBlob { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Dest Container name")]
        [ValidateNotNullOrEmpty]
        public string DestContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Dest Blob path")]
        [ValidateNotNullOrEmpty]
        public string DestPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The umask restricts the permissions of the file or directory to be created. The resulting permission is given by p & ^u, where p is the permission and u is the umask. Symbolic (rwxrw-rw-) is supported. ")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Umask { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "This parameter determines the behavior of the rename operation. The value must be \"legacy\" or \"posix\", and the default value will be \"posix\". ")]
        public PathRenameMode PathRenameMode
        {
            get
            {
                //return (pathRenameMode == null) ? null : pathRenameMode.Value;
                return pathRenameMode.Value;
            }

            set
            {
                pathRenameMode = value;
            }
        }
        private PathRenameMode? pathRenameMode = null;



        /// <summary>
        /// Initializes a new instance of the MoveAzureStorageBlobDirectoryCommand class.
        /// </summary>
        public MoveAzureStorageBlobCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MoveAzureStorageBlobDirectoryCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public MoveAzureStorageBlobCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }
        
        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;         

            CloudBlockBlob srcBlob = this.SrcCloudBlob as CloudBlockBlob;
            switch (ParameterSetName)
            {
                case ManualParameterSet:
                    if (!NameUtil.IsValidContainerName(this.SrcContainer))
                    {
                        throw new ArgumentException(String.Format(Resources.InvalidContainerName, this.SrcContainer));
                    }
                    CloudBlobContainer blobContainer = localChannel.GetContainerReference(this.SrcContainer);
                    srcBlob = blobContainer.GetBlockBlobReference(this.SrcPath);
                    break;
                case ContainerParameterSet:
                    srcBlob = this.SrcCloudBlobContainer.GetBlockBlobReference(this.SrcPath);
                    break;
                default:
                    // BlobDirectoryParameterSet already has source BlobDirectory created.
                    break;
            }

            // Create Dest Blob Dir
            if (!NameUtil.IsValidContainerName(this.DestContainer))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, this.DestContainer));
            }
            CloudBlobContainer destblobContainer = localChannel.GetContainerReference(this.DestContainer);
            CloudBlockBlob destBlob = destblobContainer.GetBlockBlobReference(this.DestPath);

            if (ShouldProcess(srcBlob.Uri.ToString(), "Move Blob: "))
            {
                srcBlob.Move(destBlob.Uri, null, null, requestOptions, OperationContext,
                this.Umask != null ? PathPermissions.ParseSymbolic(this.Umask) : null,
                this.pathRenameMode);
            }

            destBlob.FetchAttributes();
            destBlob.FetchAccessControls();

            AzureStorageBlob azureBlob = new AzureStorageBlob(destBlob);
            azureBlob.Context = localChannel.StorageContext;
            WriteObject(azureBlob);
        }
    }
}
