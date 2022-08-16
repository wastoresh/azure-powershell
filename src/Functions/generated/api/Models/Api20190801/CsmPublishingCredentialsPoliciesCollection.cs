// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Publishing Credentials Policies collection.</summary>
    public partial class CsmPublishingCredentialsPoliciesCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FtpId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpId; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FtpKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpKind = value ?? null; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FtpName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpName; }

        /// <summary>
        /// <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? FtpPropertiesAllow { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpPropertiesAllow; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpPropertiesAllow = value ?? default(bool); }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FtpType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpType; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value ?? null; }

        /// <summary>Internal Acessors for Ftp</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.Ftp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).Ftp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).Ftp = value; }

        /// <summary>Internal Acessors for FtpId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.FtpId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpId = value; }

        /// <summary>Internal Acessors for FtpName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.FtpName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpName = value; }

        /// <summary>Internal Acessors for FtpProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntityProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.FtpProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpProperty = value; }

        /// <summary>Internal Acessors for FtpType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.FtpType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).FtpType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmPublishingCredentialsPoliciesCollectionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Scm</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.Scm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).Scm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).Scm = value; }

        /// <summary>Internal Acessors for ScmId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.ScmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmId = value; }

        /// <summary>Internal Acessors for ScmName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.ScmName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmName = value; }

        /// <summary>Internal Acessors for ScmProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntityProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.ScmProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmProperty = value; }

        /// <summary>Internal Acessors for ScmType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionInternal.ScmType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionProperties _property;

        /// <summary>CsmPublishingCredentialsPoliciesCollection resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CsmPublishingCredentialsPoliciesCollectionProperties()); set => this._property = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ScmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmId; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ScmKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmKind = value ?? null; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ScmName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmName; }

        /// <summary>
        /// <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ScmPropertiesAllow { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmPropertiesAllow; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmPropertiesAllow = value ?? default(bool); }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ScmType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionPropertiesInternal)Property).ScmType; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>
        /// Creates an new <see cref="CsmPublishingCredentialsPoliciesCollection" /> instance.
        /// </summary>
        public CsmPublishingCredentialsPoliciesCollection()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Publishing Credentials Policies collection.
    public partial interface ICsmPublishingCredentialsPoliciesCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
    {
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string FtpId { get;  }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string FtpKind { get; set; }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string FtpName { get;  }
        /// <summary>
        /// <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.",
        SerializedName = @"allow",
        PossibleTypes = new [] { typeof(bool) })]
        bool? FtpPropertiesAllow { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string FtpType { get;  }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ScmId { get;  }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string ScmKind { get; set; }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string ScmName { get;  }
        /// <summary>
        /// <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.",
        SerializedName = @"allow",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ScmPropertiesAllow { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string ScmType { get;  }

    }
    /// Publishing Credentials Policies collection.
    internal partial interface ICsmPublishingCredentialsPoliciesCollectionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Whether FTP is allowed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity Ftp { get; set; }
        /// <summary>Resource Id.</summary>
        string FtpId { get; set; }
        /// <summary>Kind of resource.</summary>
        string FtpKind { get; set; }
        /// <summary>Resource Name.</summary>
        string FtpName { get; set; }
        /// <summary>
        /// <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.
        /// </summary>
        bool? FtpPropertiesAllow { get; set; }
        /// <summary>CsmPublishingCredentialsPoliciesEntity resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntityProperties FtpProperty { get; set; }
        /// <summary>Resource type.</summary>
        string FtpType { get; set; }
        /// <summary>CsmPublishingCredentialsPoliciesCollection resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesCollectionProperties Property { get; set; }
        /// <summary>Whether Scm Basic Auth is allowed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntity Scm { get; set; }
        /// <summary>Resource Id.</summary>
        string ScmId { get; set; }
        /// <summary>Kind of resource.</summary>
        string ScmKind { get; set; }
        /// <summary>Resource Name.</summary>
        string ScmName { get; set; }
        /// <summary>
        /// <code>true</code> to allow access to a publishing method; otherwise, <code>false</code>.
        /// </summary>
        bool? ScmPropertiesAllow { get; set; }
        /// <summary>CsmPublishingCredentialsPoliciesEntity resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmPublishingCredentialsPoliciesEntityProperties ScmProperty { get; set; }
        /// <summary>Resource type.</summary>
        string ScmType { get; set; }

    }
}