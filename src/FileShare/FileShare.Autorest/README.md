<!-- region Generated -->
# Az.FileShare
This directory contains the PowerShell module for the FileShare service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.FileShare`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
commit: 72c69a0cf561d41ae99fe6810c426a874d3a8372
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - D:\code\swaggerprivate\specification\fileshares\resource-manager\Microsoft.FileShares\preview\2024-01-01-preview\fileshares.json

# Normally, title is the service name
title: FileShare
# For new RP, the version is 0.1.0
subject-prefix: $(service-name)

enable-parent-pipeline-input: true

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  - where:
      variant: ^(Create|Update)(?!.*?Expanded)
    remove: true
  - where:
      model-name: Volume|VolumeGroup|Snapshot
    set:
      suppress-format: true
```
