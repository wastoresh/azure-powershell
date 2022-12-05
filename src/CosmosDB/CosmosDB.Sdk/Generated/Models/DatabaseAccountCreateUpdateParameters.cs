// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.CosmosDB.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parameters to create and update Cosmos DB database accounts.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class DatabaseAccountCreateUpdateParameters : ARMResourceProperties
    {
        /// <summary>
        /// Initializes a new instance of the
        /// DatabaseAccountCreateUpdateParameters class.
        /// </summary>
        public DatabaseAccountCreateUpdateParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// DatabaseAccountCreateUpdateParameters class.
        /// </summary>
        /// <param name="locations">An array that contains the georeplication
        /// locations enabled for the Cosmos DB account.</param>
        /// <param name="id">The unique resource identifier of the ARM
        /// resource.</param>
        /// <param name="name">The name of the ARM resource.</param>
        /// <param name="type">The type of Azure resource.</param>
        /// <param name="location">The location of the resource group to which
        /// the resource belongs.</param>
        /// <param name="kind">Indicates the type of database account. This can
        /// only be set at database account creation. Possible values include:
        /// 'GlobalDocumentDB', 'MongoDB', 'Parse'</param>
        /// <param name="consistencyPolicy">The consistency policy for the
        /// Cosmos DB account.</param>
        /// <param name="ipRules">List of IpRules.</param>
        /// <param name="isVirtualNetworkFilterEnabled">Flag to indicate
        /// whether to enable/disable Virtual Network ACL rules.</param>
        /// <param name="enableAutomaticFailover">Enables automatic failover of
        /// the write region in the rare event that the region is unavailable
        /// due to an outage. Automatic failover will result in a new write
        /// region for the account and is chosen based on the failover
        /// priorities configured for the account.</param>
        /// <param name="capabilities">List of Cosmos DB capabilities for the
        /// account</param>
        /// <param name="virtualNetworkRules">List of Virtual Network ACL rules
        /// configured for the Cosmos DB account.</param>
        /// <param name="enableMultipleWriteLocations">Enables the account to
        /// write in multiple locations</param>
        /// <param name="enableCassandraConnector">Enables the cassandra
        /// connector on the Cosmos DB C* account</param>
        /// <param name="connectorOffer">The cassandra connector offer type for
        /// the Cosmos DB database C* account. Possible values include:
        /// 'Small'</param>
        /// <param name="disableKeyBasedMetadataWriteAccess">Disable write
        /// operations on metadata resources (databases, containers,
        /// throughput) via account keys</param>
        /// <param name="keyVaultKeyUri">The URI of the key vault</param>
        /// <param name="defaultIdentity">The default identity for accessing
        /// key vault used in features like customer managed keys. The default
        /// identity needs to be explicitly set by the users. It can be
        /// "FirstPartyIdentity", "SystemAssignedIdentity" and more.</param>
        /// <param name="publicNetworkAccess">Whether requests from Public
        /// Network are allowed. Possible values include: 'Enabled',
        /// 'Disabled'</param>
        /// <param name="enableFreeTier">Flag to indicate whether Free Tier is
        /// enabled.</param>
        /// <param name="apiProperties">API specific properties. Currently,
        /// supported only for MongoDB API.</param>
        /// <param name="enableAnalyticalStorage">Flag to indicate whether to
        /// enable storage analytics.</param>
        /// <param name="analyticalStorageConfiguration">Analytical storage
        /// specific properties.</param>
        /// <param name="createMode">Enum to indicate the mode of account
        /// creation. Possible values include: 'Default', 'Restore'</param>
        /// <param name="backupPolicy">The object representing the policy for
        /// taking backups on an account.</param>
        /// <param name="cors">The CORS policy for the Cosmos DB database
        /// account.</param>
        /// <param name="networkAclBypass">Indicates what services are allowed
        /// to bypass firewall checks. Possible values include: 'None',
        /// 'AzureServices'</param>
        /// <param name="networkAclBypassResourceIds">An array that contains
        /// the Resource Ids for Network Acl Bypass for the Cosmos DB
        /// account.</param>
        /// <param name="diagnosticLogSettings">The Object representing the
        /// different Diagnostic log settings for the Cosmos DB
        /// Account.</param>
        /// <param name="disableLocalAuth">Opt-out of local authentication and
        /// ensure only MSI and AAD can be used exclusively for
        /// authentication.</param>
        /// <param name="restoreParameters">Parameters to indicate the
        /// information about the restore.</param>
        /// <param name="capacity">The object that represents all properties
        /// related to capacity enforcement on an account.</param>
        /// <param name="enableMaterializedViews">Flag to indicate whether to
        /// enable MaterializedViews on the Cosmos DB account</param>
        /// <param name="keysMetadata">This property is ignored during the
        /// update/create operation, as the metadata is read-only. The object
        /// represents the metadata for the Account Keys of the Cosmos DB
        /// account.</param>
        /// <param name="enablePartitionMerge">Flag to indicate
        /// enabling/disabling of Partition Merge feature on the
        /// account</param>
        public DatabaseAccountCreateUpdateParameters(IList<Location> locations, string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), ManagedServiceIdentity identity = default(ManagedServiceIdentity), string kind = default(string), ConsistencyPolicy consistencyPolicy = default(ConsistencyPolicy), IList<IpAddressOrRange> ipRules = default(IList<IpAddressOrRange>), bool? isVirtualNetworkFilterEnabled = default(bool?), bool? enableAutomaticFailover = default(bool?), IList<Capability> capabilities = default(IList<Capability>), IList<VirtualNetworkRule> virtualNetworkRules = default(IList<VirtualNetworkRule>), bool? enableMultipleWriteLocations = default(bool?), bool? enableCassandraConnector = default(bool?), string connectorOffer = default(string), bool? disableKeyBasedMetadataWriteAccess = default(bool?), string keyVaultKeyUri = default(string), string defaultIdentity = default(string), string publicNetworkAccess = default(string), bool? enableFreeTier = default(bool?), ApiProperties apiProperties = default(ApiProperties), bool? enableAnalyticalStorage = default(bool?), AnalyticalStorageConfiguration analyticalStorageConfiguration = default(AnalyticalStorageConfiguration), string createMode = default(string), BackupPolicy backupPolicy = default(BackupPolicy), IList<CorsPolicy> cors = default(IList<CorsPolicy>), NetworkAclBypass? networkAclBypass = default(NetworkAclBypass?), IList<string> networkAclBypassResourceIds = default(IList<string>), DiagnosticLogSettings diagnosticLogSettings = default(DiagnosticLogSettings), bool? disableLocalAuth = default(bool?), RestoreParameters restoreParameters = default(RestoreParameters), Capacity capacity = default(Capacity), bool? enableMaterializedViews = default(bool?), DatabaseAccountKeysMetadata keysMetadata = default(DatabaseAccountKeysMetadata), bool? enablePartitionMerge = default(bool?))
            : base(id, name, type, location, tags, identity)
        {
            Kind = kind;
            ConsistencyPolicy = consistencyPolicy;
            Locations = locations;
            IpRules = ipRules;
            IsVirtualNetworkFilterEnabled = isVirtualNetworkFilterEnabled;
            EnableAutomaticFailover = enableAutomaticFailover;
            Capabilities = capabilities;
            VirtualNetworkRules = virtualNetworkRules;
            EnableMultipleWriteLocations = enableMultipleWriteLocations;
            EnableCassandraConnector = enableCassandraConnector;
            ConnectorOffer = connectorOffer;
            DisableKeyBasedMetadataWriteAccess = disableKeyBasedMetadataWriteAccess;
            KeyVaultKeyUri = keyVaultKeyUri;
            DefaultIdentity = defaultIdentity;
            PublicNetworkAccess = publicNetworkAccess;
            EnableFreeTier = enableFreeTier;
            ApiProperties = apiProperties;
            EnableAnalyticalStorage = enableAnalyticalStorage;
            AnalyticalStorageConfiguration = analyticalStorageConfiguration;
            CreateMode = createMode;
            BackupPolicy = backupPolicy;
            Cors = cors;
            NetworkAclBypass = networkAclBypass;
            NetworkAclBypassResourceIds = networkAclBypassResourceIds;
            DiagnosticLogSettings = diagnosticLogSettings;
            DisableLocalAuth = disableLocalAuth;
            RestoreParameters = restoreParameters;
            Capacity = capacity;
            EnableMaterializedViews = enableMaterializedViews;
            KeysMetadata = keysMetadata;
            EnablePartitionMerge = enablePartitionMerge;
            CustomInit();
        }
        /// <summary>
        /// Static constructor for DatabaseAccountCreateUpdateParameters class.
        /// </summary>
        static DatabaseAccountCreateUpdateParameters()
        {
            DatabaseAccountOfferType = "Standard";
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets indicates the type of database account. This can only
        /// be set at database account creation. Possible values include:
        /// 'GlobalDocumentDB', 'MongoDB', 'Parse'
        /// </summary>
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the consistency policy for the Cosmos DB account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.consistencyPolicy")]
        public ConsistencyPolicy ConsistencyPolicy { get; set; }

        /// <summary>
        /// Gets or sets an array that contains the georeplication locations
        /// enabled for the Cosmos DB account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.locations")]
        public IList<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets list of IpRules.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ipRules")]
        public IList<IpAddressOrRange> IpRules { get; set; }

        /// <summary>
        /// Gets or sets flag to indicate whether to enable/disable Virtual
        /// Network ACL rules.
        /// </summary>
        [JsonProperty(PropertyName = "properties.isVirtualNetworkFilterEnabled")]
        public bool? IsVirtualNetworkFilterEnabled { get; set; }

        /// <summary>
        /// Gets or sets enables automatic failover of the write region in the
        /// rare event that the region is unavailable due to an outage.
        /// Automatic failover will result in a new write region for the
        /// account and is chosen based on the failover priorities configured
        /// for the account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableAutomaticFailover")]
        public bool? EnableAutomaticFailover { get; set; }

        /// <summary>
        /// Gets or sets list of Cosmos DB capabilities for the account
        /// </summary>
        [JsonProperty(PropertyName = "properties.capabilities")]
        public IList<Capability> Capabilities { get; set; }

        /// <summary>
        /// Gets or sets list of Virtual Network ACL rules configured for the
        /// Cosmos DB account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualNetworkRules")]
        public IList<VirtualNetworkRule> VirtualNetworkRules { get; set; }

        /// <summary>
        /// Gets or sets enables the account to write in multiple locations
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableMultipleWriteLocations")]
        public bool? EnableMultipleWriteLocations { get; set; }

        /// <summary>
        /// Gets or sets enables the cassandra connector on the Cosmos DB C*
        /// account
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableCassandraConnector")]
        public bool? EnableCassandraConnector { get; set; }

        /// <summary>
        /// Gets or sets the cassandra connector offer type for the Cosmos DB
        /// database C* account. Possible values include: 'Small'
        /// </summary>
        [JsonProperty(PropertyName = "properties.connectorOffer")]
        public string ConnectorOffer { get; set; }

        /// <summary>
        /// Gets or sets disable write operations on metadata resources
        /// (databases, containers, throughput) via account keys
        /// </summary>
        [JsonProperty(PropertyName = "properties.disableKeyBasedMetadataWriteAccess")]
        public bool? DisableKeyBasedMetadataWriteAccess { get; set; }

        /// <summary>
        /// Gets or sets the URI of the key vault
        /// </summary>
        [JsonProperty(PropertyName = "properties.keyVaultKeyUri")]
        public string KeyVaultKeyUri { get; set; }

        /// <summary>
        /// Gets or sets the default identity for accessing key vault used in
        /// features like customer managed keys. The default identity needs to
        /// be explicitly set by the users. It can be "FirstPartyIdentity",
        /// "SystemAssignedIdentity" and more.
        /// </summary>
        [JsonProperty(PropertyName = "properties.defaultIdentity")]
        public string DefaultIdentity { get; set; }

        /// <summary>
        /// Gets or sets whether requests from Public Network are allowed.
        /// Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicNetworkAccess")]
        public string PublicNetworkAccess { get; set; }

        /// <summary>
        /// Gets or sets flag to indicate whether Free Tier is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableFreeTier")]
        public bool? EnableFreeTier { get; set; }

        /// <summary>
        /// Gets or sets API specific properties. Currently, supported only for
        /// MongoDB API.
        /// </summary>
        [JsonProperty(PropertyName = "properties.apiProperties")]
        public ApiProperties ApiProperties { get; set; }

        /// <summary>
        /// Gets or sets flag to indicate whether to enable storage analytics.
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableAnalyticalStorage")]
        public bool? EnableAnalyticalStorage { get; set; }

        /// <summary>
        /// Gets or sets analytical storage specific properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties.analyticalStorageConfiguration")]
        public AnalyticalStorageConfiguration AnalyticalStorageConfiguration { get; set; }

        /// <summary>
        /// Gets or sets enum to indicate the mode of account creation.
        /// Possible values include: 'Default', 'Restore'
        /// </summary>
        [JsonProperty(PropertyName = "properties.createMode")]
        public string CreateMode { get; set; }

        /// <summary>
        /// Gets or sets the object representing the policy for taking backups
        /// on an account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.backupPolicy")]
        public BackupPolicy BackupPolicy { get; set; }

        /// <summary>
        /// Gets or sets the CORS policy for the Cosmos DB database account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.cors")]
        public IList<CorsPolicy> Cors { get; set; }

        /// <summary>
        /// Gets or sets indicates what services are allowed to bypass firewall
        /// checks. Possible values include: 'None', 'AzureServices'
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkAclBypass")]
        public NetworkAclBypass? NetworkAclBypass { get; set; }

        /// <summary>
        /// Gets or sets an array that contains the Resource Ids for Network
        /// Acl Bypass for the Cosmos DB account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkAclBypassResourceIds")]
        public IList<string> NetworkAclBypassResourceIds { get; set; }

        /// <summary>
        /// Gets or sets the Object representing the different Diagnostic log
        /// settings for the Cosmos DB Account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.diagnosticLogSettings")]
        public DiagnosticLogSettings DiagnosticLogSettings { get; set; }

        /// <summary>
        /// Gets or sets opt-out of local authentication and ensure only MSI
        /// and AAD can be used exclusively for authentication.
        /// </summary>
        [JsonProperty(PropertyName = "properties.disableLocalAuth")]
        public bool? DisableLocalAuth { get; set; }

        /// <summary>
        /// Gets or sets parameters to indicate the information about the
        /// restore.
        /// </summary>
        [JsonProperty(PropertyName = "properties.restoreParameters")]
        public RestoreParameters RestoreParameters { get; set; }

        /// <summary>
        /// Gets or sets the object that represents all properties related to
        /// capacity enforcement on an account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.capacity")]
        public Capacity Capacity { get; set; }

        /// <summary>
        /// Gets or sets flag to indicate whether to enable MaterializedViews
        /// on the Cosmos DB account
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableMaterializedViews")]
        public bool? EnableMaterializedViews { get; set; }

        /// <summary>
        /// Gets or sets this property is ignored during the update/create
        /// operation, as the metadata is read-only. The object represents the
        /// metadata for the Account Keys of the Cosmos DB account.
        /// </summary>
        [JsonProperty(PropertyName = "properties.keysMetadata")]
        public DatabaseAccountKeysMetadata KeysMetadata { get; set; }

        /// <summary>
        /// Gets or sets flag to indicate enabling/disabling of Partition Merge
        /// feature on the account
        /// </summary>
        [JsonProperty(PropertyName = "properties.enablePartitionMerge")]
        public bool? EnablePartitionMerge { get; set; }

        /// <summary>
        /// The offer type for the database
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseAccountOfferType")]
        public static string DatabaseAccountOfferType { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Locations == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Locations");
            }
            if (ConsistencyPolicy != null)
            {
                ConsistencyPolicy.Validate();
            }
            if (Locations != null)
            {
                foreach (var element in Locations)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (Cors != null)
            {
                foreach (var element1 in Cors)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
            if (Capacity != null)
            {
                Capacity.Validate();
            }
        }
    }
}
