---
Module Name: Az.Storage
Module Guid: 623d6d33-3536-4fca-a27a-e2722f5323b4
Download Help Link: https://learn.microsoft.com/powershell/module/az.storage
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Storage Module
## Description
Microsoft Azure PowerShell: Storage cmdlets

## Az.Storage Cmdlets
### [Get-AzStorageAccountMigration](Get-AzStorageAccountMigration.md)
Gets the status of the ongoing migration for the specified storage account.

### [Get-AzStorageConnector](Get-AzStorageConnector.md)
Get the specified Storage Connector.

### [Get-AzStorageDataShare](Get-AzStorageDataShare.md)
Get the specified Storage DataShare.

### [Get-AzStorageFileServiceUsage](Get-AzStorageFileServiceUsage.md)
Gets the usage of file service in storage account including account limits, file share limits and constants used in recommendations and bursting formula.

### [Get-AzStorageNetworkSecurityPerimeterConfiguration](Get-AzStorageNetworkSecurityPerimeterConfiguration.md)
Gets effective NetworkSecurityPerimeterConfiguration for association

### [Get-AzStorageSku](Get-AzStorageSku.md)
Lists the available SKUs supported by Microsoft.Storage for given subscription.

### [Get-AzStorageTaskAssignment](Get-AzStorageTaskAssignment.md)
Get the storage task assignment properties

### [Get-AzStorageTaskAssignmentInstancesReport](Get-AzStorageTaskAssignmentInstancesReport.md)
Fetch the report summary of a single storage task assignment's instances

### [Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration](Invoke-AzStorageReconcileNetworkSecurityPerimeterConfiguration.md)
Refreshes any information about the association.

### [New-AzStorageConnector](New-AzStorageConnector.md)
Create a Storage Connector if it does not already exist; otherwise, error out.
This API will not allow you to replace an already existing resource.

### [New-AzStorageDataShare](New-AzStorageDataShare.md)
Create a Storage DataShare if it does not already exist; otherwise, error out.
This API will not allow you to replace an already existing resource.

### [New-AzStorageDataShareAccessPolicyObject](New-AzStorageDataShareAccessPolicyObject.md)
Create an in-memory object for StorageDataShareAccessPolicy.

### [New-AzStorageDataShareAssetObject](New-AzStorageDataShareAssetObject.md)
Create an in-memory object for StorageDataShareAsset.

### [New-AzStorageDataShareConnectionObject](New-AzStorageDataShareConnectionObject.md)
Create an in-memory object for DataShareConnection.

### [New-AzStorageDataShareSourceObject](New-AzStorageDataShareSourceObject.md)
Create an in-memory object for DataShareSource.

### [New-AzStorageDataShareSourceUpdateObject](New-AzStorageDataShareSourceUpdateObject.md)
Create an in-memory object for DataShareSourceUpdate.

### [New-AzStorageManagedIdentityAuthPropertyObject](New-AzStorageManagedIdentityAuthPropertyObject.md)
Create an in-memory object for ManagedIdentityAuthProperties.

### [New-AzStorageManagedIdentityAuthPropertypdateObject](New-AzStorageManagedIdentityAuthPropertypdateObject.md)
Create an in-memory object for ManagedIdentityAuthPropertiesUpdate.

### [New-AzStorageTaskAssignment](New-AzStorageTaskAssignment.md)
Asynchronously create a new storage task assignment sub-resource with the specified parameters.
If a storage task assignment is already created and a subsequent create request is issued with different properties, the storage task assignment properties will be updated.
If a storage task assignment is already created and a subsequent create request is issued with the exact same set of properties, the request will succeed.

### [Remove-AzStorageConnector](Remove-AzStorageConnector.md)
Delete a Storage Connector.

### [Remove-AzStorageDataShare](Remove-AzStorageDataShare.md)
Delete a Storage DataShare.

### [Remove-AzStorageTaskAssignment](Remove-AzStorageTaskAssignment.md)
Delete the storage task assignment sub-resource

### [Start-AzStorageAccountMigration](Start-AzStorageAccountMigration.md)
Account Migration request can be triggered for a storage account to change its redundancy level.
The migration updates the non-zonal redundant storage account to a zonal redundant account or vice-versa in order to have better reliability and availability.
Zone-redundant storage (ZRS) replicates your storage account synchronously across three Azure availability zones in the primary region.

### [Stop-AzStorageTaskAssignment](Stop-AzStorageTaskAssignment.md)
Stops any active running storage action for the storage task assignment

### [Test-AzStorageConnectorExistingConnection](Test-AzStorageConnectorExistingConnection.md)
This method is used to verify that the connection to the backing data store works.\nThis API is designed to be used for monitoring and debugging purposes.
From the caller’s perspective,\nthis method does the following: Calls List on the backing data store, attempting to list up to one blob/object/etc.\nIf the above succeeds, and if a blob/object/etc is found, calls Get on that object, attempting to download one byte.

### [Update-AzStorageConnector](Update-AzStorageConnector.md)
Update a Storage Connector.

### [Update-AzStorageDataShare](Update-AzStorageDataShare.md)
Update a Storage DataShare.

### [Update-AzStorageTaskAssignment](Update-AzStorageTaskAssignment.md)
Update storage task assignment properties

