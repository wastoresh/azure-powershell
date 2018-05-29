// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Commands.Common.Compute.Version_2018_04.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ResourceSkuRestrictionInfo
    {
        /// <summary>
        /// Initializes a new instance of the ResourceSkuRestrictionInfo class.
        /// </summary>
        public ResourceSkuRestrictionInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ResourceSkuRestrictionInfo class.
        /// </summary>
        /// <param name="locations">Locations where the SKU is
        /// restricted</param>
        /// <param name="zones">List of availability zones where the SKU is
        /// restricted.</param>
        public ResourceSkuRestrictionInfo(IList<string> locations = default(IList<string>), IList<string> zones = default(IList<string>))
        {
            Locations = locations;
            Zones = zones;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets locations where the SKU is restricted
        /// </summary>
        [JsonProperty(PropertyName = "locations")]
        public IList<string> Locations { get; private set; }

        /// <summary>
        /// Gets list of availability zones where the SKU is restricted.
        /// </summary>
        [JsonProperty(PropertyName = "zones")]
        public IList<string> Zones { get; private set; }

    }
}
