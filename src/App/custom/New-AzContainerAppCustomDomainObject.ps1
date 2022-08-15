
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
Create an in-memory object for CustomDomain.
.Description
Create an in-memory object for CustomDomain.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.CustomDomain
.Link
https://docs.microsoft.com/powershell/module/az./new-azcontainerappcustomdomainobject
#>
function New-AzContainerAppCustomDomainObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.CustomDomain')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Custom Domain binding type.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType])]
        [Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType]
        $BindingType,
        [Parameter(Mandatory, HelpMessage="Resource Id of the Certificate to be bound to this hostname. Must exist in the Managed Environment.")]
        [string]
        $CertificateId,
        [Parameter(Mandatory, HelpMessage="Hostname.")]
        [string]
        $Name
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.CustomDomain]::New()

        if ($PSBoundParameters.ContainsKey('BindingType')) {
            $Object.BindingType = $BindingType
        }
        if ($PSBoundParameters.ContainsKey('CertificateId')) {
            $Object.CertificateId = $CertificateId
        }
        if ($PSBoundParameters.ContainsKey('Name')) {
            $Object.Name = $Name
        }
        return $Object
    }
}

