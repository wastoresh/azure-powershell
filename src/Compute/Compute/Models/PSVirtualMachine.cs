// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using System;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachine : PSOperation
    {
        // Gets or sets the property of 'ResourceGroupName'
        public string ResourceGroupName
        {
            get
            {
                if (string.IsNullOrEmpty(Id)) return null;
                Regex r = new Regex(@"(.*?)/resourcegroups/(?<rgname>\S+)/providers/(.*?)", RegexOptions.IgnoreCase);
                Match m = r.Match(Id);
                return m.Success ? m.Groups["rgname"].Value : null;
            }
        }

        // Gets or sets the property of 'Id'
        public string Id { get; set; }

        // Gets the property of 'VmId'
        public string VmId { get; set; }

        // Gets or sets the property of 'Name'
        public string Name { get; set; }

        // Gets or sets the property of 'Type'
        public string Type { get; set; }

        // Gets or sets the property of 'Location'
        public string Location { get; set; }

        // Gets or sets the property of 'EdgeZone'
        public ExtendedLocation ExtendedLocation { get; set; }

        // Gets or sets the license type
        public string LicenseType { get; set; }

        // Gets or sets the property of 'Tags'
        public IDictionary<string, string> Tags { get; set; }

        // Gets or sets the reference Id of the availailbity set to which this virtual machine belongs.
        public SubResource AvailabilitySetReference { get; set; }

        // Gets or sets the diagnostics profile.
        public DiagnosticsProfile DiagnosticsProfile { get; set; }

        // Gets the virtual machine child extension resources.
        public IList<VirtualMachineExtension> Extensions { get; set; }

        // Gets or sets the hardware profile.
        public HardwareProfile HardwareProfile { get; set; }

        // Gets the virtual machine instance view.
        public VirtualMachineInstanceView InstanceView { get; set; }

        // Gets or sets the network profile.
        public NetworkProfile NetworkProfile { get; set; }

        //Gets or sets the security profile 
        public SecurityProfile SecurityProfile { get; set; }

        //Gets or sets the OS name
        public string OsName { get; set; }
        //Gets or sets the OS version
        public string OsVersion { get; set; }
        //Gets or sets the HyperV Generation
        public string HyperVGeneration { get; set; }

        // Gets or sets the OS profile.
        public OSProfile OSProfile { get; set; }

        // Gets or sets the Billing profile.
        public BillingProfile BillingProfile { get; set; }

        // Gets or sets the purchase plan when deploying virtual machine from VM Marketplace images.
        public Plan Plan { get; set; }

        // Gets or sets the provisioning state, which only appears in the response.
        public string ProvisioningState { get; set; }

        // Gets or sets the storage profile.
        public StorageProfile StorageProfile { get; set; }

        public DisplayHintType DisplayHint { get; set; }

        // Gets or sets the virtual machine identity.
        public VirtualMachineIdentity Identity { get; set; }

        // Gets or sets the virtual machine zones.
        public IList<string> Zones { get; set; }

        // Gets or sets the FQDN.
        public string FullyQualifiedDomainName { get; set; }

        // Gets or sets the AdditionalCapabilities
        public AdditionalCapabilities AdditionalCapabilities { get; set; }

        // Gets or sets the ProximityPlacementGroup
        public SubResource ProximityPlacementGroup { get; set; }

        // Gets or sets the Host
        public SubResource Host { get; set; }

        // Gets or sets the VirtualMachineScaleSet
        public SubResource VirtualMachineScaleSet { get; set; }

        // Gets or sets the EvictionPolicy
        public string EvictionPolicy { get; set; }

        // Gets or sets the Priority
        public string Priority { get; set; }
        
        // Gets or sets the HostGroup
        public SubResource HostGroup { get; set; }

        public CapacityReservationProfile CapacityReservation { get; set; }
        
        // Gets or sets the UserData
        public string UserData { get; set; }
        
        public PSApplicationProfile ApplicationProfile { get; set; }

        public int? PlatformFaultDomain { get; set; }

        //
        // Summary:
        //     Gets specifies the time at which the Virtual Machine resource was created.&lt;br&gt;&lt;br&gt;Minimum
        //     api-version: 2022-03-01.
        public DateTime? TimeCreated { get; private set; }
    }
}
