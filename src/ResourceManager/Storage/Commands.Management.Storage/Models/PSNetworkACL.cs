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

using Microsoft.Azure.Management.Storage.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    [Flags]
    public enum PSNetWorkACLBypassEnum
    {
        None = 0,
        Logging = 1,
        Metrics = 2,
        AzureServices = 4
    }

    public enum PSNetWorkACLDefaultActionEnum
    {
        Deny = 0,
        Allow = 1
    }

    public enum PSNetWorkACLRuleActionEnum
    {
        Allow = 0
    }

    public struct PSIpRule
    {
        public PSNetWorkACLRuleActionEnum? Action;
        public string IPAddressOrRange;
    }

    public struct PSVirtualNetworkRule
    {
        public PSNetWorkACLRuleActionEnum? Action;
        public string VirtualNetworkResourceId;
        public string State;
    }

    public class PSNetworkACL
    {
        public PSIpRule[] IpRules { get; set; }

        public PSVirtualNetworkRule[] VirtualNetworkRules { get; set; }

        public PSNetWorkACLBypassEnum? Bypass { get; set; }

        public PSNetWorkACLDefaultActionEnum DefaultAction { get; set; }


        public static PSNetWorkACLRuleActionEnum? ParsePSNetworkACLRuleAction(Microsoft.Azure.Management.Storage.Models.Action? action)
        {
            if (action == null)
            {
                return null;
            }

            if (action.Value == Microsoft.Azure.Management.Storage.Models.Action.Allow)
            {
                return PSNetWorkACLRuleActionEnum.Allow;
            }

            return PSNetWorkACLRuleActionEnum.Allow;
        }
        public static Microsoft.Azure.Management.Storage.Models.Action? ParseStorageNetworkACLRuleAction(PSNetWorkACLRuleActionEnum? action)
        {
            if (action == null)
            {
                return null;
            }

            if (action == PSNetWorkACLRuleActionEnum.Allow)
            {
                return Microsoft.Azure.Management.Storage.Models.Action.Allow;
            }
            return Microsoft.Azure.Management.Storage.Models.Action.Allow;
        }
        public static PSNetWorkACLBypassEnum? ParsePSNetworkACLBypass(string bypass)
        {
            if (bypass == null)
            {
                return null;
            }

            PSNetWorkACLBypassEnum returnBypass = PSNetWorkACLBypassEnum.None;

            if (bypass.ToLower().Contains(PSNetWorkACLBypassEnum.Logging.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkACLBypassEnum.Logging;
            if (bypass.ToLower().Contains(PSNetWorkACLBypassEnum.Metrics.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkACLBypassEnum.Metrics;
            if (bypass.ToLower().Contains(PSNetWorkACLBypassEnum.AzureServices.ToString().ToLower()))
                returnBypass = returnBypass | PSNetWorkACLBypassEnum.AzureServices;

            return returnBypass;
        }
        public static string ParseStorageNetworkACLBypass(PSNetWorkACLBypassEnum? bypass)
        {
            if (bypass == null)
            {
                return null;
            }

            string returnBypass = string.Empty;

            if ((bypass & PSNetWorkACLBypassEnum.Logging) == PSNetWorkACLBypassEnum.Logging)
            {
                returnBypass += PSNetWorkACLBypassEnum.Logging.ToString() + ",";
            }
            if ((bypass & PSNetWorkACLBypassEnum.Metrics) == PSNetWorkACLBypassEnum.Metrics)
            {
                returnBypass += PSNetWorkACLBypassEnum.Metrics.ToString() + ",";
            }
            if ((bypass & PSNetWorkACLBypassEnum.AzureServices) == PSNetWorkACLBypassEnum.AzureServices)
            {
                returnBypass += PSNetWorkACLBypassEnum.AzureServices.ToString() + ",";
            }

            if (returnBypass == string.Empty)
            {
                returnBypass = PSNetWorkACLBypassEnum.None.ToString();
            }
            else
            {
                //remove the last ","
                returnBypass = returnBypass.Substring(0, returnBypass.Length - 1);
            }

            return returnBypass;
        }

        public static PSNetWorkACLDefaultActionEnum ParsePSNetworkACLDefaultAction(DefaultAction defaultAction)
        {
            if (defaultAction == Microsoft.Azure.Management.Storage.Models.DefaultAction.Allow)
            {
                return PSNetWorkACLDefaultActionEnum.Allow;
            }
            else
            {
                return PSNetWorkACLDefaultActionEnum.Deny;
            }
        }
        public static DefaultAction ParseStorageNetworkACLDefaultAction(PSNetWorkACLDefaultActionEnum defaultAction)
        {
            if (defaultAction == PSNetWorkACLDefaultActionEnum.Allow)
            {
                return Microsoft.Azure.Management.Storage.Models.DefaultAction.Allow;
            }
            else
            {
                return Microsoft.Azure.Management.Storage.Models.DefaultAction.Deny;
            }
        }

        public static PSIpRule ParsePSNetworkACLIPRule(IpRule ipRule)
        {
            PSIpRule returnRule = new PSIpRule();
            returnRule.Action = ParsePSNetworkACLRuleAction(ipRule.Action);
            returnRule.IPAddressOrRange = ipRule.IPAddressOrRange;
            return returnRule;
        }
        public static IpRule ParseStorageNetworkACLIPRule(PSIpRule ipRule)
        {
            IpRule returnRule = new IpRule();
            returnRule.Action = ParseStorageNetworkACLRuleAction(ipRule.Action);
            returnRule.IPAddressOrRange = ipRule.IPAddressOrRange;
            return returnRule;
        }

        public static PSVirtualNetworkRule ParsePSNetworkACLVirtualNetworkRule(VirtualNetworkRule virtualNetworkRule)
        {
            PSVirtualNetworkRule returnRule = new PSVirtualNetworkRule();
            returnRule.Action = ParsePSNetworkACLRuleAction(virtualNetworkRule.Action);
            returnRule.VirtualNetworkResourceId = virtualNetworkRule.VirtualNetworkResourceId;
            returnRule.State = virtualNetworkRule.State;

            return returnRule;
        }
        public static VirtualNetworkRule ParseStorageNetworkACLVirtualNetworkRule(PSVirtualNetworkRule virtualNetworkRule)
        {
            VirtualNetworkRule returnRule = new VirtualNetworkRule();
            returnRule.Action = ParseStorageNetworkACLRuleAction(virtualNetworkRule.Action);
            returnRule.VirtualNetworkResourceId = virtualNetworkRule.VirtualNetworkResourceId;

            return returnRule;
        }

        public static PSNetworkACL ParsePSNetworkACL(StorageNetworkAcls rules)
        {
            PSNetworkACL returnRules = new PSNetworkACL();
            returnRules.Bypass = ParsePSNetworkACLBypass(rules.Bypass);
            returnRules.DefaultAction = ParsePSNetworkACLDefaultAction(rules.DefaultAction);

            List<PSIpRule> ipRuleList = new List<PSIpRule>();
            if (rules.IpRules != null)
            {
                foreach (var ipRule in rules.IpRules)
                {
                    ipRuleList.Add(ParsePSNetworkACLIPRule(ipRule));
                }
            }
            returnRules.IpRules = ipRuleList.ToArray();

            List<PSVirtualNetworkRule> virtualNetworkList = new List<PSVirtualNetworkRule>();
            if (rules.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in rules.VirtualNetworkRules)
                {
                    virtualNetworkList.Add(ParsePSNetworkACLVirtualNetworkRule(virtualNetworkRule));
                }
            }
            returnRules.VirtualNetworkRules = virtualNetworkList.ToArray();

            return returnRules;
        }

        public static StorageNetworkAcls ParseStorageNetworkACL(PSNetworkACL rules)
        {
            StorageNetworkAcls returnRules = new StorageNetworkAcls();
            returnRules.Bypass = ParseStorageNetworkACLBypass(rules.Bypass);
            returnRules.DefaultAction = ParseStorageNetworkACLDefaultAction(rules.DefaultAction);

            List<IpRule> ipRuleList = new List<IpRule>();
            if (rules.IpRules != null)
            {
                foreach (var ipRule in rules.IpRules)
                {
                    ipRuleList.Add(ParseStorageNetworkACLIPRule(ipRule));
                }
            }
            returnRules.IpRules = ipRuleList.ToArray();

            List<VirtualNetworkRule> virtualNetworkList = new List<VirtualNetworkRule>();
            if (rules.VirtualNetworkRules != null)
            {
                foreach (var virtualNetworkRule in rules.VirtualNetworkRules)
                {
                    virtualNetworkList.Add(ParseStorageNetworkACLVirtualNetworkRule(virtualNetworkRule));
                }
            }
            returnRules.VirtualNetworkRules = virtualNetworkList.ToArray();

            return returnRules;
        }
    }
}
