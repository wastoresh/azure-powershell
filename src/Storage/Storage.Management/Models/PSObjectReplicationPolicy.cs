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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type ObjectReplicationPolicy
    /// </summary>
    public class PSObjectReplicationPolicy
    {
        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; }
        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table, Position = 1)]
        public string StorageAccountName { get; }
        public string ResourceId { get; }
        public string Name { get; }
        public string Type { get; }

        [Ps1Xml(Label = "PolicyId", Target = ViewControl.Table, Position = 2)]
        public string PolicyId { get; set; }
        [Ps1Xml(Label = "EnabledTime", Target = ViewControl.Table, Position = 3)]
        public DateTimeOffset? EnabledTime { get; }
        [Ps1Xml(Label = "SourceAccount", Target = ViewControl.Table, Position = 4)]
        public string SourceAccount { get; set; }
        [Ps1Xml(Label = "DestinationAccount", Target = ViewControl.Table, Position = 5)]
        public string DestinationAccount { get; set; }
        [Ps1Xml(Label = "Rules", Target = ViewControl.Table, ScriptBlock = "if (($_.Rules -ne $null) -and ($_.Rules.Count -ne 0)) {'[' + $_.Rules[0].RuleId + ',...]'} else {$null}", Position = 6)]
        public PSObjectReplicationPolicyRule[] Rules { get; set; }

        public PSObjectReplicationPolicy()
        { }

        public PSObjectReplicationPolicy(Track2.ObjectReplicationPolicyResource policy, string ResourceGroupName, string StorageAccountName)
        {
            this.ResourceGroupName = ResourceGroupName;
            this.StorageAccountName = StorageAccountName;
            this.ResourceId = policy.Id;
            this.Name = policy.Data.Name;
            this.Type = policy.Data.ResourceType;
            this.PolicyId = policy.Data.PolicyId;
            this.EnabledTime = policy.Data.EnabledOn;
            this.SourceAccount = policy.Data.SourceAccount;
            this.DestinationAccount = policy.Data.DestinationAccount;
            this.Rules = PSObjectReplicationPolicyRule.GetPSObjectReplicationPolicyRules(policy.Data.Rules);
        }

        public Track2.ObjectReplicationPolicyData ParseObjectReplicationPolicy()
        {
            Track2.ObjectReplicationPolicyData data = new Track2.ObjectReplicationPolicyData();
            data.SourceAccount = this.SourceAccount;
            data.DestinationAccount = this.DestinationAccount;

            foreach(PSObjectReplicationPolicyRule rule in this.Rules)
            {
                data.Rules.Add(rule.ParseObjectReplicationPolicyRule());
            }
            return data;
        }
    }

    /// <summary>
    /// Wrapper of SDK type ObjectReplicationPolicyRule
    /// </summary>
    public class PSObjectReplicationPolicyRule
    {
        [Ps1Xml(Label = "RuleId", Target = ViewControl.Table, Position = 0)]
        public string RuleId { get; set; }
        [Ps1Xml(Label = "SourceContainer", Target = ViewControl.Table, Position = 1)]
        public string SourceContainer { get; set; }
        [Ps1Xml(Label = "DestinationContainer", Target = ViewControl.Table, Position = 2)]
        public string DestinationContainer { get; set; }
        [Ps1Xml(Label = "Filter.PrefixMatch", Target = ViewControl.Table, ScriptBlock = "if (($_.Filter -ne $null) -and ($_.Filter.PrefixMatch -ne $null) -and ($_.Filter.PrefixMatch.Count -ne 0)) {'[' + ($_.Filter.PrefixMatch -join ', ') + ']'} else {$null}", Position = 3)]
        public PSObjectReplicationPolicyFilter Filters { get; set; }

        public PSObjectReplicationPolicyRule()
        {
        }

        public PSObjectReplicationPolicyRule(Track2Models.ObjectReplicationPolicyRule rule)
        {
            this.RuleId = rule.RuleId;
            this.SourceContainer = rule.SourceContainer;
            this.DestinationContainer = rule.DestinationContainer;
            this.Filters = rule.Filters is null ? null : new PSObjectReplicationPolicyFilter(rule.Filters);
        }

        public Track2Models.ObjectReplicationPolicyRule ParseObjectReplicationPolicyRule()
        {
            Track2Models.ObjectReplicationPolicyRule rule = new Track2Models.ObjectReplicationPolicyRule(this.SourceContainer, this.DestinationContainer);
            rule.RuleId = this.RuleId;
            rule.Filters = this.Filters?.ParseObjectReplicationPolicyFilter();
            return rule;
        }

        public static PSObjectReplicationPolicyRule[] GetPSObjectReplicationPolicyRules(IList<Track2Models.ObjectReplicationPolicyRule> rules)
        {
            if (rules == null)
            {
                return null;
            }
            List<PSObjectReplicationPolicyRule> psrules = new List<PSObjectReplicationPolicyRule>();
            foreach (Track2Models.ObjectReplicationPolicyRule rule in rules)
            {
                psrules.Add(new PSObjectReplicationPolicyRule(rule));
            }
            return psrules.ToArray();
        }
    }

    /// <summary>
    /// Wrapper of SDK type ObjectReplicationPolicyFilter
    /// </summary>
    public class PSObjectReplicationPolicyFilter
    {
        public string[] PrefixMatch { get; set; }
        public DateTimeOffset? MinCreationTime;

        public PSObjectReplicationPolicyFilter()
        {
        }

        public PSObjectReplicationPolicyFilter(Track2Models.ObjectReplicationPolicyFilter filter)
        {
            if (filter != null)
            {
                this.PrefixMatch = filter.PrefixMatch is null ? null : new List<string>(filter.PrefixMatch).ToArray();
                if (filter.MinCreationTime != null)
                {
                    if (filter.MinCreationTime.ToUpper()[filter.MinCreationTime.Length - 1] != 'Z')
                    {
                        filter.MinCreationTime += "Z";
                    }
                    this.MinCreationTime = Convert.ToDateTime(filter.MinCreationTime);
                }
            }
        }

        public Track2Models.ObjectReplicationPolicyFilter ParseObjectReplicationPolicyFilter()
        {
            Track2Models.ObjectReplicationPolicyFilter filter = new Track2Models.ObjectReplicationPolicyFilter();
            
            if (this.PrefixMatch != null)
            {
                foreach (string itm in this.PrefixMatch)
                {
                    filter.PrefixMatch.Add(itm);
                }
            }
            if (this.MinCreationTime != null)
            {
                filter.MinCreationTime = this.MinCreationTime.Value.ToUniversalTime().ToString("s") + "Z";
            }
            return filter;
        }
    }
}
