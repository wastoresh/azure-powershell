# Overall
This directory contains the service clients of other services for Azure PowerShell Compute module.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=Storage
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```



### Tag: Storage
``` yaml $(tag) == 'Storage'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/storage/resource-manager/Microsoft.Storage/stable/2021-09-01/storage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/storage/resource-manager/Microsoft.Storage/stable/2021-09-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/main/specification/storage/resource-manager/Microsoft.Storage/stable/2021-09-01/file.json
output-folder: Storage

payload-flattening-threshold: 2
namespace: Microsoft.Azure.Management.Storage

directive:
  - remove-operation:
    - Operations_List
    - Skus_List
    - DeletedAccounts_List
    - DeletedAccounts_Get
    - StorageAccounts_ListAccountSAS
    - StorageAccounts_ListServiceSAS
    - PrivateEndpointConnections_List
    - PrivateEndpointConnections_Get
    - PrivateEndpointConnections_Put
    - PrivateEndpointConnections_Delete
    - PrivateLinkResources_ListByStorageAccount
    - BlobServices_List
    - FileServices_List
```