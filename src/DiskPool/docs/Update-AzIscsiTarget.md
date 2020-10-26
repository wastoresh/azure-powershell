---
external help file:
Module Name: Az.DiskPool
online version: https://docs.microsoft.com/en-us/powershell/module/az.diskpool/update-aziscsitarget
schema: 2.0.0
---

# Update-AzIscsiTarget

## SYNOPSIS
Update an iSCSI target.

## SYNTAX

### UpdateViaIdentityExpanded (Default)
```
Update-AzIscsiTarget -InputObject <IDiskPoolIdentity> -Tpg <ITargetPortalGroupUpdate[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzIscsiTarget -DiskPoolName <String> -Name <String> -ResourceGroupName <String>
 -Tpg <ITargetPortalGroupUpdate[]> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an iSCSI target.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskPoolName
The name of the Disk Pool.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the iSCSI target.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: IscsiTargetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tpg
List of iSCSI target portal groups.
To construct, see NOTES section for TPG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.ITargetPortalGroupUpdate[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IIscsiTarget

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDiskPoolIdentity>: Identity Parameter
  - `[DiskPoolName <String>]`: The name of the Disk Pool.
  - `[Id <String>]`: Resource identity path
  - `[IscsiTargetName <String>]`: The name of the iSCSI target.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

TPG <ITargetPortalGroupUpdate[]>: List of iSCSI target portal groups.
  - `[Acls <IAcl[]>]`: Access Control List (ACL) for an iSCSI Target Portal Group.
    - `InitiatorIqn <String>`: iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".
    - `MappedLun <String[]>`: List of LUN names mapped to the ACL.
    - `[CredentialsPassword <String>]`: Password for Challenge Handshake Authentication Protocol (CHAP) authentication.
    - `[CredentialsUsername <String>]`: Username for Challenge Handshake Authentication Protocol (CHAP) authentication.
  - `[Lun <IIscsiLun[]>]`: List of LUNs to be exposed through the iSCSI Target Portal Group.
    - `ManagedDiskAzureResourceId <String>`: Azure Resource ID of the Managed Disk.
    - `Name <String>`: User defined name for iSCSI LUN; example: "lun0"

## RELATED LINKS

