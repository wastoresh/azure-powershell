// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.KeyVault.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A list of private link resources
    /// </summary>
    public partial class MHSMPrivateLinkResourceListResult
    {
        /// <summary>
        /// Initializes a new instance of the MHSMPrivateLinkResourceListResult
        /// class.
        /// </summary>
        public MHSMPrivateLinkResourceListResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MHSMPrivateLinkResourceListResult
        /// class.
        /// </summary>
        /// <param name="value">Array of private link resources</param>
        public MHSMPrivateLinkResourceListResult(IList<MHSMPrivateLinkResource> value = default(IList<MHSMPrivateLinkResource>))
        {
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets array of private link resources
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<MHSMPrivateLinkResource> Value { get; set; }

    }
}
