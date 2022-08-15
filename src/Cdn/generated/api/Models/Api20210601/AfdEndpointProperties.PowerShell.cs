// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601
{
    using Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.PowerShell;

    /// <summary>The JSON object that contains the properties required to create an endpoint.</summary>
    [System.ComponentModel.TypeConverter(typeof(AfdEndpointPropertiesTypeConverter))]
    public partial class AfdEndpointProperties
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AfdEndpointProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("HostName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).HostName, global::System.Convert.ToString);
            }
            if (content.Contains("AutoGeneratedDomainNameLabelScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).AutoGeneratedDomainNameLabelScope = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AutoGeneratedDomainNameLabelScope?) content.GetValueForProperty("AutoGeneratedDomainNameLabelScope",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).AutoGeneratedDomainNameLabelScope, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AutoGeneratedDomainNameLabelScope.CreateFrom);
            }
            if (content.Contains("ProfileName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).ProfileName = (string) content.GetValueForProperty("ProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).ProfileName, global::System.Convert.ToString);
            }
            if (content.Contains("EnabledState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).EnabledState = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState?) content.GetValueForProperty("EnabledState",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).EnabledState, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState.CreateFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState.CreateFrom);
            }
            if (content.Contains("DeploymentStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).DeploymentStatus = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus?) content.GetValueForProperty("DeploymentStatus",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).DeploymentStatus, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus.CreateFrom);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AfdEndpointProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("HostName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).HostName = (string) content.GetValueForProperty("HostName",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).HostName, global::System.Convert.ToString);
            }
            if (content.Contains("AutoGeneratedDomainNameLabelScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).AutoGeneratedDomainNameLabelScope = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AutoGeneratedDomainNameLabelScope?) content.GetValueForProperty("AutoGeneratedDomainNameLabelScope",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesInternal)this).AutoGeneratedDomainNameLabelScope, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AutoGeneratedDomainNameLabelScope.CreateFrom);
            }
            if (content.Contains("ProfileName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).ProfileName = (string) content.GetValueForProperty("ProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).ProfileName, global::System.Convert.ToString);
            }
            if (content.Contains("EnabledState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).EnabledState = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState?) content.GetValueForProperty("EnabledState",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)this).EnabledState, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState.CreateFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState.CreateFrom);
            }
            if (content.Contains("DeploymentStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).DeploymentStatus = (Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus?) content.GetValueForProperty("DeploymentStatus",((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdStatePropertiesInternal)this).DeploymentStatus, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus.CreateFrom);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AfdEndpointProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AfdEndpointProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AfdEndpointProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="AfdEndpointProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The JSON object that contains the properties required to create an endpoint.
    [System.ComponentModel.TypeConverter(typeof(AfdEndpointPropertiesTypeConverter))]
    public partial interface IAfdEndpointProperties

    {

    }
}