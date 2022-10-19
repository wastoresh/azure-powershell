// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Extensions;

    /// <summary>Represents bookmark timeline item.</summary>
    public partial class BookmarkTimelineItem
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject into a new instance of <see cref="BookmarkTimelineItem" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal BookmarkTimelineItem(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __entityTimelineItem = new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.EntityTimelineItem(json);
            {_createdBy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject>("createdBy"), out var __jsonCreatedBy) ? Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20.UserInfo.FromJson(__jsonCreatedBy) : CreatedBy;}
            {_azureResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString>("azureResourceId"), out var __jsonAzureResourceId) ? (string)__jsonAzureResourceId : (string)AzureResourceId;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)DisplayName;}
            {_note = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString>("notes"), out var __jsonNotes) ? (string)__jsonNotes : (string)Note;}
            {_endTimeUtc = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString>("endTimeUtc"), out var __jsonEndTimeUtc) ? global::System.DateTime.TryParse((string)__jsonEndTimeUtc, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEndTimeUtcValue) ? __jsonEndTimeUtcValue : EndTimeUtc : EndTimeUtc;}
            {_startTimeUtc = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString>("startTimeUtc"), out var __jsonStartTimeUtc) ? global::System.DateTime.TryParse((string)__jsonStartTimeUtc, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartTimeUtcValue) ? __jsonStartTimeUtcValue : StartTimeUtc : StartTimeUtc;}
            {_eventTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString>("eventTime"), out var __jsonEventTime) ? global::System.DateTime.TryParse((string)__jsonEventTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEventTimeValue) ? __jsonEventTimeValue : EventTime : EventTime;}
            {_label = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonArray>("labels"), out var __jsonLabels) ? If( __jsonLabels as Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : Label;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IBookmarkTimelineItem.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IBookmarkTimelineItem.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IBookmarkTimelineItem FromJson(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject json ? new BookmarkTimelineItem(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="BookmarkTimelineItem" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="BookmarkTimelineItem" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __entityTimelineItem?.ToJson(container, serializationMode);
            AddIf( null != this._createdBy ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) this._createdBy.ToJson(null,serializationMode) : null, "createdBy" ,container.Add );
            AddIf( null != (((object)this._azureResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(this._azureResourceId.ToString()) : null, "azureResourceId" ,container.Add );
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._note)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(this._note.ToString()) : null, "notes" ,container.Add );
            AddIf( null != this._endTimeUtc ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(this._endTimeUtc?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "endTimeUtc" ,container.Add );
            AddIf( null != this._startTimeUtc ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(this._startTimeUtc?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startTimeUtc" ,container.Add );
            AddIf( null != this._eventTime ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(this._eventTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "eventTime" ,container.Add );
            if (null != this._label)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.XNodeArray();
                foreach( var __x in this._label )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("labels",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}