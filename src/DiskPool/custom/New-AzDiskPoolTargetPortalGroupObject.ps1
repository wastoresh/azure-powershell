
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for TargetPortalGroup
.Description
Create a in-memory object for TargetPortalGroup

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroup
.Link
https://docs.microsoft.com/en-us/powershell/module/az.DiskPool/new-AzDiskPoolTargetPortalGroupObject
#>
function New-AzDiskPoolTargetPortalGroupObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroup')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory, HelpMessage="Access Control List (ACL) for an iSCSI Target Portal Group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IAcl[]]
        $Acls,
        [Parameter(Mandatory, HelpMessage="Indicates whether or not authentication is enabled on the ACL.")]
        [bool]
        $AttributeAuthentication,
        [Parameter(Mandatory, HelpMessage="Indicates whether or not write protect is enabled on the LUNs.")]
        [bool]
        $AttributeProdModeWriteProtect,
        [Parameter(Mandatory, HelpMessage="List of LUNs to be exposed through iSCSI Target Portal Group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IIscsiLun[]]
        $Lun
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroup]::New()

        $Object.Acls = $Acls
        $Object.AttributeAuthentication = $AttributeAuthentication
        $Object.AttributeProdModeWriteProtect = $AttributeProdModeWriteProtect
        $Object.Lun = $Lun
        return $Object
    }
}

