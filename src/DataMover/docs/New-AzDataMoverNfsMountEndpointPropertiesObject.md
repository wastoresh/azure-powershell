---
external help file:
Module Name: Az.DataMover
online version: https://docs.microsoft.com/powershell/module/az.DataMover/new-AzDataMoverNfsMountEndpointPropertiesObject
schema: 2.0.0
---

# New-AzDataMoverNfsMountEndpointPropertiesObject

## SYNOPSIS
Create a in-memory object for NfsMountEndpointProperties

## SYNTAX

```
New-AzDataMoverNfsMountEndpointPropertiesObject -EndpointType <EndpointType> -Host <String>
 -NfsVersion <NfsVersion> -RemoteExport <String> [-Description <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for NfsMountEndpointProperties

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

### -Host
The host name or IP address of the server exporting the file system.

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

### -NfsVersion
The NFS protocol version.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataMover.Support.NfsVersion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteExport
The directory being exported from the server.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataMover.Models.Api20210801.NfsMountEndpointProperties

## NOTES

ALIASES

## RELATED LINKS

