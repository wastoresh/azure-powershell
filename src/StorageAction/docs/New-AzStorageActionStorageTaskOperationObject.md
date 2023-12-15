---
external help file:
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/Az.StorageAction/new-azstorageactionstoragetaskoperationobject
schema: 2.0.0
---

# New-AzStorageActionStorageTaskOperationObject

## SYNOPSIS
Create an in-memory object for StorageTaskOperation.

## SYNTAX

```
New-AzStorageActionStorageTaskOperationObject -Name <String> [-OnFailure <String>] [-OnSuccess <String>]
 [-Parameter <IStorageTaskOperationParameters>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageTaskOperation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Name
The operation to be performed on the object.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnFailure
Action to be taken when the operation fails for a object.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnSuccess
Action to be taken when the operation is successful for a object.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Key-value parameters for the operation.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskOperationParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.StorageTaskOperation

## NOTES

## RELATED LINKS

