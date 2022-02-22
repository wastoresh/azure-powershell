// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    /// <summary>Properties of the private link service.</summary>
    [System.ComponentModel.TypeConverter(typeof(PrivateLinkServicePropertiesTypeConverter))]
    public partial class PrivateLinkServiceProperties
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PrivateLinkServiceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PrivateLinkServiceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PrivateLinkServiceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PrivateLinkServiceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Visibility"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Visibility = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceSet) content.GetValueForProperty("Visibility",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Visibility, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceSetTypeConverter.ConvertFrom);
            }
            if (content.Contains("AutoApproval"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApproval = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceSet) content.GetValueForProperty("AutoApproval",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApproval, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceSetTypeConverter.ConvertFrom);
            }
            if (content.Contains("LoadBalancerFrontendIPConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).LoadBalancerFrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IFrontendIPConfiguration[]) content.GetValueForProperty("LoadBalancerFrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).LoadBalancerFrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IFrontendIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.FrontendIPConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("IPConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceIPConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("NetworkInterface"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.NetworkInterfaceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState.CreateFrom);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("Fqdn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Fqdn = (string[]) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Fqdn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Alias"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Alias = (string) content.GetValueForProperty("Alias",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Alias, global::System.Convert.ToString);
            }
            if (content.Contains("EnableProxyProtocol"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).EnableProxyProtocol = (bool?) content.GetValueForProperty("EnableProxyProtocol",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).EnableProxyProtocol, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("VisibilitySubscription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).VisibilitySubscription = (string[]) content.GetValueForProperty("VisibilitySubscription",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).VisibilitySubscription, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("AutoApprovalSubscription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApprovalSubscription = (string[]) content.GetValueForProperty("AutoApprovalSubscription",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApprovalSubscription, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PrivateLinkServiceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Visibility"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Visibility = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceSet) content.GetValueForProperty("Visibility",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Visibility, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceSetTypeConverter.ConvertFrom);
            }
            if (content.Contains("AutoApproval"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApproval = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceSet) content.GetValueForProperty("AutoApproval",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApproval, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ResourceSetTypeConverter.ConvertFrom);
            }
            if (content.Contains("LoadBalancerFrontendIPConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).LoadBalancerFrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IFrontendIPConfiguration[]) content.GetValueForProperty("LoadBalancerFrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).LoadBalancerFrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IFrontendIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.FrontendIPConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("IPConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServiceIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateLinkServiceIPConfigurationTypeConverter.ConvertFrom));
            }
            if (content.Contains("NetworkInterface"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.NetworkInterfaceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.ProvisioningState.CreateFrom);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("Fqdn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Fqdn = (string[]) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Fqdn, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("Alias"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Alias = (string) content.GetValueForProperty("Alias",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).Alias, global::System.Convert.ToString);
            }
            if (content.Contains("EnableProxyProtocol"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).EnableProxyProtocol = (bool?) content.GetValueForProperty("EnableProxyProtocol",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).EnableProxyProtocol, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("VisibilitySubscription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).VisibilitySubscription = (string[]) content.GetValueForProperty("VisibilitySubscription",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).VisibilitySubscription, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("AutoApprovalSubscription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApprovalSubscription = (string[]) content.GetValueForProperty("AutoApprovalSubscription",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IPrivateLinkServicePropertiesInternal)this).AutoApprovalSubscription, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the private link service.
    [System.ComponentModel.TypeConverter(typeof(PrivateLinkServicePropertiesTypeConverter))]
    public partial interface IPrivateLinkServiceProperties

    {

    }
}