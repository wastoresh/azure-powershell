
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name).
.Description
Accept or reject terms for a given publisher id(Publisher), offer id(Product) and plan id(Name).
.Example
Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Accept
.Example
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' | Set-AzMarketplaceTerms -Accept
.Example
Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Reject
.Example
Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' | Set-AzMarketplaceTerms -Reject

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

TERMS <IAgreementTerms>: Terms properties for provided Publisher/Offer/Plan tuple To construct, see NOTES section for PARAMETER properties and create a hash table.
  [Accepted <Boolean?>]: If any version of the terms have been accepted, otherwise false.
  [LicenseTextLink <String>]: Link to HTML with Microsoft and Publisher terms.
  [MarketplaceTermsLink <String>]: Link to HTML with Azure Marketplace terms.
  [Plan <String>]: Plan identifier string of image being deployed.
  [PrivacyPolicyLink <String>]: Link to the privacy policy of the publisher.
  [Product <String>]: Offer identifier string of image being deployed.
  [Publisher <String>]: Publisher identifier string of image being deployed.
  [RetrieveDatetime <DateTime?>]: Date and time in UTC of when the terms were accepted. This is empty if Accepted is false.
  [Signature <String>]: Terms signature.
  [SystemDataCreatedAt <DateTime?>]: The timestamp of resource creation (UTC).
  [SystemDataCreatedBy <String>]: The identity that created the resource.
  [SystemDataCreatedByType <CreatedByType?>]: The type of identity that created the resource.
  [SystemDataLastModifiedAt <DateTime?>]: The timestamp of resource last modification (UTC)
  [SystemDataLastModifiedBy <String>]: The identity that last modified the resource.
  [SystemDataLastModifiedByType <CreatedByType?>]: The type of identity that last modified the resource.
.Link
https://docs.microsoft.com/powershell/module/az.marketplaceordering/set-azmarketplaceterms
#>
function Set-AzMarketplaceTerms {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms])]
[CmdletBinding(DefaultParameterSetName='TermsAccept', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='TermsAccept', Mandatory)]
    [Parameter(ParameterSetName='TermsReject', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Path')]
    [System.String]
    # Offer identifier string of image being deployed.
    ${Product},

    [Parameter(ParameterSetName='TermsAccept', Mandatory)]
    [Parameter(ParameterSetName='TermsReject', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Path')]
    [System.String]
    # Plan identifier string of image being deployed.
    ${Name},

    [Parameter(ParameterSetName='TermsAccept', Mandatory)]
    [Parameter(ParameterSetName='TermsReject', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Path')]
    [System.String]
    # Publisher identifier string of image being deployed.
    ${Publisher},

    [Parameter(ParameterSetName='TermsAccept')]
    [Parameter(ParameterSetName='TermsReject')]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='TermsAccept', Mandatory)]
    [Parameter(ParameterSetName='TermsAcceptViaIdentity', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If any version of the terms have been accepted, otherwise false.
    ${Accept},

    [Parameter(ParameterSetName='TermsReject', Mandatory)]
    [Parameter(ParameterSetName='TermsRejectViaIdentity', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Pass this to reject the legal terms.
    ${Reject},

    [Parameter(ParameterSetName='TermsAcceptViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='TermsRejectViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Models.Api202101.IAgreementTerms]
    # Terms properties for provided Publisher/Offer/Plan tuple
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    # To construct, see NOTES section for TERMS properties and create a hash table.
    ${Terms},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName

        if ($null -eq [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion) {
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion = $Host.Version.ToString()
        }         
        $preTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        if ($preTelemetryId -eq '') {
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId =(New-Guid).ToString()
            [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.module]::Instance.Telemetry.Invoke('Create', $MyInvocation, $parameterSet, $PSCmdlet)
        } else {
            $internalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
            if ($internalCalledCmdlets -eq '') {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $MyInvocation.MyCommand.Name
            } else {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets += ',' + $MyInvocation.MyCommand.Name
            }
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = 'internal'
        }

        $mapping = @{
            TermsAccept = 'Az.MarketplaceOrdering.custom\Set-AzMarketplaceTerms';
            TermsReject = 'Az.MarketplaceOrdering.custom\Set-AzMarketplaceTerms';
            TermsAcceptViaIdentity = 'Az.MarketplaceOrdering.custom\Set-AzMarketplaceTerms';
            TermsRejectViaIdentity = 'Az.MarketplaceOrdering.custom\Set-AzMarketplaceTerms';
        }
        if (('TermsAccept', 'TermsReject') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }

    finally {
        $backupTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        $backupInternalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
    }

}
end {
    try {
        $steppablePipeline.End()

        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $backupTelemetryId
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $backupInternalCalledCmdlets
        if ($preTelemetryId -eq '') {
            [Microsoft.Azure.PowerShell.Cmdlets.MarketplaceOrdering.module]::Instance.Telemetry.Invoke('Send', $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        }
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $preTelemetryId

    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
} 
}
