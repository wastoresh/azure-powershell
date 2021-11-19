// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Extensions;

    /// <summary>Describes the properties of a gallery image version.</summary>
    public partial class GalleryImageVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal
    {

        /// <summary>
        /// The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).Id = value ?? null; }

        /// <summary>Internal Acessors for OSDiskImageSizeInGb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.OSDiskImageSizeInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSizeInGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSizeInGb = value; }

        /// <summary>Internal Acessors for OSDiskImageSource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactVersionSource Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.OSDiskImageSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSource = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for PublishingProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBase Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.PublishingProfile { get => (this._publishingProfile = this._publishingProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryArtifactPublishingProfileBase()); set { {_publishingProfile = value;} } }

        /// <summary>Internal Acessors for PublishingProfilePublishedDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.PublishingProfilePublishedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).PublishedDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).PublishedDate = value; }

        /// <summary>Internal Acessors for ReplicationStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatus Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.ReplicationStatus { get => (this._replicationStatus = this._replicationStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ReplicationStatus()); set { {_replicationStatus = value;} } }

        /// <summary>Internal Acessors for ReplicationStatusAggregatedState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState? Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.ReplicationStatusAggregatedState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatusInternal)ReplicationStatus).AggregatedState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatusInternal)ReplicationStatus).AggregatedState = value; }

        /// <summary>Internal Acessors for ReplicationStatusSummary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IRegionalReplicationStatus[] Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.ReplicationStatusSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatusInternal)ReplicationStatus).Summary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatusInternal)ReplicationStatus).Summary = value; }

        /// <summary>Internal Acessors for StorageProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfile Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryImageVersionStorageProfile()); set { {_storageProfile = value;} } }

        /// <summary>Internal Acessors for StorageProfileOSDiskImage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryDiskImage Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.StorageProfileOSDiskImage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImage = value; }

        /// <summary>Internal Acessors for StorageProfileSource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactVersionSource Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionPropertiesInternal.StorageProfileSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).Source = value; }

        /// <summary>
        /// The host caching of the disk. Valid values are 'None', 'ReadOnly', and 'ReadWrite'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.HostCaching? OSDiskImageHostCaching { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageHostCaching; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageHostCaching = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.HostCaching)""); }

        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public int? OSDiskImageSizeInGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSizeInGb; }

        /// <summary>
        /// The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public string OSDiskImageSourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSourceId = value ?? null; }

        /// <summary>
        /// The uri of the gallery artifact version source. Currently used to specify vhd/blob source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public string OSDiskImageSourceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSourceUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).OSDiskImageSourceUri = value ?? null; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublishingProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBase _publishingProfile;

        /// <summary>Describes the basic gallery artifact publishing profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBase PublishingProfile { get => (this._publishingProfile = this._publishingProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryArtifactPublishingProfileBase()); set => this._publishingProfile = value; }

        /// <summary>
        /// The end of life date of the gallery image version. This property can be used for decommissioning purposes. This property
        /// is updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public global::System.DateTime? PublishingProfileEndOfLifeDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).EndOfLifeDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).EndOfLifeDate = value ?? default(global::System.DateTime); }

        /// <summary>
        /// If set to true, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public bool? PublishingProfileExcludeFromLatest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).ExcludeFromLatest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).ExcludeFromLatest = value ?? default(bool); }

        /// <summary>The timestamp for when the gallery image version is published.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public global::System.DateTime? PublishingProfilePublishedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).PublishedDate; }

        /// <summary>
        /// The number of replicas of the Image Version to be created per region. This property would take effect for a region when
        /// regionalReplicaCount is not specified. This property is updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public int? PublishingProfileReplicaCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).ReplicaCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).ReplicaCount = value ?? default(int); }

        /// <summary>
        /// Optional parameter which specifies the mode to be used for replication. This property is not updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ReplicationMode? PublishingProfileReplicationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).ReplicationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).ReplicationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ReplicationMode)""); }

        /// <summary>
        /// Specifies the storage account type to be used to store the image. This property is not updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType? PublishingProfileStorageAccountType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).StorageAccountType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).StorageAccountType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType)""); }

        /// <summary>
        /// The target regions where the Image Version is going to be replicated to. This property is updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ITargetRegion[] PublishingProfileTargetRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).TargetRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBaseInternal)PublishingProfile).TargetRegion = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="ReplicationStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatus _replicationStatus;

        /// <summary>This is the replication status of the gallery image version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatus ReplicationStatus { get => (this._replicationStatus = this._replicationStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ReplicationStatus()); }

        /// <summary>
        /// This is the aggregated replication status based on all the regional replication status flags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState? ReplicationStatusAggregatedState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatusInternal)ReplicationStatus).AggregatedState; }

        /// <summary>This is a summary of replication status for each region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IRegionalReplicationStatus[] ReplicationStatusSummary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatusInternal)ReplicationStatus).Summary; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfile _storageProfile;

        /// <summary>This is the storage profile of a Gallery Image Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfile StorageProfile { get => (this._storageProfile = this._storageProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryImageVersionStorageProfile()); set => this._storageProfile = value; }

        /// <summary>A list of data disk images.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryDataDiskImage[] StorageProfileDataDiskImage { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).DataDiskImage; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).DataDiskImage = value ?? null /* arrayOf */; }

        /// <summary>
        /// The uri of the gallery artifact version source. Currently used to specify vhd/blob source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Origin(Microsoft.Azure.PowerShell.Cmdlets.Compute.PropertyOrigin.Inlined)]
        public string Uri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).Uri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfileInternal)StorageProfile).Uri = value ?? null; }

        /// <summary>Creates an new <see cref="GalleryImageVersionProperties" /> instance.</summary>
        public GalleryImageVersionProperties()
        {

        }
    }
    /// Describes the properties of a gallery image version.
    public partial interface IGalleryImageVersionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>
        /// The host caching of the disk. Valid values are 'None', 'ReadOnly', and 'ReadWrite'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The host caching of the disk. Valid values are 'None', 'ReadOnly', and 'ReadWrite'",
        SerializedName = @"hostCaching",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.HostCaching) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.HostCaching? OSDiskImageHostCaching { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This property indicates the size of the VHD to be created.",
        SerializedName = @"sizeInGB",
        PossibleTypes = new [] { typeof(int) })]
        int? OSDiskImageSizeInGb { get;  }
        /// <summary>
        /// The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string OSDiskImageSourceId { get; set; }
        /// <summary>
        /// The uri of the gallery artifact version source. Currently used to specify vhd/blob source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uri of the gallery artifact version source. Currently used to specify vhd/blob source.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string OSDiskImageSourceUri { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// The end of life date of the gallery image version. This property can be used for decommissioning purposes. This property
        /// is updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The end of life date of the gallery image version. This property can be used for decommissioning purposes. This property is updatable.",
        SerializedName = @"endOfLifeDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PublishingProfileEndOfLifeDate { get; set; }
        /// <summary>
        /// If set to true, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If set to true, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.",
        SerializedName = @"excludeFromLatest",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PublishingProfileExcludeFromLatest { get; set; }
        /// <summary>The timestamp for when the gallery image version is published.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The timestamp for when the gallery image version is published.",
        SerializedName = @"publishedDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PublishingProfilePublishedDate { get;  }
        /// <summary>
        /// The number of replicas of the Image Version to be created per region. This property would take effect for a region when
        /// regionalReplicaCount is not specified. This property is updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of replicas of the Image Version to be created per region. This property would take effect for a region when regionalReplicaCount is not specified. This property is updatable.",
        SerializedName = @"replicaCount",
        PossibleTypes = new [] { typeof(int) })]
        int? PublishingProfileReplicaCount { get; set; }
        /// <summary>
        /// Optional parameter which specifies the mode to be used for replication. This property is not updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional parameter which specifies the mode to be used for replication. This property is not updatable.",
        SerializedName = @"replicationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ReplicationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ReplicationMode? PublishingProfileReplicationMode { get; set; }
        /// <summary>
        /// Specifies the storage account type to be used to store the image. This property is not updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the storage account type to be used to store the image. This property is not updatable.",
        SerializedName = @"storageAccountType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType? PublishingProfileStorageAccountType { get; set; }
        /// <summary>
        /// The target regions where the Image Version is going to be replicated to. This property is updatable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target regions where the Image Version is going to be replicated to. This property is updatable.",
        SerializedName = @"targetRegions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ITargetRegion) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ITargetRegion[] PublishingProfileTargetRegion { get; set; }
        /// <summary>
        /// This is the aggregated replication status based on all the regional replication status flags.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This is the aggregated replication status based on all the regional replication status flags.",
        SerializedName = @"aggregatedState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState? ReplicationStatusAggregatedState { get;  }
        /// <summary>This is a summary of replication status for each region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"This is a summary of replication status for each region.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IRegionalReplicationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IRegionalReplicationStatus[] ReplicationStatusSummary { get;  }
        /// <summary>A list of data disk images.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of data disk images.",
        SerializedName = @"dataDiskImages",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryDataDiskImage) })]
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryDataDiskImage[] StorageProfileDataDiskImage { get; set; }
        /// <summary>
        /// The uri of the gallery artifact version source. Currently used to specify vhd/blob source.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uri of the gallery artifact version source. Currently used to specify vhd/blob source.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get; set; }

    }
    /// Describes the properties of a gallery image version.
    internal partial interface IGalleryImageVersionPropertiesInternal

    {
        /// <summary>
        /// The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.
        /// </summary>
        string Id { get; set; }
        /// <summary>
        /// The host caching of the disk. Valid values are 'None', 'ReadOnly', and 'ReadWrite'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.HostCaching? OSDiskImageHostCaching { get; set; }
        /// <summary>This property indicates the size of the VHD to be created.</summary>
        int? OSDiskImageSizeInGb { get; set; }
        /// <summary>The gallery artifact version source.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactVersionSource OSDiskImageSource { get; set; }
        /// <summary>
        /// The id of the gallery artifact version source. Can specify a disk uri, snapshot uri, user image or storage account resource.
        /// </summary>
        string OSDiskImageSourceId { get; set; }
        /// <summary>
        /// The uri of the gallery artifact version source. Currently used to specify vhd/blob source.
        /// </summary>
        string OSDiskImageSourceUri { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        string ProvisioningState { get; set; }
        /// <summary>Describes the basic gallery artifact publishing profile.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactPublishingProfileBase PublishingProfile { get; set; }
        /// <summary>
        /// The end of life date of the gallery image version. This property can be used for decommissioning purposes. This property
        /// is updatable.
        /// </summary>
        global::System.DateTime? PublishingProfileEndOfLifeDate { get; set; }
        /// <summary>
        /// If set to true, Virtual Machines deployed from the latest version of the Image Definition won't use this Image Version.
        /// </summary>
        bool? PublishingProfileExcludeFromLatest { get; set; }
        /// <summary>The timestamp for when the gallery image version is published.</summary>
        global::System.DateTime? PublishingProfilePublishedDate { get; set; }
        /// <summary>
        /// The number of replicas of the Image Version to be created per region. This property would take effect for a region when
        /// regionalReplicaCount is not specified. This property is updatable.
        /// </summary>
        int? PublishingProfileReplicaCount { get; set; }
        /// <summary>
        /// Optional parameter which specifies the mode to be used for replication. This property is not updatable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ReplicationMode? PublishingProfileReplicationMode { get; set; }
        /// <summary>
        /// Specifies the storage account type to be used to store the image. This property is not updatable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType? PublishingProfileStorageAccountType { get; set; }
        /// <summary>
        /// The target regions where the Image Version is going to be replicated to. This property is updatable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.ITargetRegion[] PublishingProfileTargetRegion { get; set; }
        /// <summary>This is the replication status of the gallery image version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IReplicationStatus ReplicationStatus { get; set; }
        /// <summary>
        /// This is the aggregated replication status based on all the regional replication status flags.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.AggregatedReplicationState? ReplicationStatusAggregatedState { get; set; }
        /// <summary>This is a summary of replication status for each region.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IRegionalReplicationStatus[] ReplicationStatusSummary { get; set; }
        /// <summary>This is the storage profile of a Gallery Image Version.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImageVersionStorageProfile StorageProfile { get; set; }
        /// <summary>A list of data disk images.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryDataDiskImage[] StorageProfileDataDiskImage { get; set; }
        /// <summary>This is the disk image base class.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryDiskImage StorageProfileOSDiskImage { get; set; }
        /// <summary>The gallery artifact version source.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryArtifactVersionSource StorageProfileSource { get; set; }
        /// <summary>
        /// The uri of the gallery artifact version source. Currently used to specify vhd/blob source.
        /// </summary>
        string Uri { get; set; }

    }
}