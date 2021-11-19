// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Extensions;

    /// <summary>
    /// Specifies information about the gallery image definition that you want to create or update.
    /// </summary>
    public partial class GalleryImage
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImage.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImage.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.IGalleryImage FromJson(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject json ? new GalleryImage(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject into a new instance of <see cref="GalleryImage" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal GalleryImage(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __resource = new Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.Resource(json);
            {_property = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject>("properties"), out var __jsonProperties) ? Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20210701.GalleryImageProperties.FromJson(__jsonProperties) : Property;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="GalleryImage" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="GalleryImage" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __resource?.ToJson(container, serializationMode);
            AddIf( null != this._property ? (Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode) this._property.ToJson(null,serializationMode) : null, "properties" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}