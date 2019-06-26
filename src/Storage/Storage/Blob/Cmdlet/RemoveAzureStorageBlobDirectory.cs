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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// remove specified azure container
    /// </summary>
    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobDirectory", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true),OutputType(typeof(Boolean))]
    public class RemoveAzureStorageBlobDirectoryCommand : StorageCloudBlobCmdletBase
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
        private const string BlobDirectoryParameterSet = "BlobDirectoryPipeline";

        [Parameter(Mandatory = true, HelpMessage = "Azure Container Object",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [ValidateNotNull]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Container name", ParameterSetName = ManualParameterSet)]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(Mandatory = true, HelpMessage = "Blob Directory path", ParameterSetName = ContainerParameterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Blob Directory path", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get { return BlobDirectoryPath; }
            set { BlobDirectoryPath = value; }
        }
        private string BlobDirectoryPath = String.Empty;

        [Parameter(Mandatory = true, HelpMessage = "Azure BlobDirectory Object",
            ValueFromPipeline = true, ParameterSetName = BlobDirectoryParameterSet)]
        [ValidateNotNull]
        public CloudBlobDirectory CloudBlobDirectory { get; set; }

        [Parameter(HelpMessage = "Force to remove the container and all content in it")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force;

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified container is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageBlobDirectoryCommand class.
        /// </summary>
        public RemoveAzureStorageBlobDirectoryCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageBlobDirectoryCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveAzureStorageBlobDirectoryCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        ///// <summary>
        ///// remove azure container by container name
        ///// </summary>
        ///// <param name="name">container name</param>
        //internal async Task RemoveAzureContainer(long taskId, IStorageBlobManagement localChannel, string name)
        //{
        //    if (!NameUtil.IsValidContainerName(name))
        //    {
        //        throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
        //    }

        //    BlobRequestOptions requestOptions = RequestOptions;
        //    AccessCondition accessCondition = null;

        //    CloudBlobContainer container = localChannel.GetContainerReference(name);

        //    if (!await localChannel.DoesContainerExistAsync(container, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false))
        //    {
        //        throw new ResourceNotFoundException(String.Format(Resources.ContainerNotFound, name));
        //    }

        //    string result = string.Empty;
        //    bool removed = false;

        //    if (force || ContainerIsEmpty(container) || OutputStream.ConfirmAsync(String.Format("Remove container and all content in it: {0}", name)).Result)
        //    {
        //        await localChannel.DeleteContainerAsync(container, accessCondition, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);
        //        result = String.Format(Resources.RemoveContainerSuccessfully, name);
        //        removed = true;
        //    }
        //    else
        //    {
        //        result = String.Format(Resources.RemoveContainerCancelled, name);
        //    }

        //    OutputStream.WriteVerbose(taskId, result);

        //    if (PassThru)
        //    {
        //        OutputStream.WriteObject(taskId, removed);
        //    }
        //}

        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);            
        }

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;

            CloudBlobDirectory blobDir = this.CloudBlobDirectory;
            switch (ParameterSetName)
            {
                case ManualParameterSet:
                    CloudBlobContainer blobContainer = localChannel.GetContainerReference(ContainerName);
                    blobDir = blobContainer.GetDirectoryReference(BlobDirectoryPath);
                    break;
                case ContainerParameterSet:
                    blobDir = this.CloudBlobContainer.GetDirectoryReference(BlobDirectoryPath);
                    break;
                default:
                    // BlobDirectoryParameterSet already has the BlobDirectory created.
                    break;
            }

            if (ShouldProcess(blobDir.Uri.ToString(), "Remove Blob Directory: "))
            {
                string continuationToken = null;
                do
                {
                    continuationToken = blobDir.Delete(continuation: continuationToken);
                }
                while (!string.IsNullOrEmpty(continuationToken));
            }

            if(PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
