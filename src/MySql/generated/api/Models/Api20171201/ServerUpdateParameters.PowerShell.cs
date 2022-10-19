// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.PowerShell;

    /// <summary>Parameters allowed to update for a server.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerUpdateParametersTypeConverter))]
    public partial class ServerUpdateParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerUpdateParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParameters" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerUpdateParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerUpdateParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ServerUpdateParameters" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerUpdateParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ResourceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParametersPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParametersTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType.CreateFrom);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier.CreateFrom);
            }
            if (content.Contains("SkuCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SkuSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuSize, global::System.Convert.ToString);
            }
            if (content.Contains("SkuFamily"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuFamily, global::System.Convert.ToString);
            }
            if (content.Contains("StorageProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion.CreateFrom);
            }
            if (content.Contains("SslEnforcement"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum.CreateFrom);
            }
            if (content.Contains("MinimalTlsVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).MinimalTlsVersion = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum?) content.GetValueForProperty("MinimalTlsVersion",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).MinimalTlsVersion, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum.CreateFrom);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum.CreateFrom);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("StorageProfileStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageProfileStorageAutogrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow.CreateFrom);
            }
            if (content.Contains("StorageProfileBackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageProfileGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup.CreateFrom);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerUpdateParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IResourceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ResourceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Sku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.SkuTypeConverter.ConvertFrom);
            }
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParametersPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerUpdateParametersTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.IdentityType.CreateFrom);
            }
            if (content.Contains("SkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SkuTier"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SkuTier.CreateFrom);
            }
            if (content.Contains("SkuCapacity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SkuSize"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuSize = (string) content.GetValueForProperty("SkuSize",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuSize, global::System.Convert.ToString);
            }
            if (content.Contains("SkuFamily"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuFamily = (string) content.GetValueForProperty("SkuFamily",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SkuFamily, global::System.Convert.ToString);
            }
            if (content.Contains("StorageProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IStorageProfile) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfileTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("AdministratorLoginPassword"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).AdministratorLoginPassword = (System.Security.SecureString) content.GetValueForProperty("AdministratorLoginPassword",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).AdministratorLoginPassword, (object ss) => (System.Security.SecureString)ss);
            }
            if (content.Contains("Version"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Version = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).Version, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.ServerVersion.CreateFrom);
            }
            if (content.Contains("SslEnforcement"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SslEnforcement = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum?) content.GetValueForProperty("SslEnforcement",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).SslEnforcement, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.SslEnforcementEnum.CreateFrom);
            }
            if (content.Contains("MinimalTlsVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).MinimalTlsVersion = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum?) content.GetValueForProperty("MinimalTlsVersion",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).MinimalTlsVersion, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.MinimalTlsVersionEnum.CreateFrom);
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.PublicNetworkAccessEnum.CreateFrom);
            }
            if (content.Contains("ReplicationRole"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).ReplicationRole = (string) content.GetValueForProperty("ReplicationRole",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).ReplicationRole, global::System.Convert.ToString);
            }
            if (content.Contains("StorageProfileStorageMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageMb = (int?) content.GetValueForProperty("StorageProfileStorageMb",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageProfileStorageAutogrow"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageAutogrow = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow?) content.GetValueForProperty("StorageProfileStorageAutogrow",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileStorageAutogrow, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.StorageAutogrow.CreateFrom);
            }
            if (content.Contains("StorageProfileBackupRetentionDay"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileBackupRetentionDay = (int?) content.GetValueForProperty("StorageProfileBackupRetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileBackupRetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("StorageProfileGeoRedundantBackup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileGeoRedundantBackup = (Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup?) content.GetValueForProperty("StorageProfileGeoRedundantBackup",((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerUpdateParametersInternal)this).StorageProfileGeoRedundantBackup, Microsoft.Azure.PowerShell.Cmdlets.MySql.Support.GeoRedundantBackup.CreateFrom);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters allowed to update for a server.
    [System.ComponentModel.TypeConverter(typeof(ServerUpdateParametersTypeConverter))]
    public partial interface IServerUpdateParameters

    {

    }
}