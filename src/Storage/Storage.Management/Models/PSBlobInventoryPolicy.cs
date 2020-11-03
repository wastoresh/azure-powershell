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

using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    /// <summary>
    /// Wrapper of SDK type BlobInventoryPolicy 
    /// </summary>
    public class PSBlobInventoryPolicy
    {
        public PSBlobInventoryPolicy()
        { }

        public PSBlobInventoryPolicy(BlobInventoryPolicy policy, string ResourceGroupName, string StorageAccountName)
        {
            this.ResourceGroupName = ResourceGroupName;
            this.StorageAccountName = StorageAccountName;
            this.Id = policy.Id;
            this.Name = policy.Name;
            this.Type = policy.Type;
            this.LastModifiedTime = policy.LastModifiedTime;
            this.SystemData = policy.SystemData is null ? null : new PSSystemData(policy.SystemData);

            this.Enabled = policy.Policy.Enabled;
            this.Destination = policy.Policy.Destination;

            if (policy.Policy.Rules != null)
            {
                List<PSBlobInventoryPolicyRule> psRules = new List<PSBlobInventoryPolicyRule>();
                foreach (BlobInventoryPolicyRule rule in policy.Policy.Rules)
                {
                    psRules.Add(new PSBlobInventoryPolicyRule(rule));
                }
                this.Rules = psRules.ToArray();
            }
            else
            {
                this.Rules = null;
            }
        }

        public BlobInventoryPolicy ParseBlobInventoryPolicy()
        {
            List<BlobInventoryPolicyRule> invRules = ParseBlobInventoryPolicyRules(this.Rules);

            BlobInventoryPolicySchema policySchema = new BlobInventoryPolicySchema()
            {
                Enabled = this.Enabled,
                Destination = this.Destination,
                Rules = invRules
            };
            return new BlobInventoryPolicy(
                policySchema,
                this.Id,
                this.Name,
                this.Type,
                this.LastModifiedTime,
                this.SystemData is null ? null : this.SystemData.ParseSystemData()
            );
        }

        public static List<BlobInventoryPolicyRule> ParseBlobInventoryPolicyRules(PSBlobInventoryPolicyRule[] rules)
        {
            List<BlobInventoryPolicyRule> invRules = null;
            if (rules != null)
            {
                invRules = new List<BlobInventoryPolicyRule>();
                foreach (PSBlobInventoryPolicyRule rule in rules)
                {
                    invRules.Add(rule.ParseBlobInventoryPolicyRule());
                }
            }
            return invRules;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 1)]
        public string ResourceGroupName { get; set; }
        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 0)]
        public string StorageAccountName { get; set; }
        [Ps1Xml(Label = "Id", Target = ViewControl.List, Position = 3)]
        public string Id { get; set; }
        public string Name { get; set; }
        [Ps1Xml(Label = "Type", Target = ViewControl.List, Position = 2)]
        public string Type { get; set; }
        [Ps1Xml(Label = "LastModifiedTime", Target = ViewControl.List, Position = 4)]
        public DateTime? LastModifiedTime { get; set; }

        //public PSBlobInventoryPolicySchema Policy { get; set; }

        [Ps1Xml(Label = "Enabled", Target = ViewControl.List, Position = 6)]
        public bool Enabled { get; set; }
        [Ps1Xml(Label = "Destination", Target = ViewControl.List, Position = 5)]
        public string Destination { get; set; }
        [Ps1Xml(Label = "Rules", Target = ViewControl.List, Position = 7)]
        public PSBlobInventoryPolicyRule[] Rules { get; set; }
        public PSSystemData SystemData { get; set; }
    }

    ///// <summary>
    ///// Wrapper of SDK type BlobInventoryPolicySchema
    ///// </summary>
    //public class PSBlobInventoryPolicySchema
    //{
    //    public PSBlobInventoryPolicySchema() { }

    //    public PSBlobInventoryPolicySchema(BlobInventoryPolicySchema Policy)
    //    {
    //        this.Enabled = Policy.Enabled;
    //        this.Destination = Policy.Destination;

    //        if (Policy.Rules != null)
    //        {
    //            List<PSBlobInventoryPolicyRule> psRules = new List<PSBlobInventoryPolicyRule>();
    //            foreach (BlobInventoryPolicyRule rule in Policy.Rules)
    //            {
    //                psRules.Add(new PSBlobInventoryPolicyRule(rule));
    //            }
    //            this.Rules = psRules.ToArray();
    //        }
    //        else
    //        {
    //            this.Rules = null;
    //        }
    //    }

    //    public BlobInventoryPolicySchema ParseBlobInventoryPolicySchema()
    //    {
    //        List<BlobInventoryPolicyRule> invRules = null;
    //        if (this.Rules != null)
    //        {
    //            invRules = new List<BlobInventoryPolicyRule>();
    //            foreach(PSBlobInventoryPolicyRule rule in this.Rules)
    //            {
    //                invRules.Add(rule.ParseBlobInventoryPolicyRule());
    //            }
    //        }
    //        return new BlobInventoryPolicySchema()
    //        {
    //            Enabled = this.Enabled,
    //            Destination = this.Destination,
    //            Rules = invRules
    //        };
    //    }

    //    public static List<BlobInventoryPolicyRule> ParseBlobInventoryPolicyRules(PSBlobInventoryPolicyRule[] rules)
    //    {
    //        List<BlobInventoryPolicyRule> invRules = null;
    //        if (rules != null)
    //        {
    //            invRules = new List<BlobInventoryPolicyRule>();
    //            foreach (PSBlobInventoryPolicyRule rule in rules)
    //            {
    //                invRules.Add(rule.ParseBlobInventoryPolicyRule());
    //            }
    //        }
    //        return invRules;
    //    }

    //    public bool Enabled { get; set; }

    //    public string Destination { get; set; }

    //    public PSBlobInventoryPolicyRule[] Rules { get; set; }
    //}

    /// <summary>
    /// Wrapper of SDK type BlobInventoryPolicyRule
    /// </summary>
    public class PSBlobInventoryPolicyRule
    {
        public PSBlobInventoryPolicyRule() { }
        public PSBlobInventoryPolicyRule(BlobInventoryPolicyRule rule)
        {
            this.Enabled = rule.Enabled;
            this.Name = rule.Name;
            this.Definition = rule.Definition is null ? null : new PSBlobInventoryPolicyDefinition(rule.Definition);
        }

        public BlobInventoryPolicyRule ParseBlobInventoryPolicyRule()
        {
            return new BlobInventoryPolicyRule()
            {
                Enabled = this.Enabled,
                Name = this.Name,
                Definition = this.Definition is null ? null : this.Definition.parseBlobInventoryPolicyDefinition()
            };
        }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public PSBlobInventoryPolicyDefinition Definition { get; set; }
    }

    /// <summary>
    /// Wrapper of SDK type BlobInventoryPolicyDefinition
    /// </summary>
    public class PSBlobInventoryPolicyDefinition
    {
        public PSBlobInventoryPolicyDefinition() { }

        public PSBlobInventoryPolicyDefinition(BlobInventoryPolicyDefinition Definition)
        {
            this.Filters = Definition.Filters is null ? null : new PSBlobInventoryPolicyFilter(Definition.Filters);
        }

        public BlobInventoryPolicyDefinition parseBlobInventoryPolicyDefinition()
        {
            return new BlobInventoryPolicyDefinition(this.Filters is null? null : this.Filters.ParseBlobInventoryPolicyFilter());
        }

        public PSBlobInventoryPolicyFilter Filters { get; set; }
    }

    /// <summary>
    /// Wrapper of SDK type BlobInventoryPolicyFilter
    /// </summary>
    public class PSBlobInventoryPolicyFilter
    {
        public PSBlobInventoryPolicyFilter() { }

        public PSBlobInventoryPolicyFilter(BlobInventoryPolicyFilter filters)
        {
            this.PrefixMatch = PSManagementPolicyRuleFilter.StringListToArray(filters.PrefixMatch);
            this.BlobTypes = PSManagementPolicyRuleFilter.StringListToArray(filters.BlobTypes);
            this.IncludeBlobVersions = filters.IncludeBlobVersions;
            this.IncludeSnapshots = filters.IncludeSnapshots;
        }

        public BlobInventoryPolicyFilter ParseBlobInventoryPolicyFilter()
        {
            return new BlobInventoryPolicyFilter()
            {
                PrefixMatch = PSManagementPolicyRuleFilter.StringArrayToList(this.PrefixMatch),
                BlobTypes = PSManagementPolicyRuleFilter.StringArrayToList(this.BlobTypes),
                IncludeSnapshots = this.IncludeSnapshots,
                IncludeBlobVersions = this.IncludeBlobVersions
            };
        }

        public string[] PrefixMatch { get; set; }
        public string[] BlobTypes { get; set; }
        public bool? IncludeBlobVersions { get; set; }
        public bool? IncludeSnapshots { get; set; }
    }

    /// <summary>
    /// Wrapper of SDK type SystemData
    /// </summary>
    public class PSSystemData
    {
        public PSSystemData() { }

        public PSSystemData(SystemData SystemData)
        {
            this.CreatedBy = SystemData.CreatedBy;
            this.CreatedByType = SystemData.CreatedByType;
            this.CreatedAt = SystemData.CreatedAt;
            this.LastModifiedBy = SystemData.LastModifiedBy;
            this.LastModifiedByType = SystemData.LastModifiedByType;
            this.LastModifiedAt = SystemData.LastModifiedAt;
        }

        public SystemData ParseSystemData()
        {
            return new SystemData(this.CreatedBy, this.CreatedByType, this.CreatedAt, this.LastModifiedBy, this.LastModifiedByType, this.LastModifiedAt);
        }

        public string CreatedBy { get; set; }
        public string CreatedByType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedByType { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }

}
