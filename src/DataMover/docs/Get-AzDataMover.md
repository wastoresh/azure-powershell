---
external help file:
Module Name: Az.DataMover
online version: https://docs.microsoft.com/powershell/module/az.datamover/get-azdatamover
schema: 2.0.0
---

# Get-AzDataMover

## SYNOPSIS
Gets a data mover resource.

## SYNTAX

### List (Default)
```
Get-AzDataMover [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataMover -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDataMover -InputObject <IDataMoverIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzDataMover -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a data mover resource.

## EXAMPLES

### Example 1: List all datamovers from a subscription
```powershell
PS C:\> Get-AzDataMover

{{ Add output here }}
```

This command lists all datamovers from the current subscription.

### Example 2: List all datamovers from a resource group
```powershell
PS C:\> Get-AzDataMover -ResourceGroupName "resourcegroupname"

{{ Add output here }}
```

This command lists all datamovers from a resource group.

### Example 3: Get a datamover resource with specfic name from a resource group.
```powershell
PS C:\> Get-AzDataMover -ResourceGroupName "resourcegroupname" -Name "datamovername1"

{{ Add output here }}
```

This command gets a datamover resource with specfic name from a resource group.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMover.Models.IDataMoverIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the data mover resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DataMoverName

Required: True
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
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMover.Models.IDataMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataMover.Models.Api20210801.IDataMover

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataMoverIdentity>: Identity Parameter
  - `[AgentName <String>]`: The name of the agent resource.
  - `[DataMoverName <String>]`: The name of the data mover resource.
  - `[EndpointName <String>]`: The name of the endpoint resource.
  - `[Id <String>]`: Resource identity path
  - `[JobDefinitionName <String>]`: The name of the job definition resource.
  - `[JobRunName <String>]`: The name of the job run.
  - `[ProjectName <String>]`: The name of the project resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

