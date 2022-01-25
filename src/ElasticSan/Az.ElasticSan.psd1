@{
  GUID = '6f3f3d3e-fdfe-4f44-ab8e-3de888c3982a'
  RootModule = './Az.ElasticSan.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: ElasticSan cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.ElasticSan.private.dll'
  FormatsToProcess = './Az.ElasticSan.format.ps1xml'
  FunctionsToExport = 'Get-AzElasticSan', 'Get-AzElasticSanSnapshot', 'Get-AzElasticSanVolume', 'Get-AzElasticSanVolumeGroup', 'New-AzElasticSan', 'New-AzElasticSanSnapshot', 'New-AzElasticSanVolume', 'New-AzElasticSanVolumeGroup', 'Remove-AzElasticSan', 'Remove-AzElasticSanSnapshot', 'Remove-AzElasticSanVolume', 'Remove-AzElasticSanVolumeGroup', 'Set-AzElasticSan', 'Set-AzElasticSanSnapshot', 'Set-AzElasticSanVolume', 'Set-AzElasticSanVolumeGroup', 'Update-AzElasticSan', 'Update-AzElasticSanSnapshot', 'Update-AzElasticSanVolume', 'Update-AzElasticSanVolumeGroup', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'ElasticSan'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
