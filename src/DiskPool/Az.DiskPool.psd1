@{
  GUID = '24faf88e-65f1-4cdc-8b13-01bd6735cbd3'
  RootModule = './Az.DiskPool.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DiskPool cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DiskPool.private.dll'
  FormatsToProcess = './Az.DiskPool.format.ps1xml'
  FunctionsToExport = 'Get-AzDiskPool', 'Get-AzIscsiTarget', 'New-AzDiskPool', 'New-AzIscsiTarget', 'Remove-AzDiskPool', 'Remove-AzIscsiTarget', 'Update-AzDiskPool', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DiskPool'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
