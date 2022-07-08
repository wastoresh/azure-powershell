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

using Microsoft.Azure.Commands.Management.Storage.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Azure;
using Track2 = Azure.ResourceManager.Storage;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageEncryptionScope", DefaultParameterSetName = AccountNameParameterSet), OutputType(typeof(PSEncryptionScope))]
    public class GetAzureStorageEncryptionScopeCommand : StorageFileBaseCmdlet
    {
        /// <summary>
        /// AccountName Parameter Set
        /// </summary>
        private const string AccountNameParameterSet = "AccountName";

        /// <summary>
        /// Account object parameter set 
        /// </summary>
        private const string AccountObjectParameterSet = "AccountObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Resource Group Name.",
            ParameterSetName = AccountNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = "Storage Account Name.",
            ParameterSetName = AccountNameParameterSet)]
        [Alias(AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Storage account object",
            ValueFromPipeline = true,
            ParameterSetName = AccountObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSStorageAccount StorageAccount { get; set; }

        [Alias("Name")]
        [Parameter(Mandatory = false, 
            HelpMessage = "Azure Storage EncryptionScope name")]
        [ValidateNotNullOrEmpty]
        public string EncryptionScopeName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            switch (ParameterSetName)
            {
                case AccountObjectParameterSet:
                    this.ResourceGroupName = StorageAccount.ResourceGroupName;
                    this.StorageAccountName = StorageAccount.StorageAccountName;
                    break;
                default:
                    // For AccountNameParameterSet, the ResourceGroupName and StorageAccountName can get from input directly
                    break;
            }

            if (this.EncryptionScopeName == null)
            {

                Pageable<Track2.EncryptionScopeResource> scopes = this.StorageClientTrack2
                    .GetStorageAccount(this.ResourceGroupName, this.StorageAccountName)
                    .GetEncryptionScopes()
                    .GetAll();

                List<PSEncryptionScope> output = new List<PSEncryptionScope>();
                foreach (Track2.EncryptionScopeResource scope in scopes)
                {
                    output.Add(new PSEncryptionScope(scope));
                }
                WriteObject(output, true);
            }
            else
            {
                Track2.EncryptionScopeResource scope = this.StorageClientTrack2
                    .GetEncryptionScopeResource(this.ResourceGroupName, this.StorageAccountName, this.EncryptionScopeName)
                    .Get();
       
                WriteObject(new PSEncryptionScope(scope));
            }
        }
    }
}
