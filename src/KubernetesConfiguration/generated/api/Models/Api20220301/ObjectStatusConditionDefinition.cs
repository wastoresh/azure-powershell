// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Status condition of Kubernetes object</summary>
    public partial class ObjectStatusConditionDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IObjectStatusConditionDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IObjectStatusConditionDefinitionInternal
    {

        /// <summary>Backing field for <see cref="LastTransitionTime" /> property.</summary>
        private global::System.DateTime? _lastTransitionTime;

        /// <summary>Last time this status condition has changed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? LastTransitionTime { get => this._lastTransitionTime; set => this._lastTransitionTime = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>A more verbose description of the object status condition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private string _reason;

        /// <summary>Reason for the specified status condition type status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Reason { get => this._reason; set => this._reason = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the Kubernetes object condition type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Object status condition type for this object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ObjectStatusConditionDefinition" /> instance.</summary>
        public ObjectStatusConditionDefinition()
        {

        }
    }
    /// Status condition of Kubernetes object
    public partial interface IObjectStatusConditionDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>Last time this status condition has changed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last time this status condition has changed",
        SerializedName = @"lastTransitionTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastTransitionTime { get; set; }
        /// <summary>A more verbose description of the object status condition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A more verbose description of the object status condition",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Reason for the specified status condition type status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Reason for the specified status condition type status",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string Reason { get; set; }
        /// <summary>Status of the Kubernetes object condition type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of the Kubernetes object condition type",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get; set; }
        /// <summary>Object status condition type for this object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Object status condition type for this object",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Status condition of Kubernetes object
    internal partial interface IObjectStatusConditionDefinitionInternal

    {
        /// <summary>Last time this status condition has changed</summary>
        global::System.DateTime? LastTransitionTime { get; set; }
        /// <summary>A more verbose description of the object status condition</summary>
        string Message { get; set; }
        /// <summary>Reason for the specified status condition type status</summary>
        string Reason { get; set; }
        /// <summary>Status of the Kubernetes object condition type</summary>
        string Status { get; set; }
        /// <summary>Object status condition type for this object</summary>
        string Type { get; set; }

    }
}