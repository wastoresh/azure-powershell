#
# Module manifest for module 'Az'
#
# Generated by: Microsoft Corporation
#
# Generated on: 4/16/2020
#

@{

# Script module or binary module file associated with this manifest.
# RootModule = ''

# Version number of this module.
ModuleVersion = '3.8.0'

# Supported PSEditions
CompatiblePSEditions = 'Core', 'Desktop'

# ID used to uniquely identify this module
GUID = 'd48d710e-85cb-46a1-990f-22dae76f6b5f'

# Author of this module
Author = 'Microsoft Corporation'

# Company or vendor of this module
CompanyName = 'Microsoft Corporation'

# Copyright statement for this module
Copyright = 'Microsoft Corporation. All rights reserved.'

# Description of the functionality provided by this module
Description = 'Microsoft Azure PowerShell - Cmdlets to manage resources in Azure. This module is compatible with WindowsPowerShell and PowerShell Core.
For more information about the Az module, please visit the following: https://docs.microsoft.com/en-us/powershell/azure/'

# Minimum version of the PowerShell engine required by this module
PowerShellVersion = '5.1'

# Name of the PowerShell host required by this module
# PowerShellHostName = ''

# Minimum version of the PowerShell host required by this module
# PowerShellHostVersion = ''

# Minimum version of Microsoft .NET Framework required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
DotNetFrameworkVersion = '4.7.2'

# Minimum version of the common language runtime (CLR) required by this module. This prerequisite is valid for the PowerShell Desktop edition only.
# CLRVersion = ''

# Processor architecture (None, X86, Amd64) required by this module
# ProcessorArchitecture = ''

# Modules that must be imported into the global environment prior to importing this module
RequiredModules = @(@{ModuleName = 'Az.Accounts'; ModuleVersion = '1.7.5'; }, 
               @{ModuleName = 'Az.Advisor'; RequiredVersion = '1.1.1'; }, 
               @{ModuleName = 'Az.Aks'; RequiredVersion = '1.0.3'; }, 
               @{ModuleName = 'Az.AnalysisServices'; RequiredVersion = '1.1.2'; }, 
               @{ModuleName = 'Az.ApiManagement'; RequiredVersion = '1.4.1'; }, 
               @{ModuleName = 'Az.ApplicationInsights'; RequiredVersion = '1.0.3'; }, 
               @{ModuleName = 'Az.Automation'; RequiredVersion = '1.3.6'; }, 
               @{ModuleName = 'Az.Batch'; RequiredVersion = '2.0.2'; }, 
               @{ModuleName = 'Az.Billing'; RequiredVersion = '1.0.2'; }, 
               @{ModuleName = 'Az.Cdn'; RequiredVersion = '1.4.3'; }, 
               @{ModuleName = 'Az.CognitiveServices'; RequiredVersion = '1.3.0'; }, 
               @{ModuleName = 'Az.Compute'; RequiredVersion = '3.7.0'; }, 
               @{ModuleName = 'Az.ContainerInstance'; RequiredVersion = '1.0.3'; }, 
               @{ModuleName = 'Az.ContainerRegistry'; RequiredVersion = '1.1.1'; }, 
               @{ModuleName = 'Az.DataBoxEdge'; RequiredVersion = '1.1.0'; }, 
               @{ModuleName = 'Az.DataFactory'; RequiredVersion = '1.7.0'; }, 
               @{ModuleName = 'Az.DataLakeAnalytics'; RequiredVersion = '1.0.2'; }, 
               @{ModuleName = 'Az.DataLakeStore'; RequiredVersion = '1.2.8'; }, 
               @{ModuleName = 'Az.DeploymentManager'; RequiredVersion = '1.1.0'; }, 
               @{ModuleName = 'Az.DevTestLabs'; RequiredVersion = '1.0.2'; }, 
               @{ModuleName = 'Az.Dns'; RequiredVersion = '1.1.2'; }, 
               @{ModuleName = 'Az.EventGrid'; RequiredVersion = '1.2.3'; }, 
               @{ModuleName = 'Az.EventHub'; RequiredVersion = '1.4.3'; }, 
               @{ModuleName = 'Az.FrontDoor'; RequiredVersion = '1.4.0'; }, 
               @{ModuleName = 'Az.HDInsight'; RequiredVersion = '3.1.0'; }, 
               @{ModuleName = 'Az.HealthcareApis'; RequiredVersion = '1.0.1'; }, 
               @{ModuleName = 'Az.IotHub'; RequiredVersion = '2.4.0'; }, 
               @{ModuleName = 'Az.KeyVault'; RequiredVersion = '1.6.0'; }, 
               @{ModuleName = 'Az.LogicApp'; RequiredVersion = '1.3.2'; }, 
               @{ModuleName = 'Az.MachineLearning'; RequiredVersion = '1.1.3'; }, 
               @{ModuleName = 'Az.Maintenance'; RequiredVersion = '1.0.0'; }, 
               @{ModuleName = 'Az.ManagedServices'; RequiredVersion = '1.0.2'; }, 
               @{ModuleName = 'Az.MarketplaceOrdering'; RequiredVersion = '1.0.2'; }, 
               @{ModuleName = 'Az.Media'; RequiredVersion = '1.1.1'; }, 
               @{ModuleName = 'Az.Monitor'; RequiredVersion = '1.7.0'; }, 
               @{ModuleName = 'Az.Network'; RequiredVersion = '2.5.0'; }, 
               @{ModuleName = 'Az.NotificationHubs'; RequiredVersion = '1.1.1'; }, 
               @{ModuleName = 'Az.OperationalInsights'; RequiredVersion = '1.3.4'; }, 
               @{ModuleName = 'Az.PolicyInsights'; RequiredVersion = '1.3.0'; }, 
               @{ModuleName = 'Az.PowerBIEmbedded'; RequiredVersion = '1.1.1'; }, 
               @{ModuleName = 'Az.PrivateDns'; RequiredVersion = '1.0.2'; }, 
               @{ModuleName = 'Az.RecoveryServices'; RequiredVersion = '2.8.0'; }, 
               @{ModuleName = 'Az.RedisCache'; RequiredVersion = '1.2.1'; }, 
               @{ModuleName = 'Az.Relay'; RequiredVersion = '1.0.3'; }, 
               @{ModuleName = 'Az.Resources'; RequiredVersion = '1.13.0'; }, 
               @{ModuleName = 'Az.ServiceBus'; RequiredVersion = '1.4.1'; }, 
               @{ModuleName = 'Az.ServiceFabric'; RequiredVersion = '2.0.2'; }, 
               @{ModuleName = 'Az.SignalR'; RequiredVersion = '1.1.1'; }, 
               @{ModuleName = 'Az.Sql'; RequiredVersion = '2.6.0'; }, 
               @{ModuleName = 'Az.SqlVirtualMachine'; RequiredVersion = '1.1.0'; }, 
#               @{ModuleName = 'Az.Storage'; RequiredVersion = '1.14.0'; },  # Storage removed to support preview
               @{ModuleName = 'Az.StorageSync'; RequiredVersion = '1.2.3'; }, 
               @{ModuleName = 'Az.StreamAnalytics'; RequiredVersion = '1.0.1'; }, 
               @{ModuleName = 'Az.Support'; RequiredVersion = '1.0.0'; }, 
               @{ModuleName = 'Az.TrafficManager'; RequiredVersion = '1.0.3'; }, 
               @{ModuleName = 'Az.Websites'; RequiredVersion = '1.8.0'; })

# Assemblies that must be loaded prior to importing this module
# RequiredAssemblies = @()

# Script files (.ps1) that are run in the caller's environment prior to importing this module.
# ScriptsToProcess = @()

# Type files (.ps1xml) to be loaded when importing this module
# TypesToProcess = @()

# Format files (.ps1xml) to be loaded when importing this module
# FormatsToProcess = @()

# Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
# NestedModules = @()

# Functions to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no functions to export.
FunctionsToExport = @()

# Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no cmdlets to export.
CmdletsToExport = @()

# Variables to export from this module
# VariablesToExport = @()

# Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry, use an empty array if there are no aliases to export.
AliasesToExport = @()

# DSC resources to export from this module
# DscResourcesToExport = @()

# List of all modules packaged with this module
# ModuleList = @()

# List of all files packaged with this module
# FileList = @()

# Private data to pass to the module specified in RootModule/ModuleToProcess. This may also contain a PSData hashtable with additional module metadata used by PowerShell.
PrivateData = @{

    PSData = @{

        # Tags applied to this module. These help with module discovery in online galleries.
        Tags = 'Azure','ARM','ResourceManager','Linux','AzureAutomationNotSupported'

        # A URL to the license for this module.
        LicenseUri = 'https://aka.ms/azps-license'

        # A URL to the main website for this project.
        ProjectUri = 'https://github.com/Azure/azure-powershell'

        # A URL to an icon representing this module.
        # IconUri = ''

        # ReleaseNotes of this module
        ReleaseNotes = '3.8.0 - April 2020
Az.Accounts
* Updated Azure PowerShell survey URL in ''Resolve-AzError'' [#11507]

Az.ApiManagement
* Added breaking change notice for Azure File cmdlets output change in a future release
* ''Set-AzApiManagementGroup'' Updated documentation to specify the GroupId parameter

Az.Cdn
* Fixed ChinaCDN related pricing SKU display

Az.CognitiveServices
* Supported Identity, Encryption, UserOwnedStorage 

Az.Compute
* Added ''Set-AzVmssOrchestrationServiceState'' cmdlet.
* ''Get-AzVmss'' with -InstanceView shows OrchestrationService states.

Az.IotHub
* Manage IoT device twin configuration, New cmdlets are:
    - ''Get-AzIotHubDeviceTwin''
    - ''Update-AzIotHubDeviceTwin''
* Added cmdlet to invoke direct method on a device in an Iot Hub.
* Manage IoT device module twin configuration, New cmdlets are:
    - ''Get-AzIotHubModuleTwin''
    - ''Update-AzIotHubModuleTwin''
* Manage IoT automatic device management configuration at scale. New cmdlets are:
    - ''Add-AzIotHubConfiguration''
    - ''Get-AzIotHubConfiguration''
    - ''Remove-AzIotHubConfiguration''
    - ''Set-AzIotHubConfiguration''
* Added cmdlet to invoke an edge module method in an Iot Hub.

Az.KeyVault
* Added a new cmdlet ''Update-AzKeyVault'' that can enable soft delete and purge protection on a vault
* Added support to Microsoft.PowerShell.SecretManagement [#11178]
* Fixed error in the examples of ''Remove-AzKeyVaultManagedStorageSasDefinition'' [#11479]
* Added support to private endpoint

Az.Maintenance
* Publishing release version of Maintenance cmdlets for GA

Az.Monitor
* Added cmdlets for private link scope
    - ''Get-AzInsightsPrivateLinkScope''
    - ''Remove-AzInsightsPrivateLinkScope''
    - ''New-AzInsightsPrivateLinkScope''
    - ''Update-AzInsightsPrivateLinkScope''
    - ''Get-AzInsightsPrivateLinkScopedResource''
    - ''New-AzInsightsPrivateLinkScopedResource''
    - ''Remove-AzInsightsPrivateLinkScopedResource''

Az.Network
* Updated cmdlets to enable connection on private IP for Virtual Network Gateway.
    - ''New-AzVirtualNetworkGateway''
    - ''Set-AzVirtualNetworkGateway''
    - ''New-AzVirtualNetworkGatewayConnection''
    - ''Set-AzVirtualNetworkGatewayConnection''
* Updated cmdlets to enable FQDN based LocalNetworkGateways and VpnSites
    - ''New-AzLocalNetworkGateway''
    - ''New-AzVpnSiteLink''
* Added support for IPv6 address family in ExpressRouteCircuitConnectionConfig (Global Reach)
    - Added ''Set-AzExpressRouteCircuitConnectionConfig''
        - allows setting of all the existing properties including the IPv6CircuitConnectionProperties
    - Updated ''Add-AzExpressRouteCircuitConnectionConfig''
        - Added another optional parameter AddressPrefixType to specify the address family of address prefix
* Updated cmdlets to enable setting of DPD Timeout on Virtual Network Gateway Connections.
    - New-AzVirtualNetworkGatewayConnection
    - Set-AzVirtualNetworkGatewayConnection

Az.PolicyInsights
* Added ''Start-AzPolicyComplianceScan'' cmdlet for triggering policy compliance scans
* Added policy definition, set definition, and assignment versions to ''Get-AzPolicyState'' output

Az.ServiceFabric
* Improved code formatting and usability of ''New-AzServiceFabricCluster'' examples

Az.Sql
* Added cmdlets ''Get-AzSqlInstanceOperation'' and ''Stop-AzSqlInstanceOperation''
* Supported auditing to a storage account in VNet.

Az.Storage
* Added breaking change notice for Azure File cmdlets output change in a future release
* Supported new SkuName StandardGZRS, StandardRAGZRS when create/update Storage account
    - ''New-AzStorageAccount''
    - ''Set-AzStorageAccount''
* Supported DataLake Gen2 
    - ''New-AzDataLakeGen2Item''
    - ''Get-AzDataLakeGen2Item''
    - ''Get-AzDataLakeGen2ChildItem''
    - ''Move-AzDataLakeGen2Item''
    - ''Set-AzDataLakeGen2ItemAclObject''
    - ''Update-AzDataLakeGen2Item''
    - ''Get-AzDataLakeGen2ItemContent''
    - ''Remove-AzDataLakeGen2Item''
'

        # Prerelease string of this module
        # Prerelease = ''

        # Flag to indicate whether the module requires explicit user acceptance for install/update/save
        # RequireLicenseAcceptance = $false

        # External dependent modules of this module
        # ExternalModuleDependencies = @()

    } # End of PSData hashtable

 } # End of PrivateData hashtable

# HelpInfo URI of this module
# HelpInfoURI = ''

# Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
# DefaultCommandPrefix = ''

}

