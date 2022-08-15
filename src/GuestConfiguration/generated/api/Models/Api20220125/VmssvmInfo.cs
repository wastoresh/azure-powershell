// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125
{
    using static Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.Extensions;

    /// <summary>Information about VMSS VM</summary>
    public partial class VmssvmInfo :
        Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfo,
        Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfoInternal
    {

        /// <summary>Backing field for <see cref="ComplianceStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.ComplianceStatus? _complianceStatus;

        /// <summary>
        /// A value indicating compliance status of the machine for the assigned guest configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.ComplianceStatus? ComplianceStatus { get => this._complianceStatus; }

        /// <summary>Backing field for <see cref="LastComplianceChecked" /> property.</summary>
        private global::System.DateTime? _lastComplianceChecked;

        /// <summary>Date and time when last compliance status was checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? LastComplianceChecked { get => this._lastComplianceChecked; }

        /// <summary>Backing field for <see cref="LatestReportId" /> property.</summary>
        private string _latestReportId;

        /// <summary>Id of the latest report for the guest configuration assignment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.PropertyOrigin.Owned)]
        public string LatestReportId { get => this._latestReportId; }

        /// <summary>Internal Acessors for ComplianceStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.ComplianceStatus? Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfoInternal.ComplianceStatus { get => this._complianceStatus; set { {_complianceStatus = value;} } }

        /// <summary>Internal Acessors for LastComplianceChecked</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfoInternal.LastComplianceChecked { get => this._lastComplianceChecked; set { {_lastComplianceChecked = value;} } }

        /// <summary>Internal Acessors for LatestReportId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfoInternal.LatestReportId { get => this._latestReportId; set { {_latestReportId = value;} } }

        /// <summary>Internal Acessors for VMId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfoInternal.VMId { get => this._vMId; set { {_vMId = value;} } }

        /// <summary>Internal Acessors for VMResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Models.Api20220125.IVmssvmInfoInternal.VMResourceId { get => this._vMResourceId; set { {_vMResourceId = value;} } }

        /// <summary>Backing field for <see cref="VMId" /> property.</summary>
        private string _vMId;

        /// <summary>UUID of the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.PropertyOrigin.Owned)]
        public string VMId { get => this._vMId; }

        /// <summary>Backing field for <see cref="VMResourceId" /> property.</summary>
        private string _vMResourceId;

        /// <summary>Azure resource Id of the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.PropertyOrigin.Owned)]
        public string VMResourceId { get => this._vMResourceId; }

        /// <summary>Creates an new <see cref="VmssvmInfo" /> instance.</summary>
        public VmssvmInfo()
        {

        }
    }
    /// Information about VMSS VM
    public partial interface IVmssvmInfo :
        Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A value indicating compliance status of the machine for the assigned guest configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A value indicating compliance status of the machine for the assigned guest configuration.",
        SerializedName = @"complianceStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.ComplianceStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.ComplianceStatus? ComplianceStatus { get;  }
        /// <summary>Date and time when last compliance status was checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date and time when last compliance status was checked.",
        SerializedName = @"lastComplianceChecked",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastComplianceChecked { get;  }
        /// <summary>Id of the latest report for the guest configuration assignment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the latest report for the guest configuration assignment. ",
        SerializedName = @"latestReportId",
        PossibleTypes = new [] { typeof(string) })]
        string LatestReportId { get;  }
        /// <summary>UUID of the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"UUID of the VM.",
        SerializedName = @"vmId",
        PossibleTypes = new [] { typeof(string) })]
        string VMId { get;  }
        /// <summary>Azure resource Id of the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Azure resource Id of the VM.",
        SerializedName = @"vmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string VMResourceId { get;  }

    }
    /// Information about VMSS VM
    internal partial interface IVmssvmInfoInternal

    {
        /// <summary>
        /// A value indicating compliance status of the machine for the assigned guest configuration.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.GuestConfiguration.Support.ComplianceStatus? ComplianceStatus { get; set; }
        /// <summary>Date and time when last compliance status was checked.</summary>
        global::System.DateTime? LastComplianceChecked { get; set; }
        /// <summary>Id of the latest report for the guest configuration assignment.</summary>
        string LatestReportId { get; set; }
        /// <summary>UUID of the VM.</summary>
        string VMId { get; set; }
        /// <summary>Azure resource Id of the VM.</summary>
        string VMResourceId { get; set; }

    }
}