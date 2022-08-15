// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501
{
    using Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.PowerShell;

    /// <summary>Batch endpoint configuration.</summary>
    [System.ComponentModel.TypeConverter(typeof(BatchEndpointPropertiesTypeConverter))]
    public partial class BatchEndpointProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.BatchEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BatchEndpointProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Default"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).Default = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointDefaults) content.GetValueForProperty("Default",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).Default, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.BatchEndpointDefaultsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointProvisioningState.CreateFrom);
            }
            if (content.Contains("KeyPrimaryKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeyPrimaryKey = (string) content.GetValueForProperty("KeyPrimaryKey",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeyPrimaryKey, global::System.Convert.ToString);
            }
            if (content.Contains("KeySecondaryKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeySecondaryKey = (string) content.GetValueForProperty("KeySecondaryKey",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeySecondaryKey, global::System.Convert.ToString);
            }
            if (content.Contains("Key"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Key = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointAuthKeys) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Key, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.EndpointAuthKeysTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).AuthMode = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointAuthMode) content.GetValueForProperty("AuthMode",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).AuthMode, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointAuthMode.CreateFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.EndpointPropertiesBasePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ScoringUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).ScoringUri = (string) content.GetValueForProperty("ScoringUri",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).ScoringUri, global::System.Convert.ToString);
            }
            if (content.Contains("SwaggerUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).SwaggerUri = (string) content.GetValueForProperty("SwaggerUri",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).SwaggerUri, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultDeploymentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).DefaultDeploymentName = (string) content.GetValueForProperty("DefaultDeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).DefaultDeploymentName, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.BatchEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BatchEndpointProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Default"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).Default = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointDefaults) content.GetValueForProperty("Default",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).Default, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.BatchEndpointDefaultsTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointProvisioningState.CreateFrom);
            }
            if (content.Contains("KeyPrimaryKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeyPrimaryKey = (string) content.GetValueForProperty("KeyPrimaryKey",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeyPrimaryKey, global::System.Convert.ToString);
            }
            if (content.Contains("KeySecondaryKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeySecondaryKey = (string) content.GetValueForProperty("KeySecondaryKey",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).KeySecondaryKey, global::System.Convert.ToString);
            }
            if (content.Contains("Key"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Key = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointAuthKeys) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Key, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.EndpointAuthKeysTypeConverter.ConvertFrom);
            }
            if (content.Contains("AuthMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).AuthMode = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointAuthMode) content.GetValueForProperty("AuthMode",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).AuthMode, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointAuthMode.CreateFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.EndpointPropertiesBasePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ScoringUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).ScoringUri = (string) content.GetValueForProperty("ScoringUri",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).ScoringUri, global::System.Convert.ToString);
            }
            if (content.Contains("SwaggerUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).SwaggerUri = (string) content.GetValueForProperty("SwaggerUri",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IEndpointPropertiesBaseInternal)this).SwaggerUri, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultDeploymentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).DefaultDeploymentName = (string) content.GetValueForProperty("DefaultDeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointPropertiesInternal)this).DefaultDeploymentName, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.BatchEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BatchEndpointProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.BatchEndpointProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BatchEndpointProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BatchEndpointProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="BatchEndpointProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IBatchEndpointProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Batch endpoint configuration.
    [System.ComponentModel.TypeConverter(typeof(BatchEndpointPropertiesTypeConverter))]
    public partial interface IBatchEndpointProperties

    {

    }
}