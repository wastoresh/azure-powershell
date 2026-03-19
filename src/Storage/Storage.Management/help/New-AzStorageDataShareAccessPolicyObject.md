---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/Az.Storage/new-azstoragedatashareaccesspolicyobject
schema: 2.0.0
---

# New-AzStorageDataShareAccessPolicyObject

## SYNOPSIS
Create an in-memory object for StorageDataShareAccessPolicy.

## SYNTAX

```
New-AzStorageDataShareAccessPolicyObject -Permission <String> -PrincipalId <String> -TenantId <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageDataShareAccessPolicy.

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

### -Permission
Allowed permissions.
Currently, only supported value is Read.

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

### -PrincipalId
The AAD principal ID of the Managed Identity.

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

### -TenantId
The AAD tenant ID of the Managed Identity.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.StorageDataShareAccessPolicy

## NOTES

## RELATED LINKS
