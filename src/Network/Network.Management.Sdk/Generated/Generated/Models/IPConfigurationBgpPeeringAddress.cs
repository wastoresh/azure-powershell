// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Properties of IPConfigurationBgpPeeringAddress.
    /// </summary>
    public partial class IPConfigurationBgpPeeringAddress
    {
        /// <summary>
        /// Initializes a new instance of the IPConfigurationBgpPeeringAddress
        /// class.
        /// </summary>
        public IPConfigurationBgpPeeringAddress()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IPConfigurationBgpPeeringAddress
        /// class.
        /// </summary>
        /// <param name="ipconfigurationId">The ID of IP configuration which
        /// belongs to gateway.</param>
        /// <param name="defaultBgpIpAddresses">The list of default BGP peering
        /// addresses which belong to IP configuration.</param>
        /// <param name="customBgpIpAddresses">The list of custom BGP peering
        /// addresses which belong to IP configuration.</param>
        /// <param name="tunnelIpAddresses">The list of tunnel public IP
        /// addresses which belong to IP configuration.</param>
        public IPConfigurationBgpPeeringAddress(string ipconfigurationId = default(string), IList<string> defaultBgpIpAddresses = default(IList<string>), IList<string> customBgpIpAddresses = default(IList<string>), IList<string> tunnelIpAddresses = default(IList<string>))
        {
            IpconfigurationId = ipconfigurationId;
            DefaultBgpIpAddresses = defaultBgpIpAddresses;
            CustomBgpIpAddresses = customBgpIpAddresses;
            TunnelIpAddresses = tunnelIpAddresses;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the ID of IP configuration which belongs to gateway.
        /// </summary>
        [JsonProperty(PropertyName = "ipconfigurationId")]
        public string IpconfigurationId { get; set; }

        /// <summary>
        /// Gets the list of default BGP peering addresses which belong to IP
        /// configuration.
        /// </summary>
        [JsonProperty(PropertyName = "defaultBgpIpAddresses")]
        public IList<string> DefaultBgpIpAddresses { get; private set; }

        /// <summary>
        /// Gets or sets the list of custom BGP peering addresses which belong
        /// to IP configuration.
        /// </summary>
        [JsonProperty(PropertyName = "customBgpIpAddresses")]
        public IList<string> CustomBgpIpAddresses { get; set; }

        /// <summary>
        /// Gets the list of tunnel public IP addresses which belong to IP
        /// configuration.
        /// </summary>
        [JsonProperty(PropertyName = "tunnelIpAddresses")]
        public IList<string> TunnelIpAddresses { get; private set; }

    }
}
