---
external help file:
Module Name: Az.DiskPool
online version: https://docs.microsoft.com/en-us/powershell/module/az.DiskPool/new-AzDiskPoolTargetPortalGroupObject
schema: 2.0.0
---

# New-AzDiskPoolTargetPortalGroupObject

## SYNOPSIS
Create a in-memory object for TargetPortalGroup

## SYNTAX

```
New-AzDiskPoolTargetPortalGroupObject -Acls <IAcl[]> -AttributeAuthentication <Boolean>
 -AttributeProdModeWriteProtect <Boolean> -Lun <IIscsiLun[]> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for TargetPortalGroup

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

### -Acls
Access Control List (ACL) for an iSCSI Target Portal Group.
To construct, see NOTES section for ACLS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IAcl[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeAuthentication
Indicates whether or not authentication is enabled on the ACL.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AttributeProdModeWriteProtect
Indicates whether or not write protect is enabled on the LUNs.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lun
List of LUNs to be exposed through iSCSI Target Portal Group.
To construct, see NOTES section for LUN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.IIscsiLun[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20200315Preview.TargetPortalGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ACLS <IAcl[]>: Access Control List (ACL) for an iSCSI Target Portal Group.
  - `InitiatorIqn <String>`: iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".
  - `MappedLun <String[]>`: List of LUN names mapped to the ACL.
  - `[CredentialsPassword <String>]`: Password for Challenge Handshake Authentication Protocol (CHAP) authentication.
  - `[CredentialsUsername <String>]`: Username for Challenge Handshake Authentication Protocol (CHAP) authentication.

LUN <IIscsiLun[]>: List of LUNs to be exposed through iSCSI Target Portal Group.
  - `ManagedDiskAzureResourceId <String>`: Azure Resource ID of the Managed Disk.
  - `Name <String>`: User defined name for iSCSI LUN; example: "lun0"

## RELATED LINKS

