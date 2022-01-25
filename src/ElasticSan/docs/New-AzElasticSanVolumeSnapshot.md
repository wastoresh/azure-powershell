---
external help file:
Module Name: Az.ElasticSan
online version: https://docs.microsoft.com/powershell/module/az.elasticsan/new-azelasticsanvolumesnapshot
schema: 2.0.0
---

# New-AzElasticSanVolumeSnapshot

## SYNOPSIS
Create a Volume Snapshot.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticSanVolumeSnapshot -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> [-SubscriptionId <String>] [-CreationDataSourceUri <String>] [-Location <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzElasticSanVolumeSnapshot -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupName <String> -Parameter <ISnapshot> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> -Parameter <ISnapshot>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzElasticSanVolumeSnapshot -InputObject <IElasticSanIdentity> [-CreationDataSourceUri <String>]
 [-Location <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Volume Snapshot.

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

### -CreationDataSourceUri
If createOption is Copy, this is the ARM id of the source snapshot or disk.
If createOption is Restore, this is the ARM-like id of the source disk restore point.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -ElasticSanName
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the snapshot within the given subscription, resource and volume group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: SnapshotName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Response for Volume Snapshot request.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ISnapshot
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Azure resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VolumeGroupName
The name of the VolumeGroup.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ISnapshot

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.ISnapshot

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IElasticSanIdentity>: Identity Parameter
  - `[ElasticSanName <String>]`: The name of the ElasticSan.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SnapshotName <String>]`: The name of the snapshot within the given subscription, resource and volume group.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VolumeGroupName <String>]`: The name of the VolumeGroup.
  - `[VolumeName <String>]`: The name of the Volume.

PARAMETER <ISnapshot>: Response for Volume Snapshot request.
  - `[Location <String>]`: The geo-location where the resource lives.
  - `[Tag <IResourceTags>]`: Azure resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[CreationDataSourceUri <String>]`: If createOption is Copy, this is the ARM id of the source snapshot or disk. If createOption is Restore, this is the ARM-like id of the source disk restore point.

## RELATED LINKS

