// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101
{
    using Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Runtime.PowerShell;

    /// <summary>Dicom Service properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(DicomServicePropertiesTypeConverter))]
    public partial class DicomServiceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.DicomServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DicomServiceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.DicomServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DicomServiceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.DicomServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DicomServiceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("AuthenticationConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceAuthenticationConfiguration) content.GetValueForProperty("AuthenticationConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfiguration, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.DicomServiceAuthenticationConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ProvisioningState.CreateFrom);
            }
            if (content.Contains("ServiceUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ServiceUrl = (string) content.GetValueForProperty("ServiceUrl",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ServiceUrl, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.IPrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.PublicNetworkAccess?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.PublicNetworkAccess.CreateFrom);
            }
            if (content.Contains("AuthenticationConfigurationAuthority"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAuthority = (string) content.GetValueForProperty("AuthenticationConfigurationAuthority",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAuthority, global::System.Convert.ToString);
            }
            if (content.Contains("AuthenticationConfigurationAudience"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAudience = (string[]) content.GetValueForProperty("AuthenticationConfigurationAudience",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.DicomServiceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DicomServiceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("AuthenticationConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceAuthenticationConfiguration) content.GetValueForProperty("AuthenticationConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfiguration, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.DicomServiceAuthenticationConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ProvisioningState.CreateFrom);
            }
            if (content.Contains("ServiceUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ServiceUrl = (string) content.GetValueForProperty("ServiceUrl",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).ServiceUrl, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.IPrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.PublicNetworkAccess?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.PublicNetworkAccess.CreateFrom);
            }
            if (content.Contains("AuthenticationConfigurationAuthority"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAuthority = (string) content.GetValueForProperty("AuthenticationConfigurationAuthority",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAuthority, global::System.Convert.ToString);
            }
            if (content.Contains("AuthenticationConfigurationAudience"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAudience = (string[]) content.GetValueForProperty("AuthenticationConfigurationAudience",((Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServicePropertiesInternal)this).AuthenticationConfigurationAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DicomServiceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DicomServiceProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomServiceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Dicom Service properties.
    [System.ComponentModel.TypeConverter(typeof(DicomServicePropertiesTypeConverter))]
    public partial interface IDicomServiceProperties

    {

    }
}