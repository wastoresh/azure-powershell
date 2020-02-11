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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMStoragePrefix + StorageShareNounStr, DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSShare))]
    public class GetAzureStorageShareCommand : StorageFileBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameListParameterSet = "AccountNameList";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectListParameterSet = "AccountObjectList";

        /// <summary>
        /// Share ResourceId  parameter set 
        /// </summary>
        private const string ShareResourceIdParameterSet = "ShareResourceId";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameListParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameListParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectListParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Input a File Share Resource Id.",
           ParameterSetName = ShareResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("N", "ShareName")]
        [Parameter(HelpMessage = "Share Name",
            Mandatory = true,
            ParameterSetName = AccountObjectParameterSet)]
        [Parameter(HelpMessage = "Share Name",
            Mandatory = false,
            ParameterSetName = AccountNameParameterSet)]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Include deleted shares, by default list shares won't include deleted shares",
            ParameterSetName = AccountNameListParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "Include deleted shares, by default list shares won't include deleted shares",
            ParameterSetName = AccountObjectListParameterSet)]
        public SwitchParameter IncludeDeleted { get; set; }

        //[Parameter(Mandatory = false,
        //    HelpMessage = "The fitler to list shares.",
        //    ParameterSetName = AccountNameListParameterSet)]
        //[Parameter(Mandatory = false,
        //    HelpMessage = "The fitler to list shares.",
        //    ParameterSetName = AccountObjectListParameterSet)]
        //[ValidateNotNullOrEmpty]
        //public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case AccountObjectParameterSet:
                case AccountObjectListParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                case ShareResourceIdParameterSet:
                    ResourceIdentifier shareResource = new ResourceIdentifier(ResourceId);
                    this.ResourceGroupName = shareResource.ResourceGroupName;
                    this.StorageAccountName = PSBlobServiceProperties.GetStorageAccountNameFromResourceId(ResourceId);
                    this.Name = shareResource.ResourceName;
                    break;
                default:
                    // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                var Share = this.StorageClient.FileShares.Get(
                           this.ResourceGroupName,
                           this.StorageAccountName,
                           this.Name);
                WriteObject(new PSShare(Share));
            }
            else
            {
                ListSharesExpand? listSharesExpand = null;
                if (this.IncludeDeleted.IsPresent)
                {
                    listSharesExpand = ListSharesExpand.Deleted;
                }
                IPage<FileShareItem> shares = this.StorageClient.FileShares.List(
                           this.ResourceGroupName,
                           this.StorageAccountName,
                           //null,
                           //filter: this.Filter,
                           expand: listSharesExpand);
                WriteShareList(shares);
                while (shares.NextPageLink != null)
                {
                    shares = this.StorageClient.FileShares.ListNext(shares.NextPageLink);
                    WriteShareList(shares);
                }
            }
        }
    }
}
