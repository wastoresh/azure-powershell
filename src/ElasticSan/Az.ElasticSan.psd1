@{
  GUID = '59312ee6-fca5-496d-b524-376bb54a5c68'
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
  FunctionsToExport = 'Export-AzElasticSanVolumeSnapshot', 'Get-AzElasticSan', 'Get-AzElasticSanSku', 'Get-AzElasticSanVolume', 'Get-AzElasticSanVolumeGroup', 'Get-AzElasticSanVolumeSnapshot', 'New-AzElasticSan', 'New-AzElasticSanVirtualNetworkRuleObject', 'New-AzElasticSanVolume', 'New-AzElasticSanVolumeGroup', 'New-AzElasticSanVolumeSnapshot', 'Remove-AzElasticSan', 'Remove-AzElasticSanVolume', 'Remove-AzElasticSanVolumeGroup', 'Remove-AzElasticSanVolumeSnapshot', 'Update-AzElasticSan', 'Update-AzElasticSanVolume', 'Update-AzElasticSanVolumeGroup', 'Update-AzElasticSanVolumeSnapshot', '*'
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
