
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
Create a in-memory object for TargetPortalGroupUpdate
.Description
Create a in-memory object for TargetPortalGroupUpdate

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroupUpdate
.Link
https://docs.microsoft.com/en-us/powershell/module/az.DiskPool/new-AzDiskPoolTargetPortalGroupUpdateObject
#>
function New-AzDiskPoolTargetPortalGroupUpdateObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroupUpdate')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="Access Control List (ACL) for an iSCSI Target Portal Group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IAcl[]]
        $Acls,
        [Parameter(HelpMessage="List of LUNs to be exposed through the iSCSI Target Portal Group.")]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IIscsiLun[]]
        $Lun
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroupUpdate]::New()

        $Object.Acls = $Acls
        $Object.Lun = $Lun
        return $Object
    }
}

