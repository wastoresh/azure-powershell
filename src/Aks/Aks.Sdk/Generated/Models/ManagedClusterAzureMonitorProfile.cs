// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerService.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Azure Monitor addon profiles for monitoring the managed cluster.
    /// </summary>
    public partial class ManagedClusterAzureMonitorProfile
    {
        /// <summary>
        /// Initializes a new instance of the ManagedClusterAzureMonitorProfile
        /// class.
        /// </summary>
        public ManagedClusterAzureMonitorProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ManagedClusterAzureMonitorProfile
        /// class.
        /// </summary>
        public ManagedClusterAzureMonitorProfile(ManagedClusterAzureMonitorProfileMetrics metrics = default(ManagedClusterAzureMonitorProfileMetrics))
        {
            Metrics = metrics;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metrics")]
        public ManagedClusterAzureMonitorProfileMetrics Metrics { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Metrics != null)
            {
                Metrics.Validate();
            }
        }
    }
}
