// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Extensions;

    /// <summary>Describes activity entity query properties</summary>
    public partial class ActivityEntityQueryTemplateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private string _content;

        /// <summary>The entity query content to display in timeline</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string Content { get => this._content; set => this._content = value; }

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IDataTypeDefinitions[] _dataType;

        /// <summary>List of required data types for the given entity query template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IDataTypeDefinitions[] DataType { get => this._dataType; set => this._dataType = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The entity query description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="EntitiesFilter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesEntitiesFilter _entitiesFilter;

        /// <summary>The query applied only to entities matching to all filters</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesEntitiesFilter EntitiesFilter { get => (this._entitiesFilter = this._entitiesFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ActivityEntityQueryTemplatePropertiesEntitiesFilter()); set => this._entitiesFilter = value; }

        /// <summary>Backing field for <see cref="InputEntityType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType? _inputEntityType;

        /// <summary>The type of the query's source entity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType? InputEntityType { get => this._inputEntityType; set => this._inputEntityType = value; }

        /// <summary>Internal Acessors for QueryDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitions Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesInternal.QueryDefinition { get => (this._queryDefinition = this._queryDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ActivityEntityQueryTemplatePropertiesQueryDefinitions()); set { {_queryDefinition = value;} } }

        /// <summary>Backing field for <see cref="QueryDefinition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitions _queryDefinition;

        /// <summary>The Activity query definitions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitions QueryDefinition { get => (this._queryDefinition = this._queryDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ActivityEntityQueryTemplatePropertiesQueryDefinitions()); set => this._queryDefinition = value; }

        /// <summary>The Activity query to run on a given entity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string QueryDefinitionQuery { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitionsInternal)QueryDefinition).Query; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitionsInternal)QueryDefinition).Query = value ?? null; }

        /// <summary>
        /// The dimensions we want to summarize the timeline results on, this is comma separated list
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Inlined)]
        public string QueryDefinitionSummarizeBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitionsInternal)QueryDefinition).SummarizeBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitionsInternal)QueryDefinition).SummarizeBy = value ?? null; }

        /// <summary>Backing field for <see cref="RequiredInputFieldsSet" /> property.</summary>
        private string[][] _requiredInputFieldsSet;

        /// <summary>List of the fields of the source entity that are required to run the query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string[][] RequiredInputFieldsSet { get => this._requiredInputFieldsSet; set => this._requiredInputFieldsSet = value; }

        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        /// <summary>The entity query title</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public string Title { get => this._title; set => this._title = value; }

        /// <summary>Creates an new <see cref="ActivityEntityQueryTemplateProperties" /> instance.</summary>
        public ActivityEntityQueryTemplateProperties()
        {

        }
    }
    /// Describes activity entity query properties
    public partial interface IActivityEntityQueryTemplateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IJsonSerializable
    {
        /// <summary>The entity query content to display in timeline</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The entity query content to display in timeline",
        SerializedName = @"content",
        PossibleTypes = new [] { typeof(string) })]
        string Content { get; set; }
        /// <summary>List of required data types for the given entity query template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of required data types for the given entity query template",
        SerializedName = @"dataTypes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IDataTypeDefinitions) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IDataTypeDefinitions[] DataType { get; set; }
        /// <summary>The entity query description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The entity query description",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The query applied only to entities matching to all filters</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The query applied only to entities matching to all filters",
        SerializedName = @"entitiesFilter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesEntitiesFilter) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesEntitiesFilter EntitiesFilter { get; set; }
        /// <summary>The type of the query's source entity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the query's source entity",
        SerializedName = @"inputEntityType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType? InputEntityType { get; set; }
        /// <summary>The Activity query to run on a given entity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Activity query to run on a given entity",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string QueryDefinitionQuery { get; set; }
        /// <summary>
        /// The dimensions we want to summarize the timeline results on, this is comma separated list
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The dimensions we want to summarize the timeline results on, this is comma separated list",
        SerializedName = @"summarizeBy",
        PossibleTypes = new [] { typeof(string) })]
        string QueryDefinitionSummarizeBy { get; set; }
        /// <summary>List of the fields of the source entity that are required to run the query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of the fields of the source entity that are required to run the query",
        SerializedName = @"requiredInputFieldsSets",
        PossibleTypes = new [] { typeof(string) })]
        string[][] RequiredInputFieldsSet { get; set; }
        /// <summary>The entity query title</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The entity query title",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string Title { get; set; }

    }
    /// Describes activity entity query properties
    internal partial interface IActivityEntityQueryTemplatePropertiesInternal

    {
        /// <summary>The entity query content to display in timeline</summary>
        string Content { get; set; }
        /// <summary>List of required data types for the given entity query template</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IDataTypeDefinitions[] DataType { get; set; }
        /// <summary>The entity query description</summary>
        string Description { get; set; }
        /// <summary>The query applied only to entities matching to all filters</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesEntitiesFilter EntitiesFilter { get; set; }
        /// <summary>The type of the query's source entity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType? InputEntityType { get; set; }
        /// <summary>The Activity query definitions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IActivityEntityQueryTemplatePropertiesQueryDefinitions QueryDefinition { get; set; }
        /// <summary>The Activity query to run on a given entity</summary>
        string QueryDefinitionQuery { get; set; }
        /// <summary>
        /// The dimensions we want to summarize the timeline results on, this is comma separated list
        /// </summary>
        string QueryDefinitionSummarizeBy { get; set; }
        /// <summary>List of the fields of the source entity that are required to run the query</summary>
        string[][] RequiredInputFieldsSet { get; set; }
        /// <summary>The entity query title</summary>
        string Title { get; set; }

    }
}