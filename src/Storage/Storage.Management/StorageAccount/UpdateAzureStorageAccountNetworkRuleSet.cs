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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageAccountNetworkRuleSet", SupportsShouldProcess = true), OutputType(typeof(PSNetworkRuleSet))]
    public class UpdateAzureStorageAccountRuleSetCommand : StorageAccountBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage Account Name.")]
        [Alias(StorageAccountNameAlias, AccountNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account NetworkRule Bypass.")]
        [ValidateNotNullOrEmpty]
        public PSNetWorkRuleBypassEnum Bypass
        {
            get
            {
                return bypass == null ? PSNetWorkRuleBypassEnum.None : bypass.Value;
            }
            set
            {
                bypass = value;
            }
        }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Storage Account NetworkRule DefaultAction.")]
        [ValidateNotNullOrEmpty]
        public PSNetWorkRuleDefaultActionEnum DefaultAction
        {
            get
            {
                return defaultAction == null ? PSNetWorkRuleDefaultActionEnum.Allow : defaultAction.Value;
            }
            set
            {
                defaultAction = value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Storage Account NetworkRule IPRules.")]
        public PSIpRule[] IPRule
        {
            get
            {
                return iPRules;
            }
            set
            {
                isIpRuleSet = true;
                iPRules = value == null? new List<PSIpRule>().ToArray(): value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Storage Account NetworkRule VirtualNetworkRules.")]
        public PSVirtualNetworkRule[] VirtualNetworkRule
        {
            get
            {
                return virtualNetworkRules;
            }
            set
            {
                isNetworkRuleSet = true;
                virtualNetworkRules = value == null ? new List<PSVirtualNetworkRule>().ToArray() : value;
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Storage Account NetworkRule ResourceAccessRules.")]
        public PSResourceAccessRule[] ResourceAccessRule
        {
            get
            {
                return resourceAccessRule;
            }
            set
            {
                isResourceAccessRuleSet = true;
                resourceAccessRule = value == null ? new List<PSResourceAccessRule>().ToArray() : value;
            }
        }

        private PSNetWorkRuleBypassEnum? bypass = null;
        private PSNetWorkRuleDefaultActionEnum? defaultAction = null;
        private PSIpRule[] iPRules = null;
        private PSVirtualNetworkRule[] virtualNetworkRules = null;
        private PSResourceAccessRule[] resourceAccessRule = null;
        private bool isIpRuleSet = false;
        private bool isNetworkRuleSet = false;
        private bool isResourceAccessRuleSet = false;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }


        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (ShouldProcess(this.Name, "Update Storage Account NetworkRule"))
            {
                if (IPRule == null && VirtualNetworkRule == null && bypass == null && defaultAction == null && resourceAccessRule == null)
                {
                    throw new System.ArgumentNullException("IPRules, VirtualNetworkRules, Bypass, DefaultAction", "Request must specify an account NetworkRule property to update.");
                }
                Track2.StorageAccountResource storageAccount = this.StorageClientTrack2
                    .GetStorageAccount(this.ResourceGroupName, this.Name).Get();
                Track2Models.StorageAccountNetworkRuleSet storageACL = storageAccount.Data.NetworkRuleSet;

                if (storageACL == null)
                {
                    storageACL = new Track2Models.StorageAccountNetworkRuleSet(Track2Models.StorageNetworkDefaultAction.Allow);
                }

                PSNetworkRuleSet psNetworkRule = PSNetworkRuleSet.ParsePSNetworkRule(storageACL);

                if (isIpRuleSet)
                {
                    psNetworkRule.IpRules = IPRule;       
                }

                if (isNetworkRuleSet)
                {
                    psNetworkRule.VirtualNetworkRules = VirtualNetworkRule;
                }

                if (isResourceAccessRuleSet)
                {
                    psNetworkRule.ResourceAccessRules = ResourceAccessRule;
                }

                if (bypass != null)
                {
                    psNetworkRule.Bypass = bypass;
                }

                if (defaultAction != null)
                {
                    psNetworkRule.DefaultAction = defaultAction.Value;
                }

                Track2Models.StorageAccountPatch patch = new Track2Models.StorageAccountPatch();
                patch.NetworkRuleSet = PSNetworkRuleSet.ParseStorageNetworkRule(psNetworkRule);
                
                if (patch.NetworkRuleSet.IPRules.Count == 0)
                {
                    patch.NetworkRuleSet.IPRules.Clear();
                }
                if (patch.NetworkRuleSet.VirtualNetworkRules.Count == 0)
                {
                    patch.NetworkRuleSet.VirtualNetworkRules.Clear();
                }
                if (patch.NetworkRuleSet.ResourceAccessRules.Count == 0)
                {
                    patch.NetworkRuleSet.ResourceAccessRules.Clear();
                }

                var updatedStorageAccount = this.StorageClientTrack2
                    .GetStorageAccount(this.ResourceGroupName, this.Name)
                    .Update(patch);

                storageAccount = this.StorageClientTrack2
                    .GetStorageAccount(this.ResourceGroupName, this.Name).Get();
                WriteObject(PSNetworkRuleSet.ParsePSNetworkRule(storageAccount.Data.NetworkRuleSet));
            }
        }
    }
}
