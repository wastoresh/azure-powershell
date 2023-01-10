
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
Create a segment by id in a private cloud workload network.
.Description
Create a segment by id in a private cloud workload network.
.Example
{{ Add code here }}
.Example
{{ Add code here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IWorkloadNetworkSegment
.Link
https://learn.microsoft.com/powershell/module/az.vmware/new-azvmwareworkloadnetworksegment
#>
function New-AzVMwareWorkloadNetworkSegment {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20211201.IWorkloadNetworkSegment])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
    [System.String]
    # Name of the private cloud
    ${PrivateCloudName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
    [System.String]
    # NSX Segment identifier.
    # Generally the same as the Segment's display name
    ${SegmentName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
    [System.String]
    # Gateway which to connect segment to.
    ${ConnectedGateway},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
    [System.String]
    # Display name of the segment.
    ${DisplayName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
    [System.Int64]
    # NSX revision number.
    ${Revision},

    [Parameter()]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
    [System.String[]]
    # DHCP Range assigned for subnet.
    ${SubnetDhcpRange},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Body')]
    [System.String]
    # Gateway address.
    ${SubnetGatewayAddress},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
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

        $mapping = @{
            CreateExpanded = 'Az.VMware.private\New-AzVMwareWorkloadNetworkSegment_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }

        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {

        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {

        throw
    }

}
end {
    try {
        $steppablePipeline.End()

    } catch {

        throw
    }
} 
}
