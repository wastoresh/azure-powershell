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

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.File;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Remove,
        Constants.ShareCmdletName,
        DefaultParameterSetName = Constants.ShareNameParameterSetName,
        SupportsShouldProcess = true)]
    public class RemoveAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "File share object to be removed.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(HelpMessage = "Remove File Share with all its snapshots")]
        public SwitchParameter IncludeSnapshot { get; set; }

        [Parameter(HelpMessage = "Force to remove the share with all its snapshots, and all content in them.")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }

        [Parameter(HelpMessage = "Returns an object representing the removed file share. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        private bool force;

        public override void ExecuteCmdlet()
        {
            CloudFileShare share;
            switch (this.ParameterSetName)
            {
                case Constants.ShareParameterSetName:
                    share = this.Share;
                    break;

                case Constants.ShareNameParameterSetName:
                    share = this.BuildFileShareObjectFromName(this.Name);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (ShouldProcess(share.Name, "Remove share"))
            {
                this.RunTask(async taskId =>
                {
                    if(share.IsSnapshot && IncludeSnapshot.IsPresent)
                    {
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "'IncludeSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share snapshot: {0}", share.SnapshotQualifiedUri));
                    }

                    if (force || (ShareIsEmpty(share) && !IncludeSnapshot.IsPresent)
                    || ShouldContinue(string.Format(IncludeSnapshot.IsPresent ? "Remove the share with all its snapshots, and all content in them: {0}" : "Remove share and all content in it: {0}", share.Name), ""))
                    {
                        DeleteShareSnapshotsOption deleteShareSnapshotsOption = DeleteShareSnapshotsOption.None;

                        //Force means will delete the share anyway, so use 'IncludeSnapshots' to delete the share even has snapshot, or delete will fail when share has snapshot
                        // To delete a Share shapshot, must use 'None' 
                        if (IncludeSnapshot.IsPresent || (force && !share.IsSnapshot))
                        {
                            deleteShareSnapshotsOption = DeleteShareSnapshotsOption.IncludeSnapshots;
                        }

                        await this.Channel.DeleteShareAsync(share, deleteShareSnapshotsOption, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                    }

                    if (this.PassThru)
                    {
                        this.OutputStream.WriteObject(taskId, share);
                    }
                });
            }
        }
    }
}
