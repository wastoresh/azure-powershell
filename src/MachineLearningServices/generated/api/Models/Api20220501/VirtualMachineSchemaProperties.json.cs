// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Extensions;

    public partial class VirtualMachineSchemaProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IVirtualMachineSchemaProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IVirtualMachineSchemaProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IVirtualMachineSchemaProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject json ? new VirtualMachineSchemaProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VirtualMachineSchemaProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VirtualMachineSchemaProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._administratorAccount ? (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode) this._administratorAccount.ToJson(null,serializationMode) : null, "administratorAccount" ,container.Add );
            AddIf( null != (((object)this._virtualMachineSize)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonString(this._virtualMachineSize.ToString()) : null, "virtualMachineSize" ,container.Add );
            AddIf( null != this._sshPort ? (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNumber((int)this._sshPort) : null, "sshPort" ,container.Add );
            AddIf( null != this._notebookServerPort ? (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNumber((int)this._notebookServerPort) : null, "notebookServerPort" ,container.Add );
            AddIf( null != (((object)this._address)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonString(this._address.ToString()) : null, "address" ,container.Add );
            AddIf( null != this._isNotebookInstanceCompute ? (Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonBoolean((bool)this._isNotebookInstanceCompute) : null, "isNotebookInstanceCompute" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject into a new instance of <see cref="VirtualMachineSchemaProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VirtualMachineSchemaProperties(Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_administratorAccount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonObject>("administratorAccount"), out var __jsonAdministratorAccount) ? Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.VirtualMachineSshCredentials.FromJson(__jsonAdministratorAccount) : AdministratorAccount;}
            {_virtualMachineSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonString>("virtualMachineSize"), out var __jsonVirtualMachineSize) ? (string)__jsonVirtualMachineSize : (string)VirtualMachineSize;}
            {_sshPort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNumber>("sshPort"), out var __jsonSshPort) ? (int?)__jsonSshPort : SshPort;}
            {_notebookServerPort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonNumber>("notebookServerPort"), out var __jsonNotebookServerPort) ? (int?)__jsonNotebookServerPort : NotebookServerPort;}
            {_address = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonString>("address"), out var __jsonAddress) ? (string)__jsonAddress : (string)Address;}
            {_isNotebookInstanceCompute = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Runtime.Json.JsonBoolean>("isNotebookInstanceCompute"), out var __jsonIsNotebookInstanceCompute) ? (bool?)__jsonIsNotebookInstanceCompute : IsNotebookInstanceCompute;}
            AfterFromJson(json);
        }
    }
}