---
external help file:
Module Name: Az.DataMover
online version: https://docs.microsoft.com/powershell/module/az.DataMover/new-AzDataMoverAzureStorageBlobContainerEndpointPropertiesObject
schema: 2.0.0
---

# New-AzDataMoverAzureStorageBlobContainerEndpointPropertiesObject

## SYNOPSIS
Create an in-memory object for AzureStorageBlobContainerEndpointProperties.

## SYNTAX

```
New-AzDataMoverAzureStorageBlobContainerEndpointPropertiesObject -BlobContainerName <String>
 -EndpointType <EndpointType> -StorageAccountResourceId <String> [-Description <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureStorageBlobContainerEndpointProperties.

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

### -BlobContainerName
The name of the Storage blob container that is the target destination.

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

### -Description
A description for the endpoint.

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

### -EndpointType
The endpoint resource type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMover.Support.EndpointType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountResourceId
The Azure Resource ID of the storage account that is the target destination.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataMover.Models.Api20210801.AzureStorageBlobContainerEndpointProperties

## NOTES

ALIASES

## RELATED LINKS

