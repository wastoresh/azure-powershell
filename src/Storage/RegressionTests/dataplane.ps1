# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 

BeforeAll {
    # Modify the path to your own
    Import-Module (get-item .\utils.ps1).FullName

    [xml]$config = Get-Content (get-item .\config.xml).FullName
    $globalNode = $config.SelectSingleNode("config/section[@id='global']")
    $testNode = $config.SelectSingleNode("config/section[@id='dataplane']")

    $resourceGroupName = $globalNode.resourceGroupName
    $storageAccountName = $testNode.SelectSingleNode("accountName[@id='1']").'#text'
    $storageAccountName2 = $testNode.SelectSingleNode("accountName[@id='2']").'#text'
    
    # create oauth context
    #$secpasswd = ConvertTo-SecureString $globalNode.secPwd -AsPlainText -Force
    #$cred = New-Object System.Management.Automation.PSCredential ($globalNode.applicationId, $secpasswd)
    #Add-AzAccount -ServicePrincipal -Tenant $globalNode.tenantId -SubscriptionId $globalNode.subscriptionId -Credential $cred 

    # Connect-AzAccount
    $ctxoauth1 = New-AzStorageContext -StorageAccountName $storageAccountName
    $ctxoauth2 = New-AzStorageContext -StorageAccountName $storageAccountName2

    $storageAccountKey1 = (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName)[0].Value
    $ctx = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageAccountKey1
    $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context

    $localSrcFile = ".\data\testfile_10240K_0" # The file needs to exist before tests, and the size should be 10240K 
    $localSmallSrcFile = ".\data\testfile_1K_0" # The file needs to exist before tests, abd the size should be 1K
    $localBigSrcFile = ".\data\testfile_300M" # The file needs to exist before tests, and the size should be 300000K
    
    $localDestFile = ".\created\test1.txt" # test will create the file
    $containerName = GetRandomContainerName

    New-AzStorageContainer $containerName -Context $ctx
    New-AzStorageShare $containerName -Context $ctx
    New-AzStorageContainer -Name $containerName -Context $ctxoauth2

    
    $OriginalPref = $ProgressPreference
    $ProgressPreference = "SilentlyContinue"
}

Describe "dataplane test" {

    It "Blob Version test" -Tag "blobversion" {
        $Error.Clear()

        $localSrcFile = ".\data\testfile_2048K" #The file need exist before test, and should be 512 bytes aligned
        $localDestFile = ".\created\testversion.txt" # test will create the file

        $blobname = "aa.txt"
        $blobname2 = "bb.txt"

        $b = Set-AzStorageBlobContent -Container $containerName -Blob $blobname1 -File $localSrcFile -Context $ctx -Force
        $b.ICloudBlob.snapshot() 
        $b = Set-AzStorageBlobContent -Container $containerName -Blob $blobname1 -File $localSrcFile -Context $ctx -Force

        #list with include version
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx  -IncludeVersion 
        $b.Count | should -BeGreaterOrEqual 3

        #list with include version with ContinuationToken
        $Total = 0
        $Token = $Null
        $Blobs
        do
        {
             $Blobs = Get-AzStorageBlob -Container $containerName -Context $ctx -IncludeVersion -MaxCount 2 -ContinuationToken $Token
             $Total += $Blobs.Count
             $Blobs.Count | should -BeLessOrEqual 2
             # $blobs | ft Name,ContinuationToken
             if($Blobs.Length -le 0) 
             { 
                # echo "length 0"
                Break;
             }
             $Token = $Blobs[$blobs.Count -1].ContinuationToken;
        }
        While ($Token -ne $Null)
        $Total | should -BeGreaterOrEqual 3

        # get single with versionID or Snapshottime
        $b1 = $b | ?{$_.VersionId -ne $null} | Select-Object -First 1
        $b11 = Get-AzStorageBlob -Container $containerName -Context $ctx  -Blob $b1.Name -VersionId $b1.VersionId
        $b1.VersionId  | should -be $b11.VersionId
        $b2 = $b | ?{$_.SnapshotTime -ne $null} | Select-Object -First 1
        $b21 = Get-AzStorageBlob -Container $containerName -Context $ctx  -Blob $b2.Name -SnapshotTime $b2.SnapshotTime
        $b2.SnapshotTime  | should -be $b21.SnapshotTime

    
        # Test Copy
        $blobveresion = $b1 = $b | ?{$_.VersionId -ne $null -and !($_.BlobProperties.IsLatestVersion)} | Select-Object -First 1
        $blobveresion | Start-AzStorageBlobCopy  -DestContainer $containerName -DestBlob $blobname2 -Force # might fail for server issue, with "CannotVerifyCopySource"
        #$blobversionUri = $blobveresion | New-AzStorageBlobSASToken -Permission rt -FullUri -ExpiryTime (Get-Date).Add(6)
        #Start-AzStorageBlobCopy -AbsoluteUri $blobversionUri  -DestContainer $containerName -DestBlob $blobname2 -Force -DestContext $ctx # might fail for server issue, with "CannotVerifyCopySource"

        $blobsnapshot = $b | ?{$_.SnapshotTime -ne $null} | Select-Object -First 1
        $blobsnapshot | Start-AzStorageBlobCopy  -DestContainer $containerName -DestBlob $blobname2 -Force

        # Test download
        $blobveresion | Get-AzStorageBlobContent -Destination $localDestFile -Force
        $blobsnapshot | Get-AzStorageBlobContent -Destination $localDestFile -Force

        # Test SAS
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx  -IncludeVersion 
        $blobveresion = $b1 = $b | ?{$_.VersionId -ne $null -and !($_.BlobProperties.IsLatestVersion)} | Select-Object -First 1
        $blobsnapshot = $b | ?{$_.SnapshotTime -ne $null} | Select-Object -First 1
        $blobbase = $b | ?{$_.IsLatestVersion} | Select-Object -First 1
        if ($ctx.StorageAccount.Credentials.IsSharedKey -or $ctx.StorageAccount.Credentials.IsToken)
        {
            #Blob SAS - version
            $sas = $blobveresion | New-AzStorageBlobSASToken -Permission wdlactxr -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobveresion.BlobBaseClient.BlobContainerName -Blob $blobveresion.BlobBaseClient.Name -VersionId $blobveresion.VersionId -Context $sascontext
            $b1.VersionId  | should -be $blobveresion.VersionId
            #Blob SAS - snapshot
            $sas = $blobsnapshot | New-AzStorageBlobSASToken -Permission wdlactxr -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobsnapshot.BlobBaseClient.BlobContainerName -Blob $blobsnapshot.BlobBaseClient.Name -SnapshotTime $blobsnapshot.SnapshotTime -Context $sascontext
            $blobsnapshot.SnapshotTime  | should -be $b1.SnapshotTime

            #Blob SAS - base
            $sas = $blobbase | New-AzStorageBlobSASToken -Permission wdlactxri -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobbase.BlobBaseClient.BlobContainerName -Blob $blobbase.BlobBaseClient.Name -Context $sascontext
            $b1.LastModified  | should -be $blobbase.BlobBaseClient.GetProperties().value.LastModified
        
            #container SAS - version
            $sas = New-AzStorageContainerSASToken -Name $containerName -Permission wdlacrtxi -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) -Context $ctx 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobveresion.BlobBaseClient.BlobContainerName -Blob $blobveresion.BlobBaseClient.Name -VersionId $blobveresion.VersionId -Context $sascontext
            $b1.VersionId  | should -be $blobveresion.VersionId
        }
        if ($ctx.StorageAccount.Credentials.IsSharedKey)
        {
            #account SAS
            $sas = New-AzStorageAccountSASToken -Service Blob,Table -ResourceType Object,Service -Permission wdltxacfpuri -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) -Context $ctx 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobveresion.BlobBaseClient.BlobContainerName -Blob $blobveresion.BlobBaseClient.Name -VersionId $blobveresion.VersionId -Context $sascontext
            $b1.VersionId  | should -be $blobveresion.VersionId
        }

        #remove with versionID or Snapshottime
        Remove-AzStorageBlob -Container $containerName -Context $ctx  -Blob $blobveresion.Name -VersionId $blobveresion.VersionId
        $false  | should -be $blobveresion.BlobBaseClient.Exists().value
        Remove-AzStorageBlob -Container $containerName -Context $ctx  -Blob $blobsnapshot.Name -SnapshotTime $blobsnapshot.SnapshotTime
        $false  | should -be $blobsnapshot.BlobBaseClient.Exists().value

        #cleanup
        # Remove-AzStorageContainer $containerName -Context $ctx -Force
        $Error.Count | should -be 0

    }

    It "blob basic" {
        $Error.Clear()

        $sas = New-AzStorageAccountSASToken -Service Blob -ResourceType Service,Container -Permission rl -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas

        # if the PR https://github.com/Azure/azure-powershell/pull/5420 is not merged, the following 2 cmdlets will fail.
        $c = Get-AzStorageContainerAcl -MaxCount 10 -Context $ctxsas
        $c = Get-AzStorageContainer -Name $containerName -Context $ctxsas
        $c.Permission.PublicAccess | should -be $null
        $c = Get-AzStorageContainer -Name $containerName -Context $ctx
        $c.Permission.PublicAccess | should -be "Off"

        #upload blob with write only sas
        $sas = New-AzStorageBlobSASToken -container $containerName -Blob test.txt -Permission w -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        $a = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Properties @{"ContentType" = "image/jpeg"; "ContentMD5" = "i727sP7HigloQDsqadNLHw=="} -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Context $ctxsas
        # upload blob with access tier
        $a = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Context $ctx -StandardBlobTier cool 
        $a.ICloudBlob.Properties.StandardBlobTier | should -Be "Cool" 
        $b = Get-AzStorageContainer -Name $containerName -Context $ctx |Get-AzStorageBlob  
        $b.Count | Should -BeGreaterOrEqual 1

        # list/get blob with SAS without prefix "?"
        $sas = New-AzStorageBlobSASToken -container $containerName -Blob test.txt -Permission w -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas.Substring(1)
        $bs = Get-AzStorageBlob -Container $containerName -Context $ctx
        $bs[0].BlobType | Should -Not -Be $null 
        $bs[0].ListBlobProperties | should -Not -Be $null
        $bs[0].ListBlobProperties.Properties | should -Not -Be $null
        $bs[0].ListBlobProperties.Properties.BlobType | should -Not -Be $null
        $bs[0].BlobProperties | should -Not -Be $null
        $b = Get-AzStorageBlob -Container $containerName -Blob $bs[0].Name -Context $ctx
        $b.BlobProperties | should -Not -Be $null
        $b.ListBlobProperties | should -Be $null

        #copy with oauth 
        # cross account     
        $copyDest = Start-AzStorageBlobCopy -SrcContainer $containerName -SrcBlob test.txt -Context $ctxoauth1 -DestContainer $containerName -DestBlob test.txt -DestContext $ctxoauth2 -Force
        $copyDest | Get-AzStorageBlobCopyState -WaitForComplete
        $copydest.BlobBaseClient.Exists() | should -Be $true
        # same account   
        $copyDest = Start-AzStorageBlobCopy -SrcContainer $containerName -SrcBlob test.txt -Context $ctxoauth1 -DestContainer $containerName -DestBlob testcopysameaccount.txt -DestContext $ctxoauth1 -Force
        $copyDest | Get-AzStorageBlobCopyState -WaitForComplete
        $copydest.BlobBaseClient.Exists() | should -Be $true

        # copy with tier
        Start-AzStorageBlobCopy -AbsoluteUri $a.ICloudBlob.Uri.ToString() -DestContainer $containerName -DestBlob testtier.txt -Context $ctx -DestContext $ctx -Force -StandardBlobTier hot -RehydratePriority High
        (Get-AzStorageBlob -Container $containerName -Blob testtier.txt -Context $ctx).BlobProperties.AccessTier  | should -Be "hot"
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob testtier.txt -Context $ctx -DestContext $ctx -Force -RehydratePriority Standard
        (Get-AzStorageBlob -Container $containerName -Blob testtier.txt -Context $ctx).BlobProperties.AccessTier | should -Be "hot"
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob testtier.txt -Context $ctx -DestContext $ctx -Force -StandardBlobTier Archive 
        (Get-AzStorageBlob -Container $containerName -Blob testtier.txt -Context $ctx).BlobProperties.AccessTier  | should -Be "Archive"
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob test1.txt -Context $ctx -DestContext $ctx -Force          
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx
        $copystate = Get-AzStorageBlobCopyState -Container $containerName -Blob test1.txt -Context $ctx
        $copystate.Status | Should -Be "Success"

        #Sync Copy, the copy source must be block blob currently 
        $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob "test/test2/test.txt" -Context $ctx -StandardBlobTier hot -RehydratePriority High -Force
        $b.Name | Should -Be "test/test2/test.txt"
        $b.AccessTier | should -Be "hot"
        $longblobName = "testblobsyncopy201234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789.txt"
        $b = $b | Copy-AzStorageBlob -DestContainer $containerName -DestBlob $longblobName -Context $ctx -Force
        $b.Name | Should -Be $longblobName
        $blobSasUri = $b | New-AzStorageBlobSASToken -Permission rt -ExpiryTime (Get-Date).AddDays(6) -FullUri
        $b = Copy-AzStorageBlob -AbsoluteUri $blobSasUri -DestContainer $containerName -DestBlob testblobsyncopy3.txt -Context $ctx -Force
        $b.Name | Should -Be "testblobsyncopy3.txt"
        
        Set-AzStorageBlobContent -Container $containerName -Blob smallblock -File $localSmallSrcFile -Context $ctx -Force
        $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob smallblock -DestContainer $containerName -DestBlob smallblock2 -Context $ctx -Force
        $b.Name | Should -Be "smallblock2"
        $b.Length | should -Be (Get-Item $localSmallSrcFile).Length

        Set-AzStorageBlobContent -Container $containerName -Blob bigfile -File $localBigSrcFile -Context $ctx -Force
        $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob bigfile -DestContainer $containerName -DestBlob bigfile2 -Context $ctx -Force
        $b.Name | Should -Be "bigfile2"
        $b.Length | should -Be (Get-Item $localBigSrcFile).Length


        # download blob
        Get-AzStorageBlobContent -Container $containerName -Blob test1.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageBlobContent -Container $containerName -Blob test1.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageBlobContent -Container $containerName -Blob test1.txt -Force -Context $ctx
        del test1.txt
        $Error.Count | should -be 0
    }

    It "download item with create sub folder" {
        $Error.Clear()

        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob "aa/bb/cc/dd.txt" -Force -Context $ctx
        Get-AzStorageBlobContent -Container $containerName -Blob "aa/bb/cc/dd.txt" -Force -Context $ctx -Destination .
        del "aa\bb\cc\dd.txt"
        Remove-Item -Path "aa" -Force -Recurse
        $Error.Count | should -be 0
    }

    It "Quick Query" -tag "qq"{
        $Error.Clear()
        $qaSrcFile = "C:\temp\qq.txt" # This file should exist before tests
        $qaDestFile = "C:\temp\QA_result.csv"
        $blobName = "testcsvcurrent.csv"
        $blob = Set-AzStorageBlobContent -Container $containerName -Blob $blobName -File $qaSrcFile -Context $ctx -Force
        $inputconfig = New-AzStorageBlobQueryConfig -AsCsv -ColumnSeparator "," -QuotationCharacter """" -EscapeCharacter "\" -HasHeader  -RecordSeparator "" 
        $outputconfig = New-AzStorageBlobQueryConfig -AsJson  -RecordSeparator "" 
        #$queryString = "SELECT * FROM BlobStorage WHERE _1 LIKE '1%%'"
        $queryString = "SELECT _2 from BlobStorage WHERE _1 > 250;"
        $result = Get-AzStorageBlobQueryResult -Container $containerName -Blob $blobName -QueryString $queryString -ResultFile $qaDestFile -Context $ctx -Force -InputTextConfiguration $inputconfig -OutputTextConfiguration $outputconfig  
        ($result.BytesScanned -gt 0) | Should -BeTrue
        $result.FailureCount | Should -Be 0
        $result.BlobQueryError | Should -Be $null
        del $qaDestFile 
        $Error.Count | should -be 0
    }

    It "Set-AzStorageContainerAcl won't clean up the stored Access Policy" -Tag "accesspolicy" {
        $Error.Clear()

        Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -AllowBlobPublicAccess $true
        sleep 120 # Set sleep time to 2 min to make sure AllowBlobPublicAccess becomes True

        ## regression test for Fix  Set-AzStorageContainerAcl can clean up the stored Access Policy
        New-AzStorageContainerStoredAccessPolicy -Container $containerName  -Policy 123 -Permission rw -Context $ctx
        New-AzStorageContainerStoredAccessPolicy -Container $containerName  -Policy 234 -Permission rwdl -Context $ctx
        $policy = Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx
        $policy.Count | should -Be 2
        $policy[0].Policy | should -Be 123
        $policy[0].Permissions | should -Be rw
        $policy[0].ExpiryTime | should -Be $null
        $policy[0].StartTime | should -Be $null
        Set-AzStorageContainerAcl -Container $containerName  -Permission Blob -Context $ctx
        Set-AzStorageContainerAcl -Container $containerName  -Permission Off -Context $ctx
        $policy = Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx
        $policy.Count | should -Be 2

        # test generate SAS with access policy and start / expire will success
        $sas = New-AzStorageContainerSASToken -Name $ContainerName -Policy 123  -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(1) -Context $ctx
        $sas.Length | should -BeGreaterThan 10

        Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -AllowBlobPublicAccess $false

        $Error.Count | should -be 0
    }

    It "upload/download blob with as job" {
        $Error.Clear()

        $t = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed" 

        $t = Set-AzStorageBlobContent -File .\data\testfile_2048K -Container $containerName -Blob test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed" 

        #download blob with asjob
        #del $localDestFile
        $t = Get-AzStorageBlobContent -Container $containerName -Blob test.txt -Destination $localDestFile -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed" 

        del $localDestFile
        $t = Get-AzStorageBlobContent -Container $containerName -Blob test.txt -Destination $localDestFile -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"  
        del $localDestFile

        Remove-AzStorageBlob -Container $containerName -Blob test.txt -Force -Context $ctx
        Get-AzStorageBlob -Container $containerName -Context $ctx
        $Error.Count | should -be 0
    }

    It "Blob Incremental Copy" {
        $Error.Clear()
    
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob page -Force -BlobType page -Context $ctx
        $task = $b.ICloudBlob.SnapshotAsync() 
        $task.Wait()
        $snapshot = $task.Result
        $uri = New-AzStorageBlobSASToken -CloudBlob $snapshot -Permission wrd -FullUri -Context $ctx
        if ($uri -notlike "*?snapshot=20*")
        {
            throw $t.Error;
        }
        $content = Invoke-RestMethod -uRI $uri #-Headers @{ "x-ms-version"=“2019-02-02"}
        $content.Length
        
        # Start-AzStorageBlobIncrementalCopy -srcContainer $containerName -SrcBlob page -SrcBlobSnapshotTime $snapshot.SnapshotTime -DestContainer $containerName -DestBlob page2 -UseTrack2 -Context $ctx -DestContext $ctx
        # Get-AzStorageBlobCopyState -Container $containerName -Blob page2 -Context $ctx

        Start-AzStorageBlobIncrementalCopy -srcContainer $containerName -SrcBlob page -SrcBlobSnapshotTime $snapshot.SnapshotTime -DestContainer $containerName -DestBlob page2  -Context $ctx -DestContext $ctx
        $Error.Count | should -be 0
    } 
  
    It "File basic" {  
        $Error.Clear()
        Get-AzStorageShare -Context $ctx
        Set-AzStorageShareQuota -ShareName $containerName -Quota 500 -Context $ctx
        New-AzStorageDirectory -ShareName $containerName -Path testdir -Context $ctx
        Set-AzStorageFileContent -source .\data\testfile_2048K -ShareName $containerName -Path test.txt -Force -Context $ctx
        Set-AzStorageFileContent -source $localSrcFile -ShareName $containerName -Path test.txt   -PreserveSMBAttribute -Force -Context $ctx
        $file = Get-AzStorageFile -ShareName $containerName -Path test.txt -Context $ctx		
        $localFileProperties = Get-ItemProperty $localSrcFile
        $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
        $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
        $localFileProperties.Attributes.ToString() | should -Be  $file[0].FileProperties.SmbProperties.FileAttributes.ToString()

       # $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
       # $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
       # $localFileProperties.Attributes.ToString() | should -Be  $file[0].FileProperties.SmbProperties.FileAttributes.ToString()
       
       # list files with/without extended properties
        $files = Get-AzStorageFile -ShareName $containerName -Context $ctx
        ($files | ?{$_.ListFileProperties.IsDirectory} | Select-Object -First 1 ).ListFileProperties.Properties.ETag.ToString().length | should -BeGreaterThan 1
        ($files | ?{$_.ListFileProperties.IsDirectory -eq $false} | Select-Object -First 1 ).ListFileProperties.Properties.ETag.ToString().length | should -BeGreaterThan 1
        $files = Get-AzStorageFile -ShareName $containerName -Context $ctx -ExcludeExtendedInfo
        ($files | ?{$_.ListFileProperties.IsDirectory} | Select-Object -First 1 ).ListFileProperties.Properties.ETag | should -Be $null
        ($files | ?{$_.ListFileProperties.IsDirectory -eq $false} | Select-Object -First 1 ).ListFileProperties.Properties.ETag | should -Be $null

        Start-AzStorageFileCopy -SrcShareName $containerName -SrcFilePath test.txt -DestShareName $containerName -DestFilePath test1.txt -Force -Context $ctx -DestContext $ctx
        Start-AzStorageFileCopy -SrcShareName $containerName -SrcFilePath test.txt -DestShareName $containerName -DestFilePath test1.txt -Force -Context $ctx 
        Get-AzStorageFileCopyState -ShareName $containerName -FilePath test1.txt -Context $ctx
        Get-AzStorageFile -ShareName $containerName -Context $ctx
        Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageFileContent -ShareName $containerName -Path test1.txt -PreserveSMBAttribute -Force -Context $ctx
        $file = Get-AzStorageFile -ShareName $containerName -Context $ctx | ? {$_.Name -eq "test1.txt"}
        $localFileProperties = Get-ItemProperty test1.txt
        $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].ListFileProperties.Properties.CreatedOn.ToUniversalTime().Ticks
        $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].ListFileProperties.Properties.LastWrittenOn.ToUniversalTime().Ticks
        $localFileProperties.Attributes.ToString() | should -Be  $file[0].ListFileProperties.FileAttributes.ToString()
        
        # $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
        # $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
        # $localFileProperties.Attributes.ToString() | should -Be  $file[0].FileProperties.SmbProperties.FileAttributes.ToString()

        # del $localDestFile -Force
        $Error.Count | should -be 0
    }

    It "upload/download file with asjob" {
        $Error.Clear()
    
        #upload file with asjob
        $t = Set-AzStorageFileContent -source $localSrcFile -ShareName $containerName -Path test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"

        $t = Set-AzStorageFileContent -source .\data\testfile_2048K -ShareName $containerName -Path test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"

        #download file with asjob
        #del $localDestFile
        $t = Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"

        del $localDestFile
        $t = Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile  -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"
        del $localDestFile
        $Error.Count | should -be 0
    }

    It "file handle" {
        $Error.Clear()

        #filehandle 
        Get-AzStorageFileHandle -ShareName $containerName -Context $ctx
        Get-AzStorageFileHandle -ShareName $containerName -Path testdir -Context $ctx
        Get-AzStorageFileHandle  -ShareName $containerName -Path test.txt -Context $ctx 
        Close-AzStorageFileHandle -ShareName $containerName -CloseAll -Recursive -Context $ctx
        Close-AzStorageFileHandle -ShareName $containerName -Path testdir -CloseAll -Recursive -Context $ctx
        Close-AzStorageFileHandle -ShareName $containerName -Path test.txt -CloseAll -Context $ctx

        Remove-AzStorageFile -ShareName $containerName -Path test.txt -Context $ctx
        Remove-AzStorageDirectory -ShareName $containerName -Path testdir -Context $ctx
        $Error.Count | should -be 0
    }

    It "blob to/from File Copy" {
        $Error.Clear()
    
        Set-AzStorageFileContent -source $localSrcFile -ShareName $containerName -Path test1.txt -Force -Context $ctx
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Context $ctx
        #blob<->File Copy
        Start-AzStorageBlobCopy  -SrcShareName $containerName -SrcFilePath test1.txt -DestContainer $containerName -DestBlob test2.txt -Force -Context $ctx -DestContext $ctx -StandardBlobTier Cool -RehydratePriority High
        Get-AzStorageBlobCopyState -Container $containerName -Blob test2.txt -Context $ctx    
        if ((Get-AzStorageBlob -Container $containerName -Blob test2.txt -Context $ctx).BlobProperties.AccessTier -ne "Cool") { throw;}
        Start-AzStorageFileCopy  -SrcContainerName $containerName -SrcBlobName test.txt  -DestShareName $containerName -DestFilePath test2.txt -Force -Context $ctx -DestContext $ctx
        Get-AzStorageFileCopyState -ShareName $containerName -FilePath test2.txt -Context $ctx

        $fileuri = New-AzStorageFileSASToken -ShareName $containerName -Path test1.txt -Permission rdwl -ExpiryTime 2029-12-12 -Context $ctx -FullUri
        Start-AzStorageBlobCopy -AbsoluteUri $fileuri -DestContainer $containerName -DestBlob testtier4.txt -Force  -DestContext $ctx #-RehydratePriority Standard
        if ((Get-AzStorageBlob -Container $containerName -Blob testtier4.txt -Context $ctx).BlobProperties.AccessTier -ne "hot") { throw;}
        Start-AzStorageBlobCopy -AbsoluteUri $fileuri -DestContainer $containerName -DestBlob testtier5.txt -Force  -DestContext $ctx -StandardBlobTier Archive
        if ((Get-AzStorageBlob -Container $containerName -Blob testtier5.txt -Context $ctx).BlobProperties.AccessTier -ne "Archive") { throw;}
        $Error.Count | should -be 0
    }

    It "Table test" { 
        $Error.Clear()
        Get-AzStorageTable -Context $ctx
        New-AzStorageTable -Name $containerName -Context $ctx
        Get-AzStorageTable -Context $ctx
        ##Table SAS
            New-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p123 -Context $ctx -Permission r
            New-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p456 -Context $ctx -Permission rdu
            get-AzStorageTableStoredAccessPolicy -Table $containerName -Context $ctx 
            get-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p123 -Context $ctx 
            Remove-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p123 -Context $ctx 
            set-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p456 -Context $ctx -StartTime 2019-10-01 -ExpiryTime 2020-01-01
            New-AzStorageTableSASToken -Name $containerName -Policy p456 -Protocol HttpsOnly -IPAddressOrRange 12.0.0.1-20.4.0.0 -StartPartitionKey 123 -EndPartitionKey 456 -Context $ctx 
            New-AzStorageTableSASToken -Name $containerName -Permission ru -StartPartitionKey pk123 -EndPartitionKey pk456 -StartRowKey rk123 -EndRowKey rk456 -StartTime 2019-10-01 -ExpiryTime 2020-01-01 -Context $ctx -FullUri

        ## Table module
            #Import-module C:\code\AzureRmStorageTable\AzureRmStorageTable.psd1
            #For Linux        
            # Import-module /home/xtest/AzureRmStorageTable/AzureRmStorageTable.psd1
            $partitionKey1 = "partition1"
            $partitionKey2 = "partition2"
            $storageTable = (Get-AzStorageTable -Name $containerName -Context $ctx).CloudTable
            ### add  rows 
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey1 -rowKey ("CA") -property @{"username"="Chris";"userid"=1;"DateTimeProperty"="2012-01-02T23:00:00";"DateTimeProperty@odata.type"="Edm.DateTime"}
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey2 -rowKey ("NM2") -property @{"username"="Jessie";"userid"=2}
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey1 -rowKey ("CD") -property @{"username"="ChrisLi";"userid"=3;"time"=(Get-Date)}
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey1 -rowKey ("CC") -property @{"username"="ChrisLi";"userid"=4;"ff"=3213213213.3232132132131232132132323213233}
            ### Get Rows
            Get-AzTableRow -table $storageTable -partitionKey $partitionKey1 | ft userid,time,ff
            Get-AzTableRow -table $storageTable -columnName "username" -value "Chris" -operator Equal
            Get-AzTableRow -table $storageTable -customFilter "(userid eq 1)"
            # Create a filter and get the entity to be updated.
            [string]$filter = `
                [Microsoft.Azure.Cosmos.Table.TableQuery]::GenerateFilterCondition("username",`
                [Microsoft.Azure.Cosmos.Table.QueryComparisons]::Equal,"Jessie")
            $user = Get-AzTableRow -table $storageTable -customFilter $filter
            # Change the entity.
            $user.username = "Jessie2" 
            # To commit the change, pipe the updated record into the update cmdlet.
            $user | Update-AzTableRow -table $storageTable 
            # To see the new record, query the table.
            Get-AzTableRow -table $storageTable -customFilter "(username eq 'Jessie2')"
        ## Table API
            # Create Table Object - which reference to exist Table with SAS
            $tableSASUri = New-AzStorageTableSASToken -Name $containerName  -Permission "raud" -ExpiryTime (([DateTime]::UtcNow.AddDays(10))) -FullUri -Context $ctx
            $uri = [System.Uri]$tableSASUri
            $sasTable = New-Object -TypeName Microsoft.Azure.Cosmos.Table.CloudTable $uri 

            #Test run Table query - Query Entity
            $query = New-Object Microsoft.Azure.Cosmos.Table.TableQuery
            ## Define columns to select.
            $list = New-Object System.Collections.Generic.List[string]
            $list.Add("RowKey")
            $list.Add("username")
            $list.Add("userid")
            ## Set query details.
            $query.FilterString = "userid gt 0"
            $query.SelectColumns = $list
            $query.TakeCount = 20
            ## Execute the query.
            $sasTable.ExecuteQuerySegmentedAsync($query, $null)
            $storageTable.ExecuteQuerySegmentedAsync($query, $null) 

        ##Remove Table    
        Remove-AzStorageTable -Name $containerName -Force -Context $ctx

       # $Error.Count | should -be 0 
       # mark this line since Az.Table cmdlet will have error in $error with Get-Alias.
       # so check all errors are for Get-Alias       
        foreach ($e in $Error)
        {
            $e.Exception.Message | should -BeLike "This command cannot find a matching alias*"
        }
    }

    It "Queue test" {  
        $Error.Clear()
        Get-AzStorageQueue -Context $ctx
        New-AzStorageQueue -Name $containerName -Context $ctx
        Get-AzStorageQueue -Context $ctx
        $queue = Get-AzStorageQueue -Name $containerName -Context $ctx
        $queueMessage = "This is message 1"
        $queue.QueueClient.SendMessage($QueueMessage)
        $queueMessage = "This is message 2"
        $queue.QueueClient.SendMessage($QueueMessage)
        Remove-AzStorageQueue -Name $containerName -Force -Context $ctx
        Get-AzStorageQueue -Context $ctx
        $Error.Count | should -be 0
    }

    It "common service properties" {
        $Error.Clear()
        Set-AzStorageServiceLoggingProperty -ServiceType blob -RetentionDays 2 -Version 1.0 -LoggingOperations All -Context $ctx
        $properteis = Get-AzStorageServiceLoggingProperty -ServiceType blob -Context $ctx
        '1.0' | should -be $properteis.Version
        "All" | should -be  $properteis.LoggingOperations
        2 | should -be  $properteis.RetentionDays

        Set-AzStorageServiceMetricsProperty -ServiceType blob -Version 1.0 -MetricsType Hour -RetentionDays 2 -MetricsLevel Service -Context $ctx
        $properteis = Get-AzStorageServiceMetricsProperty -ServiceType Blob -MetricsType Hour -Context $ctx    
        '1.0' | should -be  $properteis.Version
        "Service" | should -be  $properteis.MetricsLevel
        '2.0' | should -be  $properteis.RetentionDays

        Set-AzStorageCORSRule -ServiceType blob -Context $ctx -CorsRules (@{
            AllowedHeaders=@("x-ms-blob-content-type","x-ms-blob-content-disposition");
            AllowedOrigins=@("*");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Get","Connect")},
            @{
            AllowedOrigins=@("http://www.fabrikam.com","http://www.contoso.com"); 
            ExposedHeaders=@("x-ms-meta-data*","x-ms-meta-customheader"); 
            AllowedHeaders=@("x-ms-meta-target*","x-ms-meta-customheader");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Put")})
        $rule = Get-AzStorageCORSRule -ServiceType blob -Context $ctx
        $rule
        2  | should -be $rule.Count
        Remove-AzStorageCORSRule -ServiceType blob -Context $ctx    
        $rule = Get-AzStorageCORSRule -ServiceType blob -Context $ctx
        0  | should -be $rule.Count
    
        Enable-AzStorageDeleteRetentionPolicy -RetentionDays 5 -Context $ctx
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $true  | should -be $properteis.DeleteRetentionPolicy.Enabled
        5  | should -be $properteis.DeleteRetentionPolicy.RetentionDays
        Disable-AzStorageDeleteRetentionPolicy  -Context $ctx
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $false  | should -be $properteis.DeleteRetentionPolicy.Enabled
    
        Enable-AzStorageStaticWebsite -IndexDocument index.xml -ErrorDocument404Path error.xml  -Context $ctx 
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $true  | should -be $properteis.StaticWebsite.Enabled
        $properteis.StaticWebsite.IndexDocument  | should -be "index.xml"
        $properteis.StaticWebsite.ErrorDocument404Path | should -be "error.xml" 
        Disable-AzStorageStaticWebsite -Context $ctx     
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $false  | should -be $properteis.StaticWebsite.Enabled
        Enable-AzStorageStaticWebsite -Context $ctx 
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $true  | should -be $properteis.StaticWebsite.Enabled
        $null  | should -be $properteis.StaticWebsite.IndexDocument
        $null  | should -be $properteis.StaticWebsite.ErrorDocument404Path
        Disable-AzStorageStaticWebsite -Context $ctx 
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $false  | should -be $properteis.StaticWebsite.Enabled
        $Error.Count | should -be 0

    }

    It "Table service properties test"  {
        $Error.Clear()
        Set-AzStorageServiceLoggingProperty -ServiceType table -RetentionDays 2 -Version 1.0 -LoggingOperations All -Context $ctx
        $properteis = Get-AzStorageServiceLoggingProperty -ServiceType table -Context $ctx
        '1.0' | should -be  $properteis.Version
        "All" | should -be  $properteis.LoggingOperations
        2 | should -be  $properteis.RetentionDays

        Set-AzStorageServiceMetricsProperty -ServiceType table -Version 1.0 -MetricsType Hour -RetentionDays 2 -MetricsLevel Service -Context $ctx
        $properteis = Get-AzStorageServiceMetricsProperty -ServiceType table -MetricsType Hour -Context $ctx
        '1.0' | should -be  $properteis.Version
        "Service" | should -be  $properteis.MetricsLevel
        2 | should -be  $properteis.RetentionDays

        Set-AzStorageCORSRule -ServiceType table -Context $ctx -CorsRules (@{
            AllowedHeaders=@("x-ms-blob-content-type","x-ms-blob-content-disposition");
            AllowedOrigins=@("*");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Get","Connect")},
            @{
            AllowedOrigins=@("http://www.fabrikam.com","http://www.contoso.com"); 
            ExposedHeaders=@("x-ms-meta-data*","x-ms-meta-customheader"); 
            AllowedHeaders=@("x-ms-meta-target*","x-ms-meta-customheader");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Put")})
        sleep 30
        $rule = Get-AzStorageCORSRule -ServiceType table -Context $ctx
        $rule.count | should -be 2
        Remove-AzStorageCORSRule -ServiceType table -Context $ctx
        sleep 30  
        $rule = Get-AzStorageCORSRule -ServiceType table -Context $ctx
        0  | should -be  $rule.Count

        Get-AzStorageServiceProperty -ServiceType table -Context $ctx
        $Error.Count | should -be 0
    } 

    It "container access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        $con = get-AzStorageContainer $containerName -Context $ctx

        Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx  | remove-AzStorageContainerStoredAccessPolicy  -Container $containerName -Context $ctx
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test1 -Permission xcdlrwt -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2 -Permission ctr -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test3 -Permission "" -ExpiryTime (Get-Date).AddDays(365*2)
        $policy = get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 
        $policy.Count | should -Be 3
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2
        Set-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2 -Permission xacdlrwt -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 
        Remove-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2
        Remove-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 

        $Error.Count | should -be 0
    }

    It "Share access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        $share = Get-AzStorageShare $containerName -Context $ctx

        New-AzStorageShareStoredAccessPolicy  $containerName -Context $ctx -Policy test1 -Permission lwr -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2 -Permission dclrw 
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx 
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2
        Set-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2 -Permission ldcrw -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx 
        Remove-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2
        Remove-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx 

        $Error.Count | should -be 0
    }

    It "Queue access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        New-AzStorageQueue $containerName -Context $ctx
        $queue = Get-AzStorageQueue $containerName -Context $ctx

        New-AzStorageQueueStoredAccessPolicy  $containerName -Context $ctx -Policy test1 -Permission apru -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission pu 
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx 
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Set-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission apru -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx 
        Remove-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Remove-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx 

        Remove-AzStorageQueue $containerName -Context $ctx -Force

        $Error.Count | should -be 0
    }

    It "Table access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        New-AzStorageTable $containerName -Context $ctx

        $table = Get-AzStorageTable $containerName -Context $ctx

        New-AzStorageTableStoredAccessPolicy  $containerName -Context $ctx -Policy test1 -Permission qaud -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission au 
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx 
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Set-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission qad -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx 
        Remove-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Remove-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx 

        Remove-AzStorageTable $containerName -Context $ctx -Force

        $Error.Count | should -be 0
    }
    
    It "Encryption Scope"{
        $Error.Clear()

         ## Encryption Scope
        #$secpasswd = ConvertTo-SecureString $globalNode.secPwd -AsPlainText -Force
        #$cred = New-Object System.Management.Automation.PSCredential ($globalNode.applicationId, $secpasswd)
        #Add-AzAccount -ServicePrincipal -Tenant $globalNode.tenantId -SubscriptionId $globalNode.subscriptionId -Credential $cred 

        $scopeName1 = "testscope"
        $scopeName2 = "testscope2"    
        $md5 = New-Object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider
        New-AzStorageEncryptionScope -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -EncryptionScopeName $scopeName1 -StorageEncryption
        New-AzStorageEncryptionScope -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -EncryptionScopeName $scopeName2 -StorageEncryption
        Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -AllowBlobPublicAccess $true

        sleep 120 # Make sleep time 2 min to make sure AllowBlobPublicAccess is True
        
        try{

            $containerName_es = $containerName + "es"
            $c = New-AzStorageContainer $containerName_es -Context $ctx -DefaultEncryptionScope $scopeName2 -PreventEncryptionScopeOverride $false -Permission Blob
            $scopeName2  | should -Be $c.BlobContainerProperties.DefaultEncryptionScope
            $false | should -Be  $c.BlobContainerProperties.PreventEncryptionScopeOverride
            $c.Permission.PublicAccess | should -be "Blob"

             uploadblob $ctx

             #SAS
            $sas = New-AzStorageContainerSASToken -Name $containerName_es -Permission wrdlt -ExpiryTime (Get-Date).AddDays(6) -Context $ctx #-EncryptionScope $scopeName1
            $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName  -SasToken $sas
            uploadblob $ctxsas

            ## upgrade blob with encrption scope in SAs
            $sas = New-AzStorageContainerSASToken -Name $containerName_es -Permission wrdlt -ExpiryTime (Get-Date).AddDays(6) -Context $ctx -EncryptionScope $scopeName1
            $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName  -SasToken $sas
            $b = Set-AzStorageBlobContent  -Context $ctxsas -File $localSrcFile -Container $containerName_es -Blob block -BlobType Block  -EncryptionScope $scopeName1  -Force  
            $b.BlobProperties.EncryptionScope | should -be $scopeName1

            #Oauth
            $ctxoauth = New-AzStorageContext -StorageAccountName $storageAccountName  
            uploadblob $ctxoauth
        }
        catch
        {
           Remove-AzStorageContainer $containerName_es -Context $ctx -Force
           throw; 
        }
        
        Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName -AllowBlobPublicAccess $false

        Remove-AzStorageContainer $containerName_es -Context $ctx -Force
        $Error.Count | should -be 0
    }   

    It "Upload Download FileTree" {
        $Error.Clear()

        Upload_Download_BlobTree $ctx ((Get-Location).ToString()+"\data") 'Block'
        Upload_Download_BlobTree $ctx ((Get-Location).ToString()+"\data") 'Page'
        Upload_Download_BlobTree $ctx ((Get-Location).ToString()+"\data") 'Append'
        Upload_Download_FileTree $ctx ((Get-Location).ToString()+"\data")

        $Error.Count | should -be 0
    }

    It "partition zone" {
        $Error.Clear()
        
        $resourceGroupName = $globalNode.resourceGroupName
        $name =  $testNode.SelectSingleNode("accountName[@id='1']").'#text'
        $nameZone = $testNode.paritionZone.nameZone
        $key = (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $name)[0].Value
        
        # key
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -StorageAccountKey $key
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $name
        $testctx.StorageAccount.Credentials.IsSharedKey  | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true

        #SAS
        $sas = New-AzStorageContainerSASToken -Context $testctx -Name testcon -Permission r
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -SasToken $sas -Protocol Http
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsSAS  | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true
        
        # anonymous
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -Anonymous -Endpoint "test.com"
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsAnonymous | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true
        
        # Oauth
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -Environment AzureChinaCloud
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsToken | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true

        $PrimaryEndpoint = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $name).PrimaryEndpoints
        
        # key
        $testctx = New-AzStorageContext -StorageAccountName $name -StorageAccountKey $key -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $name
        $testctx.StorageAccount.Credentials.IsSharedKey  | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        Get-AzStorageContainer -Context $ctx -MaxCount 1

        #SAS
        $sas = New-AzStorageContainerSASToken -Context $testctx -Name testcon -Permission r
        $testctx = New-AzStorageContext -SasToken $sas -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsSAS  | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        Get-AzStorageContainer -Context $ctx -MaxCount 1
        
        # anonymous
        $testctx = New-AzStorageContext -Anonymous -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsAnonymous | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        
        # Oauth
        $testctx = New-AzStorageContext -UseConnectedAccount -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table        
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsToken | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        Get-AzStorageContainer -Context $ctx -MaxCount 1

        $Error.Count | should -be 0
    }
    

    It "Blob Tag" -Tag "Totest" {
        $Error.Clear()
        
        # upload blob 
        # only tag
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob -Tag @{"tag3" = "value3"} -Context $ctx -Force
        $b.TagCount | should -Be 1
        #only tag condition
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob2  -Context $ctx -Force #-TagCondition """tag3""='value3'"
        $b.TagCount | should -Be 0
        # tag and tag condition not match, when blob not exist won't fail, if overwrite will fail
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob3 -Tag @{"tag3" = "value3"; "tag2" = "version" }  -Context $ctx -Force #-TagCondition """tag2""='value2'"
        $b.TagCount | should -Be 2
        # tag and tag condition matches 
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob tagtesttodelete -Tag @{"tag3" = "value3"; "tag2" = "value2" }  -Context $ctx -Force # -TagCondition """tag2""='value2'"
        $b.TagCount | should -Be 2

        # Should fail with 412 since TagCondition not match
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob -Tag @{"tag3" = "value3"; "tag2" = "version" } -TagCondition """tag1""='nonevalue'" -Context $ctx -Force -ErrorAction SilentlyContinue
        $Error[0].Exception.Status | Should -Be 412
        $Error.Count | should -be 1
        $Error.Clear()

        # Set/Get Blob tag with tag condition
        $tags = Set-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -Tag @{"tag3" = "value3"; "tag2" = "version" } -TagCondition """tag3""='value3'"
        $tags.Count | should -Be 2
        $tags = Get-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -TagCondition """tag3""='value3'" 
        $tags.Count | should -Be 2

        #Should fail with 412 since TagCondition not match
        Set-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -Tag @{"tag3" = "value3"; "tag2" = "version" } -TagCondition """tag2""='nonevalue'" -ErrorAction SilentlyContinue
        Get-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -TagCondition """tag2""='nonevalue'"  -ErrorAction SilentlyContinue
        $Error[0].Exception.Status | Should -Be 412
        $Error[1].Exception.Status | Should -Be 412
        $Error.Count | should -be 2
        $Error.Clear()

        # Set/Get blob tag with pipeline
        # list blob in contaiener
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx  -IncludeVersion -Prefix testtag -IncludeTag
        $b[0].TagCount | should -Be 2
        $b[0].Tags.Count | should -Be 2
        # Set/Get blob tag to a single blob with pipeline
        $tags = $b[0] | Set-AzStorageBlobTag -Tag @{"tag3" = "value3"}
        $tags.Count | should -Be 1
        $tags = $b[0] | Get-AzStorageBlobTag
        $tags.Count | should -Be 1


        # download blob with tag condition
        $b = Get-AzStorageBlobContent -Destination $localDestFile -Container $containerName -Blob testtagblob -TagCondition """tag3""='value3'" -Context $ctx -Force
        $b[0].TagCount | should -Be 1

        # Should fail with 412 since TagCondition not match
        Get-AzStorageBlobContent -Destination $localDestFile -Container $containerName -Blob testtagblob -TagCondition """tag3""='nonevalue'" -Context $ctx -Force  -ErrorAction SilentlyContinue
        $Error[0].Exception.Status | Should -Be 412
        $Error.Count | should -be 1
        $Error.Clear()

        # list Blob across containers by tag 
        #list with tag match
        $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $ctx 
        $blobs.Count | should -BeGreaterOrEqual 3
        $blobs[0].ContentType | Should -Be $null
        $blobs[0].LastModified | Should -Be $null

        # list with tag match, and get blob properties for each blob (Will be slow as add 1 request for each blob)
        $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression "tag3='value3'" -Context $ctx -GetBlobProperty
        $blobs.Count | should -BeGreaterOrEqual 3
        ($blobs | ?{$_.BlobClient.BlobContainerName -eq $containerName})[0].ContentType  | Should -Not -Be $null
        ($blobs | ?{$_.BlobClient.BlobContainerName -eq $containerName})[0].LastModified| Should -Not -Be $null

        # list blob inside a container with container sas
        $sas = New-AzStorageContainerSASToken -Name $containerName -Context $ctx -Permission f 
        $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $sasctx -Container $containerName
        $blobs.Count | should -Be 3

        # list blobs inside specific containers with specific tag
        $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression "@container='$($containerName)' AND ""tag3""='value3' AND ""tag2""='value2'" -Context $ctx -GetBlobProperty
        $blobs.Count | should -BeGreaterOrEqual 1
        $blobs[0].ContentType | Should -Not -Be $null

        #list blob by tag , and chunk by chunk (with continuation token)
        $MaxReturn = 2
        $Total = 0
        $Token = $Null
        do
            {
                $Blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $ctx -MaxCount $MaxReturn  -ContinuationToken $Token
                $Blobs
                $Total += $Blobs.Count
                if($Blobs.Length -le 0) { Break;}
                $Token = $Blobs[$blobs.Count -1].ContinuationToken;
            }
            While ($Token.NextMarker -ne $Null -and $Token.NextMarker -ne "")
            $Total | should -Be (Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $ctx).count

        # list Blob include Tag in a container
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx -IncludeTag
        $b.Count | should -BeGreaterThan 1
        ($b | ?{ $_.Name -like "testtag*"})[0].Tags.Count | should -BeGreaterOrEqual 1

        # Get single blob with tag, with/without tag condition
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -IncludeTag
        $b.Count | should -Be 1
        $b.Tags.Count | should -BeGreaterOrEqual 1
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -IncludeTag -TagCondition """tag3""='value3'"
        $b.Count | should -Be 1
        $b.Tags.Count | should -BeGreaterOrEqual 1

        #Should fail with 412 since TagCondition not match
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -IncludeTag -TagCondition """tag2""='nonevalue'" -ErrorAction SilentlyContinue
        $Error[0].Exception.Status | Should -Be 412
        $Error.Count | should -be 1
        $Error.Clear()

        #remove Blob with tag condition
        Remove-AzStorageBlob -Container $containerName -Context $ctx -Blob tagtesttodelete -TagCondition """tag3""='value3'"

        #Should fail with 412 since TagCondition not match
        $Error.Clear()
        Remove-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -TagCondition """tag2""='nonevalue'" -ErrorAction SilentlyContinue
        $Error[0].Exception.Status | Should -Be 412
        $Error.Count | should -be 1
        $Error.Clear()


        # Start/stop Blob Copy with tag condition and set tag (stop might fail if copy finish too soon)
        $b = Start-AzStorageBlobCopy -SrcContainer $containerName -Context $ctx -SrcBlob testtagblob -DestContainer $containerName -DestBlob tagcopydest -Tag @{"tag3" = "value3"; "tag2" = "version" }  -TagCondition """tag3""='value3'" -DestTagCondition """tag3""='value3'"
        $b.Name | should -Be  tagcopydest
        $b.TagCount | should -Be 2
        $Error.Count | should -be 0  
        $b | Stop-AzStorageBlobCopy -Force -TagCondition """tag3""='value3'" -ErrorAction SilentlyContinue # very possible fail as copy finish too soon, with error "There is currently no pending copy operation.", If so, this error can be ignored
        (($Error.Count -eq 0) -or ($Error[0].Exception.Message.Contains("AbortCopyFromUri does not support the TagConditions condition(s).")) -or ($Error[0].Exception.Message.Contains("There is currently no pending copy operation."))) | Should -BeTrue
        $Error.Count | should -BeLessOrEqual 1
        $Error.Clear()

        #Should fail with 412 since TagCondition not match
        $b = Start-AzStorageBlobCopy -SrcContainer $containerName -Context $ctx -SrcBlob testtagblob -DestContainer $containerName -DestBlob tagcopydest -Tag @{"tag3" = "value3"; "tag2" = "version" }  -TagCondition """tag2""='nonevalue'" -Force  -ErrorAction SilentlyContinue
        $b = Start-AzStorageBlobCopy -SrcContainer $containerName -Context $ctx -SrcBlob testtagblob -DestContainer $containerName -DestBlob tagcopydest -Tag @{"tag3" = "value3"; "tag2" = "version" }  -DestTagCondition """tag2""='nonevalue'" -Force  -ErrorAction SilentlyContinue
        Stop-AzStorageBlobCopy -Container $containerName -Blob tagcopydest -Force -TagCondition """tag2""='nonevalue'" -Context $ctx  -ErrorAction SilentlyContinue
        $Error[0].Exception.Status | Should -Be 412
        $Error[1].Exception.Status | Should -Be 412
        $Error[2].Exception.Status | Should -Be 412
        $Error.Count | should -be 3
        $Error.Clear()

        # tag sas
        if ($ctx.StorageAccount.Credentials.IsSharedKey -or $ctx.StorageAccount.Credentials.IsToken)
        { 
            #blob sas + t
            $sas = New-AzStorageBlobSASToken -Container $containerName -Context $ctx  -Blob testtagblob -Permission t 
            $sascontext = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            $tags = Get-AzStorageBlobTag -Container $containerName  -Blob testtagblob -Context $sascontext 
            $tags.count | should -BeGreaterOrEqual 1

            #container sas + t
            $sas = New-AzStorageContainerSASToken -Container $containerName -Context $ctx  -Permission t 
            $sascontext = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            $tags = Get-AzStorageBlobTag -Container $containerName  -Blob testtagblob -Context $sascontext 
            $tags.count | should -BeGreaterOrEqual 1
        }

        if ($ctx.StorageAccount.Credentials.IsSharedKey)
        {
            #accountSAS + t ,f
            $sas = New-AzStorageAccountSASToken -Service Blob,Queue,File,Table -ResourceType Service,Container,Object -Context $ctx  -Permission rtxfy
            $sascontext = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            $tags = Get-AzStorageBlobTag -Container $containerName  -Blob testtagblob -Context $sascontext -TagCondition """tag3""='value3'" 
            $tags.count | should -BeGreaterOrEqual 1
            $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context  $sascontext  -GetBlobProperty 
            $blobs.Count | should -BeGreaterOrEqual 1
        }

        $Error.Count | should -be 0

    }

    It "Download Managed Disk"  {
        $Error.Clear()        
        
        # Disk is https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/{SubscriptionId}/resourceGroups/weitry/providers/Microsoft.Compute/disks/weioauthsas_download1G/overview
        $DiskName = "yifantestdisksasoauth" #$testNode.downloadManagedDisk.diskName

        #Generate the SAS Uri to download
        New-AzDiskUpdateConfig -DataAccessAuthMode "AzureActiveDirectory" | Update-AzDisk -ResourceGroupName $resourceGroupName -DiskName $DiskName
        $diskSas = Grant-AzDiskAccess -ResourceGroupName $resourceGroupName -DiskName $DiskName -DurationInSecond 86400 -Access 'Read'
        $sasUri = $diskSas.AccessSAS

        # Download
        $blob = Get-AzStorageBlobContent -Uri $sasUri  -Destination $localDestFile -Force # -debug 
        $blob.Length | should -Be (Get-Item $localDestFile).Length

        #revoke the Sas Uri access
        Revoke-AzDiskAccess -ResourceGroupName $resourceGroupName -DiskName $DiskName

        $Error.Count | should -be 0
    }
    
    It "HNS softdelete"  {
        $Error.Clear()
        
        $rgname = $globalNode.resourceGroupName
        $accountName = $testNode.SelectSingleNode("accountName[@id='3']").'#text'
        $ctxhns = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName).Context

        $localSrcFile = ".\data\testfile_1K_0" 
        $filesystemName = "retestsoftdelete"

        # enable soft delete (on blob, also on hns)
        Enable-AzStorageDeleteRetentionPolicy -RetentionDays 1  -Context $ctxhns 

        # create file system and items
        New-AzDatalakeGen2FileSystem -Name $filesystemName -Context $ctxhns        
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Directory -Path dir0 
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Directory -Path dir0/dir0
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Directory -Path dir0/dir1
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Directory -Path dir0/dir2
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Path dir0/dir1/file2 -Source $localSrcFile -Force
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Path dir0/dir2/file3 -Source $localSrcFile -Force
        New-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force 

        $items = Get-AzDataLakeGen2ChildItem -Context $ctxhns -FileSystem $filesystemName -Recurse
        $items.Count | should -be 8

        Remove-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Force -Path dir0/dir1/file1
        Remove-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Force -Path dir0/dir2/file3 
        Remove-AzDataLakeGen2Item -Context $ctxhns -FileSystem $filesystemName -Force -Path dir0/dir2        

        $items = Get-AzDataLakeGen2ChildItem -Context $ctxhns -FileSystem $filesystemName -Recurse
        $items.Count | should -be 4

        $items = Get-AzDataLakeGen2DeletedItem -Context $ctxhns -FileSystem $filesystemName -Path dir0/dir2
        $items.Count | should -be 2

        $items = Get-AzDataLakeGen2DeletedItem -Context $ctxhns -FileSystem $filesystemName 
        $items.Count | should -be 3

        # item[0] should be dir0/dir1/file1
        $items0 = $items[0] | Restore-AzDataLakeGen2DeletedItem 
        $items0.Path | should -be $items[0].Path
        $items0.File.Exists() | should -be $true
        
        # item[1] should be dir0/dir2
        $items1 = Restore-AzDataLakeGen2DeletedItem -Context $ctxhns -FileSystem $filesystemName  -Path $items[1].Path -DeletionId $items[1].DeletionId 
        $items1.Path | should -be $items[1].Path
        $items1.Directory.Exists() | should -be $true

        $items = Get-AzDataLakeGen2DeletedItem -Context $ctxhns -FileSystem $filesystemName 
        $items.Count | should -be 1

        $items = Get-AzDataLakeGen2ChildItem -Context $ctxhns -FileSystem $filesystemName -Recurse
        $items.Count | should -be 7

        Remove-AzDatalakeGen2FileSystem -Name $filesystemName -Context $ctxhns -Force

        $Error.Count | should -be 0
    }

    It "Cross type blob copy"  -Tag "crossblobcopy" {
        $Error.Clear()     
        
        $blobTypes = @("Block", "Page", "Append")

        $account1 = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name "testblobcopy1" -SkuName Standard_LRS -Location eastus2
        $account2 = New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name "testblobcopy2" -SkuName Standard_LRS -Location eastus2
        
        Update-AzStorageBlobServiceProperty -ResourceGroupName $resourceGroupName -StorageAccountName "testblobcopy1" -IsVersioningEnabled $true 

        $ctx11 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name "testblobcopy1").Context 
        $ctx12 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name "testblobcopy2").Context 

        $ctxoauth11 = New-AzStorageContext -StorageAccountName "testblobcopy1"
        $ctxoauth12 = New-AzStorageContext -StorageAccountName "testblobcopy2"

        $containerSAS = New-AzStorageContainerSASToken -Name $containerName -Permission  rwdl -ExpiryTime (Get-Date).AddDays(100) -Context $ctx11
        $sasctx = New-AzStorageContext -StorageAccountName $ctx11.StorageAccountName -SasToken $containerSAS

        $blobCopySrcFile10M = ".\data\testfile_10M"
        $blobCopySrcFile300M = ".\data\testfile_300M"

        try {
            Remove-AzStorageContainer -Name $containerName -Context $ctx11 -Force -ErrorAction Stop
            Remove-AzStorageContainer -Name $containerName -Context $ctx12 -Force -ErrorAction Stop
        } 
        catch 
        {
            "Containers don't exist"
        }

        # Create the containers and upload the src blobs 
        if ($true) { 
            New-AzStorageContainer -Name $containerName -Context $ctx11
            New-AzStorageContainer -Name $containerName -Context $ctx12

            foreach ($srcType in $blobTypes) {
                $smallSrcBlob = Set-AzStorageBlobContent -File $blobCopySrcFile10M -Container $containerName -Blob "$($srctype)SmallSource" -Context $ctx11 -BlobType $srctype -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value2"} -Force
                $largeSrcBlob = Set-AzStorageBlobContent -File $blobCopySrcFile300M -Container $containerName -Blob "$($srctype)LargeSource" -Context $ctx11 -BlobType $srctype -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value2"} -Force
            }
        }
        
        # tests for 9 directions of blob type conversions 
        foreach ($srcType in $blobTypes) {
            foreach ($destType in $blobTypes) { 
                # Small src file. Key ctx
                $smallDestBlob = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srctype)SmallSource" -Context $ctx11 -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)SmallDest" -DestContext $ctx12 -DestBlobType $destType -Force
                $smallDestBlob.Name | Should -Be "$($srctype)TO$($desttype)SmallDest"
                $smallDestBlob.BlobProperties.ContentType | Should -Be "image/jpeg"
                $smallDestBlob.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $smallDestBlob.BlobProperties.Metadata.Count | Should -Be 2 
                $smallDestBlob.BlobBaseClient.AccountName | Should -Be "testblobcopy2"

                # compare content 
                $smallDestBlob | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                $path1 = (Get-Location).ToString()+$blobCopySrcFile10M
                $path2 = (Get-Location).ToString()+$localDestFile
                CompareFileMD5 $path1 $path2
                del $localDestFile
                $smallDestBlob | Remove-AzStorageBlob

                # Small src file. Sas ctx
                $smallDestBlob2 = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srctype)SmallSource" -Context $sasctx -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)SmallDest2"  -DestBlobType $destType -Force
                $smallDestBlob2.Name | Should -Be "$($srctype)TO$($desttype)SmallDest2"
                $smallDestBlob2.BlobProperties.ContentType | Should -Be "image/jpeg"
                $smallDestBlob2.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $smallDestBlob2.BlobProperties.Metadata.Count | Should -Be 2 
                $smallDestBlob2.BlobBaseClient.AccountName | Should -Be "testblobcopy1"
                
                $smallDestBlob2 | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                CompareFileMD5 $path1 $path2
                del $localDestFile
                $smallDestBlob2 | Remove-AzStorageBlob

                # Small src file. oauth ctx 
                $smallDestBlob3 = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srctype)SmallSource" -Context $ctxoauth11 -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)SmallDest3" -DestContext $ctxoauth12  -DestBlobType $destType -Force
                $smallDestBlob3.Name | Should -Be "$($srctype)TO$($desttype)SmallDest3"
                $smallDestBlob3.BlobProperties.ContentType | Should -Be "image/jpeg"
                $smallDestBlob3.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $smallDestBlob3.BlobProperties.Metadata.Count | Should -Be 2 
                $smallDestBlob3.BlobBaseClient.AccountName | Should -Be "testblobcopy2"

                $smallDestBlob3 | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                CompareFileMD5 $path1 $path2
                del $localDestFile
                $smallDestBlob3 | Remove-AzStorageBlob

                $largeDestBlob = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srcType)LargeSource" -Context $ctx11 -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)BigDest" -DestContext $ctxoauth11 -DestBlobType $destType -Force
                $largeDestBlob.Name | Should -Be "$($srcType)TO$($destType)BigDest"
                $largeDestBlob.BlobProperties.ContentType | Should -Be "image/jpeg"
                $largeDestBlob.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile300M).Length
                $largeDestBlob.BlobProperties.Metadata.Count | Should -Be 2 
                $largeDestBlob.BlobBaseClient.AccountName | Should -Be "testblobcopy1"

                $largeDestBlob | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                $path1 = (Get-Location).ToString()+$blobCopySrcFile300M
                CompareFileMD5 $path1 $path2
                del $localDestFile
                $largeDestBlob | Remove-AzStorageBlob
            }
        }

        # Block to block with access tier and rehydrate priority set 
        $blockToBlock1 = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "BlockSmallSource" -Context $ctx11 -DestContainer $containerName -DestBlob "BlockToBlockWithAccessTier" -DestContext $ctx12 -DestBlobType Block -StandardBlobTier "Cool" -RehydratePriority High -Force
        $blockToBlock1.AccessTier | Should -Be "Cool"

        # blob version 
        $smallSrcBlob = Set-AzStorageBlobContent -File $blobCopySrcFile10M -Container $containerName -Blob "$($srctype)SmallSource" -Context $ctx11 -BlobType $srctype -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value2"} -Force
        $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx11 -IncludeVersion -Prefix "$($srctype)SmallSource"
        $blobVersion = $blobs[1]
        $destBlob = $blobVersion | Copy-AzStorageBlob -DestContainer $containerName -DestBlob "blobVersionToBlock" -DestBlobType Block -DestContext $ctx12 -Force
        $destBlob.Name | Should -Be "blobVersionToBlock"

        Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name "testblobcopy1" -Force
        Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name "testblobcopy2" -Force

        $Error.Count | should -be 0
    }

    
    It "File cmdlet pipeline - for track2 migration"  {
        $Error.Clear() 

        $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context

        $sas = New-AzStorageAccountSASToken -Service File -ResourceType Container,Object,Service -Permission rwdl -ExpiryTime (Get-Date).AddDays(6) -Context $ctx
        $ctxaccountsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas

        # All following File request will run with RequestIntent=Backup 
        $shareName = GetRandomContainerName
        $shareName2 = $shareName +2
        $shareName3 = $shareName +3

        # Prepare data
        $s = New-AzStorageShare -Name $shareName -Context $ctx

        New-AzStorageDirectory -ShareName $shareName -Path dir1 -Context $ctx 
        New-AzStorageDirectory -ShareName $shareName -Path dir1/dir2 -Context $ctx 
        Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctx -Force
        Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path testfile -Context $ctx -Force

        $s.ShareClient.CreateSnapshot()

        # create Share
        $share2 = New-AzStorageShare -Name $shareName2 -Context $ctx

        # Get share 
        $shares = Get-AzStorageShare -Context $ctx
        $shares.count | should -BeGreaterOrEqual 3
        $s = Get-AzStorageShare -Name $shareName -Context $ctx
        $s.Name | should -be $shareName


        ## snapshot ##
        $shareSnapshot = $s.ShareClient.CreateSnapshot()
        $ss = (Get-AzStorageShare -Context $ctx | ?{$_.IsSnapshot -and $_.Name -eq $shareName}) |Select-Object -First 1


        ### Delete 
        $share2 = Get-AzStorageShare -Name $shareName2 -Context $ctx
        Set-AzStorageFileContent  -ShareName $shareName2 -Source $localSrcFile -Path testfile -Context $ctx -Force

        Remove-AzStorageShare -Share $share2.ShareClient -Force -Context $ctx
        $share2.ShareClient.Exists().Value | should -be $false

        $share3 = New-AzStorageShare -Name $shareName3 -Context $ctxaccountsas
        $shareSnapshot3 = $share3.ShareClient.CreateSnapshot()
        Remove-AzStorageShare -Name $shareName3 -IncludeAllSnapshot -Context $ctx
        $share3.ShareClient.Exists().Value | should -be $false


        # delete share snapshot fail with -IncludeAllSnapshot
        Remove-AzStorageShare -Share $ss.ShareClient  -IncludeAllSnapshot -ErrorAction SilentlyContinue -Context $ctx # Should fail 
        $Error.Count | should -BeLessOrEqual 1
        $Error[0].Exception.Message| should -BeLike "*'IncludeAllSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share snapshot*"
        $Error.Clear()

        # set share quota
        $sq = $ss | Set-AzStorageShareQuota -Quota 4096
        $sq.ShareProperties.QuotaInGB | should -be 4096
        $sq = Set-AzStorageShareQuota -Name $shareName -Context $ctx -Quota 1024
        $sq.ShareProperties.QuotaInGB | should -be 1024
        $sq = Set-AzStorageShareQuota -ShareClient $s.ShareClient -Quota 2048 -Context $ctx
        $sq.ShareProperties.QuotaInGB | should -be 2048
        $sq = Set-AzStorageShareQuota -Name $shareName -Quota 1024  -Context $ctx 
        $sq.ShareProperties.QuotaInGB | should -be 1024

        ## ACCESS POLICY
        New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy 123 -Permission rwdl -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(200)
        New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy 1234  -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(200) 
        New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy abc -Permission rwdlc 
        New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy abcd -Permission rwdlc -ExpiryTime (Get-Date).AddDays(100)

        $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
        $policies.Count | should -be 4    

        Set-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy abc -Permission r
        $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
        $policies.Count | should -be 4
        ($policies | ?{ $_.Policy -eq "abc"}).Permissions | should -be r 
    
        Remove-AzStorageShareStoredAccessPolicy -ShareName $shareName  -Policy abc -PassThru  -Context $ctx
        $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
        $policies.Count | should -be 3
        Remove-AzStorageShareStoredAccessPolicy -ShareName $shareName  -Policy 1234 -Context $ctx 
        $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
        $policies.Count | should -be 2
    
        $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Policy abcd -Context $ctx | Remove-AzStorageShareStoredAccessPolicy -ShareName $shareName  -Context $ctx 


        # Share SAS
        $saslist = New-Object System.Collections.Generic.List[System.String]
        $saslist.Add((New-AzStorageShareSASToken -ShareName $shareName -Policy 123  -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -Context $ctx))
        $saslist.Add((New-AzStorageShareSASToken -ShareName $shareName -Permission rl -Context $ctx ))
        $saslist.Add((New-AzStorageShareSASToken -ShareName $shareName -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOrHttp -Context $ctx))
        foreach ($sas in $saslist)
        {
            $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            Get-AzStorageFile -ShareName $shareName -Context $sasctx
        }

        $sasUri = New-AzStorageShareSASToken -ShareName $shareName -Permission rlwd -IPAddressOrRange "12.3.4-5.6.7.8" -Protocol HttpsOnly -Context $ctx -FullUri
        $sasUri | should -BeLike "$($ctx.StorageAccount.FileEndpoint)*$($shareName)*sp=rwdl*sig=*"

        #File SAS
        $f1 = Get-AzStorageFile -ShareName $shareName  -Path dir1/test1 -Context $ctx 
        $fs1 = $ss | Get-AzStorageFile  -Path dir1/test1 

        $saslist = New-Object System.Collections.Generic.List[System.String]

        $saslist.Add((New-AzStorageFileSASToken -ShareName $shareName -Path $f1.ShareFileClient.Path -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -ExpiryTime 2050-10-10 -Context $ctx))
        $saslist.Add((New-AzStorageFileSASToken -ShareName $shareName -Path $f1.ShareFileClient.Path -Policy 123 -Protocol HttpsOnly -IPAddressOrRange "0.0.0.0-255.255.255.255" -Context $ctx ))
        # $saslist.Add(($f1 | New-AzStorageFileSASToken -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -ExpiryTime 2050-10-10 -Context $ctx ))
        # $saslist.Add(($f1 | New-AzStorageFileSASToken -Policy 123 -Protocol HttpsOnly -IPAddressOrRange "0.0.0.0-255.255.255.255" -Context $ctx))
        # $saslist.Add(($fs1 | New-AzStorageFileSASToken -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -ExpiryTime 2050-10-10 -Context $ctx)) 

        foreach ($sas in $saslist)
        {
            $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            Get-AzStorageFile -ShareName $shareName -Path $f1.ShareFileClient.Path -Context $sasctx
        }

        # Directory

        $sas = $ss | New-AzStorageShareSASToken -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly 
        $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        $d = Get-AzStorageFile -ShareName $shareName -Context $sasctx

        $d2 = $s | New-AzStorageDirectory -Path dir2 
        $d2.ShareDirectoryClient.Path | should -be dir2

        $d2 = Get-AzStorageFile -ShareName $shareName -Path dir2 -Context $ctx
        $d3 = $d2| New-AzStorageDirectory -Path dir3
        $d3.ShareDirectoryClient.Path | should -be dir2/dir3
        Remove-AzStorageDirectory -ShareDirectoryClient $d3.ShareDirectoryClient -Context $ctx

        $d3 = New-AzStorageDirectory -ShareName $shareName -Path dir2/dir3 -Context $sasctx 
        $d3.ShareDirectoryClient.Path | should -be dir2/dir3

        $d4 = New-AzStorageDirectory -ShareDirectoryClient $d2.ShareDirectoryClient -Path dir4 -Context $ctx
        $d4.ShareDirectoryClient.Path | should -be dir2/dir4 
    
        $d5 = New-AzStorageDirectory -ShareName $shareName -Path dir2/dir5 -Context $ctx
        $d5.ShareDirectoryClient.Path | should -be dir2/dir5
    
        $d = Get-AzStorageFile -ShareName $shareName -Context $sasctx
        $ds = $d | ?{$_.Name -eq "dir2"} | Get-AzStorageFile
        $ds.Count | should -BeGreaterOrEqual 3

        Remove-AzStorageDirectory -ShareName $shareName -Path dir2/dir3 -Context $ctx 
        $d4 | Remove-AzStorageDirectory -Context $ctx 
        Remove-AzStorageDirectory -ShareClient $s.ShareClient -Path dir2/dir5 -Context $ctx
    
        $ds = $d | ?{$_.Name -eq "dir2"} | Get-AzStorageFile
        $ds.Count | should -Be 0

        $s | Remove-AzStorageDirectory -Path dir2 
        $d2.ShareDirectoryClient.Exists().value | should -be $false

        # File remove
        # remove by manul parameter    
        $f = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx  
        $f.ShareFileClient.Exists().value | should -be $true

        $f = Remove-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx -PassThru    
        $f.ShareFileClient.Exists().value | should -be $false
        Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctx -Force
        $f.ShareFileClient.Exists().value | should -be $true

        #remove by file pipeline
        $f | Remove-AzStorageFile  
        $f.ShareFileClient.Exists().value | should -be $false
        Set-AzStorageFileContent -ShareClient $s.ShareClient -Source $localSrcFile -Path dir1/test1  -Force -Context $ctx
        $f.ShareFileClient.Exists().value | should -be $true

        Remove-AzStorageFile -ShareFileClient $f.ShareFileClient -Context $ctx    
        $f.ShareFileClient.Exists().value | should -be $false 
        $dir1 = Get-AzStorageFile -ShareName $shareName -Path dir1 -Context $ctx
        Set-AzStorageFileContent -ShareDirectoryClient $dir1.ShareDirectoryClient -Source $localSrcFile -Path test1 -Force -Context $ctx
        $f.ShareFileClient.Exists().value | should -be $true

        # remove by dir pipeline
        $s | Get-AzStorageFile -Path dir1 | Remove-AzStorageFile -Path test1  -PassThru
        $f.ShareFileClient.Exists().value | should -be $false
        Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctx -Force
        $f.ShareFileClient.Exists().value | should -be $true

        Remove-AzStorageFile -ShareDirectoryClient $dir1.ShareDirectoryClient  -Path test1  -PassThru -Context $ctx
        $f.ShareFileClient.Exists().value | should -be $false
        $dir1 | Set-AzStorageFileContent -Source $localSrcFile -Path test1 -Force
        $f.ShareFileClient.Exists().value | should -be $true
    
        # remove by share pipeline
        $s | Remove-AzStorageFile -Path dir1/test1  -PassThru
        $f.ShareFileClient.Exists().value | should -be $false
        $dir1 | Set-AzStorageFileContent -Source $localSrcFile -Path test1 -Force
        $f.ShareFileClient.Exists().value | should -be $true

        Remove-AzStorageFile -ShareClient $s.ShareClient  -Path dir1/test1  -PassThru -Context $ctx
        $f.ShareFileClient.Exists().value | should -be $false
        $dir1 | Set-AzStorageFileContent -Source $localSrcFile -Path test1 -Force
        $f.ShareFileClient.Exists().value | should -be $true

        # remove file from snapshot should fail
        $Error.Count | should -Be 0
        $ss  | Remove-AzStorageFile -Path dir1/test1  -PassThru -ErrorAction SilentlyContinue # Should fail 
        $Error.Count | should -BeLessOrEqual 1
        $Error[0].Exception.Message| should -BeLike "*Value for one of the query parameters specified in the request URI is invalid.*"
        $Error.Clear()

        # File Copy

        ### prepare blob

        # manual parameters

        # Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force # will fail, aligne with before
    
        $Error.Count | should -Be 0
        New-AzStorageContainer -Name $shareName -Context $ctx -ErrorAction SilentlyContinue
        $b = Set-AzStorageblobContent -Container $shareName -File $localSrcFile -blob testblob -Context $ctx -Force
        New-AzStorageShare -Name $shareName -Context $ctx2 -ErrorAction SilentlyContinue
        New-AzStorageDirectory -ShareName $shareName -Path dir1 -Context $ctx2 -ErrorAction SilentlyContinue
        $Error.Clear()

    
        $fsrc = $s | Get-AzStorageFile -Path dir1/test1 -Context $ctx 
        $f = Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -DestContext $ctx2 -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -be $fsrc.Length
        $f = Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -be $fsrc.Length

        $f = Start-AzStorageFileCopy -SrcContainerName  $shareName -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -DestContext $ctx2 -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -be $b.Length
        $f = Start-AzStorageFileCopy -SrcContainerName  $shareName -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length



        # from file object 
        $f1 = $ss | Get-AzStorageFile -Path dir1/test1 -Context $ctx 
        $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/copydest -Context $ctx 
        # fail since not dest context
        #$f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force
        #Start-AzStorageFileCopy -SrcFile $f1.CloudFile  -DestShareName $shareName -DestFilePath dir1/copydest -Force
        # fail since not dest context
        #$f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 
        #Start-AzStorageFileCopy -SrcFile $f1.CloudFile  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 

        # success
        $f2 = $f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length

        $f2 = Start-AzStorageFileCopy -SrcFile $f1.ShareFileClient  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length

        $fdest = Get-AzStorageFile -ShareName $shareName -Path dir1/copydest -Context  $ctx2
        $f2 = Start-AzStorageFileCopy -SrcFile $f1.ShareFileClient  -DestFile $fdest.ShareFileClient -Force -DestContext $ctx   
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length
         
        $f2 = $f1  | Start-AzStorageFileCopy  -DestFile $fdest.ShareFileClient -Force -DestContext $ctx
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length

        # From Share object
        $f2 = Start-AzStorageFileCopy -SrcShare $s.ShareClient -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be (Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx).Length

        # copy from file in share snapshot
        $f2 = Start-AzStorageFileCopy -SrcShare $ss.ShareClient -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
        $copystatus = $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length  
        #check copy status
        $srcfile = Get-AzStorageFile -ShareClient $ss.ShareClient -Path dir1/test1 -Context $ctx         
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($srcfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $srcfile.Length
        $copystatus.BytesCopied | should -be $srcfile.Length

        # From blob object
        $b = Get-AzStorageBlob -Containe $shareName -Blob testblob -Context $ctx 
        $bs = $b.ICloudBlob.Snapshot()
        $bs.FetchAttributes()
        # fail since not dest context
        #$b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force
        #Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force
        # fail since not dest context
        #$b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 
        #Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 
        # success
        $f = $b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length

        $f = Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length
        
        $fdest = Get-AzStorageFile -ShareName $shareName -Path dir1/copydest -Context  $ctx2
        $f = Start-AzStorageFileCopy -SrcBlob $bs -DestFile $fdest.ShareFileClient -Force -DestContext $ctx
        $copystatus = $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $bs.Properties.Length
        #check copy status
        $srcfile = Get-AzStorageFile -ShareClient $ss.ShareClient -Path dir1/test1 -Context $ctx        
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($bs.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bs.Properties.Length
        $copystatus.BytesCopied | should -be $bs.Properties.Length

        # from container object
        $c = Get-AzStorageContainer -Name  $shareName -Context $ctx 
        $f = Start-AzStorageFileCopy -SrcContainer $c.CloudBlobContainer  -SrcBlobName testblob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length
        # from Uri
        $uri1 = New-AzStorageFileSASToken -ShareName $shareName -Path dir1/test1 -Permission rwdl -FullUri -Context $ctx 
        $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        #$f.FileProperties.ContentLength | should -Be $f1.Length

        $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestFile $fdest.ShareFileClient -Force -DestContext $ctx
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"

        $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"

        # Get copy state
        ## Prepare a big blob
        $biglocalfile = $localBigSrcFile
        $bigfile = Set-AzStorageFileContent -ShareName $shareName -Source $biglocalfile -Path bigfile -Context $ctx2 -Force -PassThru

        ## start copy     
        $bigdestfile = Start-AzStorageFileCopy -SrcFile  $bigfile.ShareFileClient -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force

        # get copy status in different ways
        $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/bigcopydest -Context $ctx 
        $fd.FileProperties.CopyStatus | should -be Pending
        # $fd.FileProperties.CopySource | should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"

        $copystatus = $bigdestfile | Get-AzStorageFileCopyState
        $copystatus.Status | should -be Pending
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length

        $copystatus = Get-AzStorageFileCopyState -ShareName $shareName  -FilePath dir1/bigcopydest -Context $ctx 
        $copystatus.Status | should -be Pending
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length

        $copystatus = Get-AzStorageFileCopyState -ShareFileClient $bigdestfile.ShareFileClient -Context $ctx
        $copystatus.Status | should -be Pending
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length

        # wait for complete
        $copystatus = $fd | Get-AzStorageFileCopyState -WaitForComplete
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -be $bigfile.Length
    
        $bigdestfile = Start-AzStorageFileCopy -SrcFile  $bigfile.ShareFileClient -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
        Get-AzStorageFileCopyState -ShareName $shareName  -FilePath dir1/bigcopydest -Context $ctx -WaitForComplete
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -be $bigfile.Length

        $fd | Remove-AzStorageFile 


        # Stop copy 
        # by pipeline
        Start-AzStorageFileCopy -SrcFile  $bigfile.ShareFileClient -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
        $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/bigcopydest -Context $ctx 
        ($fd | Get-AzStorageFileCopyState).Status | should -be Pending
        $stopmessage = $fd | Stop-AzStorageFileCopy -CopyId $fd.FileProperties.CopyId
        $stopmessage | should -BeLike "Stopped the copy task on file '$($fd.ShareFileClient.Uri.ToString())' successfully."
        $copystatus = $fd | Get-AzStorageFileCopyState
        $copystatus.Status | should -be Aborted
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length 

        # manually
        Start-AzStorageFileCopy -SrcFile  $bigfile.ShareFileClient -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
        ($fd | Get-AzStorageFileCopyState).Status | should -be Pending
        $stopmessage = Stop-AzStorageFileCopy -ShareName $shareName  -FilePath dir1/bigcopydest -Context $ctx -Force
        $stopmessage | should -BeLike "Stopped the copy task on file '$($fd.ShareFileClient.Uri.ToString())' successfully."
        $copystatus = $fd | Get-AzStorageFileCopyState
        $copystatus.Status | should -be Aborted
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length 

        # by file object
        Start-AzStorageFileCopy -SrcFile  $bigfile.ShareFileClient -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
        ($fd | Get-AzStorageFileCopyState).Status | should -be Pending
        $stopmessage = Stop-AzStorageFileCopy -ShareFileClient $fd.ShareFileClient -Context $ctx -Force
        $stopmessage | should -BeLike "Stopped the copy task on file '$($fd.ShareFileClient.Uri.ToString())' successfully."
        $copystatus = $fd | Get-AzStorageFileCopyState
        $copystatus.Status | should -be Aborted
        # $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bigfile.Length
        $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length 

        # List file handles
        #List from share
        Get-AzStorageFileHandle -ShareName $shareName -Context $ctx
        Get-AzStorageFileHandle -ShareName $shareName -Context $ctx -Recursive        
        Get-AzStorageFileHandle -ShareName $shareName -Context $ctx -Recursive -Skip 1 -First 3
        $share = Get-AzStorageShare -Name $shareName -Context $ctx
        $share | Get-AzStorageFileHandle  -Recursive 
        $share.ShareClient | Get-AzStorageFileHandle  -Recursive 

        # list from dir
        Get-AzStorageFileHandle -ShareName $shareName -Path dir1 -Context $ctx        
        Get-AzStorageFileHandle -ShareName $shareName -Path dir1 -Context $ctx -Recursive
        $dir = Get-AzStorageFile -ShareName $shareName -Path dir1 -Context $ctx
        $dir | Get-AzStorageFileHandle  -Recursive 
        $dir.ShareDirectoryClient | Get-AzStorageFileHandle  -Recursive 

        #list from file
        Get-AzStorageFileHandle  -ShareName $shareName -Path dir1/test1  -Context $ctx
        Get-AzStorageFileHandle  -ShareName $shareName -Path dir1/test1  -Context $ctx -Skip 1 -First 1
        $file = Get-AzStorageFile -ShareName $shareName -Path dir1/test1  -Context $ctx
        $file | Get-AzStorageFileHandle  -Recursive 
        $file.ShareFileClient | Get-AzStorageFileHandle  -Recursive 


        # close file handles
        $h =Get-AzStorageFileHandle -ShareName $containerName -Context $ctx -Recursive   
        $h.Count | should -BeGreaterOrEqual 0


        # From Share - close all
        Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Context $ctx -PassThru
        Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Recursive -Context $ctx
        $share = Get-AzStorageShare -Name $shareName -Context $ctx
        $share | Close-AzStorageFileHandle  -Recursive -CloseAll -PassThru
        $share.ShareClient | Close-AzStorageFileHandle  -CloseAll -PassThru

        # From Dir - close all
        Close-AzStorageFileHandle -ShareName $shareName -Path dir1 -CloseAll -Context $ctx
        Close-AzStorageFileHandle -ShareName $shareName -Path dir1 -CloseAll -Recursive -Context $ctx
        $dir = Get-AzStorageFile -ShareName $shareName -Path dir1 -Context $ctx
        $dir | Close-AzStorageFileHandle  -CloseAll 
        $dir.ShareDirectoryClient | Close-AzStorageFileHandle  -Recursive -CloseAll -PassThru
        
        # From file - close all
        Close-AzStorageFileHandle -ShareName $shareName -Path dir1/test1 -CloseAll -Context $ctx -PassThru
        $file = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx
        $file | Close-AzStorageFileHandle  -CloseAll  
        $file.ShareFileClient | Close-AzStorageFileHandle  -CloseAll 

        # From Share - Close single
        if ($h.count -ge 5)
        {
            $h[0] |  Close-AzStorageFileHandle -ShareName $shareName -Context $ctx
            $h[1] |  Close-AzStorageFileHandle -ShareClient $share.ShareClient -Context $ctx
            $share = Get-AzStorageShare -Name $shareName -Context $ctx
            $share |  Close-AzStorageFileHandle -FileHandle $h[2] 
            $share.ShareClient |  Close-AzStorageFileHandle -FileHandle $h[3] 
            Close-AzStorageFileHandle -ShareName $shareName -Context $ctx -FileHandle $h[4] 
        }

        # TEst continueation token
        Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Recursive -Context $ctx -PassThru
        Close-AzStorageFileHandle -ShareName $shareName -Path dir1 -CloseAll -Recursive -Context $ctx -PassThru

        # Download file

        $share = Get-AzStorageShare -Name $shareName -Context $ctx
        $snapshot = $share.ShareClient.CreateSnapshot().value

        # Set-AzStorageFileContent -ShareName $containerName -Path 0size -Source C:\temp\0  -Context $ctx -force 
        
        $file = Get-AzStorageFileContent -Destination $localDestFile -ShareName $shareName -Path $bigfile.ShareFileClient.Path -CheckMd5 -Context $ctx2 -force -PassThru
        CompareFileFileMD5 (get-item $localDestFile).FullName $file

        # del $localDestFile

        # share pipeline
        $sharesnapshot = Get-AzStorageShare -Name $shareName -Context $ctx -SnapshotTime $snapshot.Snapshot        
        $file = $sharesnapshot | Get-AzStorageFileContent -Destination $localDestFile -Path dir1/test1  -PassThru   -force
        CompareFileFileMD5 $localDestFile $file        
        $file = Get-AzStorageFileContent -Destination $localDestFile -ShareClient $sharesnapshot.ShareClient -Path dir1/test1 -PassThru -force -Context $ctx
        CompareFileFileMD5 $localDestFile $file

        #dir pipeline
        $dir = $share | Get-AzStorageFile -Path dir1
        $file = $dir | Get-AzStorageFileContent -Destination $localDestFile -Path test1 -force -PassThru
        CompareFileFileMD5 $localDestFile $file  

        del $localDestFile

        $file = $dir.ShareDirectoryClient | Get-AzStorageFileContent -Destination $localDestFile -Path test1 -force -PassThru -Context $ctx
        CompareFileFileMD5 $localDestFile $file  

        #file pipeline
        $file = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx  
        $file = Get-AzStorageFileContent -Destination $localDestFile -ShareFileClient $file.ShareFileClient -force -PassThru -Context $ctx
        CompareFileFileMD5 $localDestFile $file      
        $file = $file | Get-AzStorageFileContent -Destination $localDestFile  -force -PassThru
        CompareFileFileMD5 $localDestFile $file 


        $Error.Count | should -be 0
    }

    It "File cmdlets context issue fix"  -Skip {
        # With Track2 objects, context is required, so the tests are unnecessary
        $Error.Clear()        

        $accountname = GetRandomAccountName + "fc1"
        $currentctx = (New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountname -SkuName Standard_LRS -Location eastus).Context
        Set-AzCurrentStorageAccount -Context $currentctx

        $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context
        $sharename = GetRandomContainerName

        $s = New-AzStorageShare -Name $sharename -Context $ctx2 
        $d = New-AzStorageDirectory -ShareClient $s.ShareClient -Path dir1 -Context $ctx2
        $d.Context.FileEndPoint | Should -BeLike *$storageAccountName2*

        $f = Set-AzStorageFileContent -ShareDirectoryClient $d.ShareDirectoryClient -Source .\data\testfile_1K_0 -Path test1 -PassThru -Force -Context $ctx2
        $f.Context.FileEndPoint | Should -BeLike *$storageAccountName2*

        $s = Set-AzStorageShareQuota -Share $s.CloudFileShare -Quota 100 
        $s.Context.FileEndPoint | should -BeLike *$storageAccountName2*

        $f = Get-AzStorageFileContent -File $f.CloudFile -Destination .\created\test1 -PassThru -Force
        $f.Context.FileEndPoint | Should -BeLike *$storageAccountName2*

        $f = Get-AzStorageFile -Directory $d.CloudFileDirectory -Path test1 
        $f.Context.FileEndPoint | Should -BeLike *$storageAccountName2*

        $f = Remove-AzStorageFile -File $f.CloudFile -PassThru 
        $f.Context.FileEndPoint | Should -BeLike *$storageAccountName2*

        $d = Remove-AzStorageDirectory -Directory $d.CloudFileDirectory -PassThru
        $d.Context.FileEndPoint | Should -BeLike *$storageAccountName2*

        $s = Remove-AzStorageShare -Share $s.CloudFileShare -PassThru -Force
        $s.Context.FileEndPoint | should -BeLike *$storageAccountName2*

        Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountname -Force -AsJob

        $Error.Count | should -be 0
    }

    It "List blob with leading slashes"  {
        $Error.Clear()     

        $accountname = GetRandomAccountName + "slash"
        $currentctx = (New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountname -SkuName Standard_LRS -Location eastus).Context

        $containername1 = GetRandomContainerName
        New-AzStorageContainer -Name $containername1 -Context $currentctx 

        $destblobname = "///test1"
        $destblobname2 = "test2"
        $blob = Set-AzStorageBlobContent -File $localSmallSrcFile -Container $containername1 -Blob $destblobname -Context $currentctx -Force
        $blob.Name | Should -Be $destblobname
        $blob = Set-AzStorageBlobContent -File $localSmallSrcFile -Container $containername1 -Blob $destblobname2 -Context $currentctx -Force
        $blob.Name | Should -Be $destblobname2

        $blobs = Get-AzStorageBlob -Container $containername1 -Context $currentctx 
        $blobs.Count | Should -Be 2 
        $blobs.Name | Should -Contain $destblobname

        $blobs = Get-AzStorageBlob -Container $containername1 -Prefix "/" -Context $currentctx 
        $blobs.Count | Should -Be 1 
        $blobs[0].Name | Should -Be $destblobname

        $blobs[0] | Remove-AzStorageBlob
        
        Remove-AzStorageContainer -Name $containername1 -Context $currentctx -Force 

        Remove-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountname -Force -AsJob

        $Error.Count | should -be 0
    }

    It "Rename file and directory"  {
        $Error.Clear()     

        $accountname = GetRandomAccountName + "rename"
        $currentctx = (New-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountname -SkuName Standard_LRS -Location eastus).Context

        $sharename = "testrenameshare1"
        $dirpath = "dir1"
        $filename = "file1"
        $share = New-AzStorageShare -Name $sharename -Context $currentctx 
        $dir = New-AzStorageDirectory -ShareName $sharename -Path $dirpath -Context $currentctx 
        $file = Set-AzStorageFileContent -ShareName $sharename -Source $localSmallSrcFile -Path $filename -Force -Context $currentctx -PassThru

        $destdir = "dir2"
        $destfilename = "file2"

        $file2 = Rename-AzStorageFile -ShareName $sharename -SourcePath $filename -DestinationPath $destfilename -Context $currentctx -Force 
        $file2.Name | Should -Be $destfilename
        $file2.Length | Should -Be $file.Length

        $dir2 = Rename-AzStorageDirectory -ShareName $sharename -SourcePath $dirpath -DestinationPath $destdir -Context $currentctx -Force
        $dir2.Name | Should -Be $destdir
        $dir2.Length | Should -Be $dir.Length

        $file = $file2 | Rename-AzStorageFile -DestinationPath $filename 
        $file.Name | Should -Be $filename
        $file.Length | Should -Be $file2.Length

        $file = $share | Rename-AzStorageFile -SourcePath $filename -DestinationPath $destfilename
        $file.Name | Should -Be $destfilename

        $dir = $dir2 | Rename-AzStorageDirectory -DestinationPath $dirpath 
        $dir.Name | Should -Be $dirpath
        $dir.Length | Should -Be $dir2.Length

        Remove-AzStorageShare -Name $sharename -Context $currentctx -Force

        $Error.Count | should -be 0
    }

    It "Cold tier"  {
        $Error.Clear()     

        $containername1 = GetRandomContainerName + "cold"
        New-AzStorageContainer -Name $containername1 -Context $ctx

        $blob = Set-AzStorageBlobContent -Container $containername1 -File $localSmallSrcFile -Blob test1 -StandardBlobTier Cold -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"} -Context $ctx -Force
        $blob.Name | Should -Be "test1"
        $blob.AccessTier | Should -Be "Cold"
        $blob.BlobProperties.ContentType | Should -Be "image/jpeg"

        $blob = Set-AzStorageBlobContent -Container $containerName1 -File $localBigSrcFile -Blob test2 -StandardBlobTier Cold -Context $ctx
        $blob.Name | Should -Be "test2"
        $blob.AccessTier | Should -Be "Cold"

        $blob.BlobBaseClient.SetAccessTier("Cold")
        $blob.AccessTier | Should -Be "Cold"
        $blob.Name | Should -Be "test2"

        $blob = Get-AzStorageBlob -Container $containerName1 -Blob test1 -Context $ctx
        $blob.AccessTier | Should -Be "Cold"
        $blob.Name | Should -Be "test1"
        $blob.BlobProperties.ContentType | Should -Be "image/jpeg"

        $destBlobName = "destblob1"
        $copyblob = $blob | Copy-AzStorageBlob -DestContainer $containerName1 -DestBlob $destBlobName -Force
        $copyblob.Name | Should -Be $destBlobName
        $copyblob.AccessTier | Should -Be "Hot"
        $copyBlob.BlobProperties.ContentType | Should -Be "image/jpeg"

        $copyblob = Copy-AzStorageBlob -SrcBlob $blob.Name -SrcContainer $containerName1 -DestContainer $containerName -DestBlob $destBlobName -StandardBlobTier Cold -Context $ctx -Force
        $copyblob.Name | Should -Be $destBlobName
        $copyblob.AccessTier | Should -Be "Cold"
        $copyBlob.BlobProperties.ContentType | Should -Be "image/jpeg"

        $largeBlob = Get-AzStorageBlob -Blob test2 -Container $containerName1 -Context $ctx 
        $copyblob = $largeblob | Copy-AzStorageBlob -DestContainer $containerName1 -DestBlob $destBlobName -StandardBlobTier Cold -Force
        $copyblob.Name | Should -Be $destBlobName
        $copyblob.AccessTier | Should -Be "Cold"

        Start-AzStorageBlobCopy -DestContainer $containerName1 -DestBlob $destBlobName -StandardBlobTier Cold -SrcContainer $containerName1 -SrcBlob test1 -Force -Context $ctx -RehydratePriority Standard
        $copyblob = Get-AzStorageBlob -Container $containerName1 -Blob $destBlobName -Context $ctx
        $copyblob.Name | Should -Be $destBlobName
        $copyblob.AccessTier | Should -Be "Cold"
        $copyBlob.BlobProperties.ContentType | Should -Be "image/jpeg"

        Remove-AzStorageContainer -Name $containername1 -Context $ctx -Force 

        $Error.Count | should -be 0
    }

    It "Queue track2 migration"  {
        $Error.Clear()     
        $queuename = "testq1"

        $q = New-AzStorageQueue -Name $queuename -Context $ctx 
        $q.Name | Should -Be $queuename
        $q = Get-AzStorageQueue -Name $queuename -Context $ctx 
        $q.Name | Should -Be $queuename
        $q.ApproximateMessageCount | Should -Be 0 
        $q.QueueProperties.ApproximateMessagesCount | Should -Be 0

        $q = New-AzStorageQueue -Name testq2 -Context $ctx 
        $qs = Get-AzStorageQueue -Context $ctx
        $qs.Count | Should -BeGreaterOrEqual 2
        
        $q = Get-AzStorageQueue -Name $queuename -Context $ctx
        $queueMessage = "This is message 1"
        $q.QueueClient.SendMessage($QueueMessage)
        $q = Get-AzStorageQueue -Name $queuename -Context $ctxoauth1
        $q.Name | Should -Be $queuename
        $q.ApproximateMessageCount | Should -Be 1 
        $q.QueueProperties.ApproximateMessagesCount | Should -Be 1 

        $sas = New-AzStorageAccountSASToken -Service Queue -ResourceType Container,Object,Service -Permission rwdl -ExpiryTime 3000-01-01 -Context $ctx 
        $ctxaccountsas = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $qs = Get-AzStorageQueue -Context $ctxaccountsas
        $qs.Count | Should -BeGreaterOrEqual 2 

        $sas = New-AzStorageQueueSASToken -Name $queuename -Context $ctx -Permission ruap
        $sas | Should -BeLike "*sp=raup*"
        $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas 
        $q = Get-AzStorageQueue -Name $queuename -Context $sasctx
        $q.Name | Should -Be $queuename
        $q.Context.StorageAccount.Credentials.IsSAS | Should -Be $true

        $sas = New-AzStorageQueueSASToken -Name $queuename -Context $ctx -Permission rap -StartTime 2023-04-20 -ExpiryTime 2223-08-05
        $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $sas | Should -BeLike "*st=2023-04-19*se=2223-08-04*"
        $q = Get-AzStorageQueue -Name $queuename -Context $sasctx
        $q.Name | Should -Be $queuename
        $q.Context.StorageAccount.Credentials.IsSAS | Should -Be $true

        $sas = New-AzStorageQueueSASToken -Name $queuename -Context $ctx -Permission raup -Protocol HttpsOnly -IPAddressOrRange 0.0.0.0-255.255.255.255 -ExpiryTime 2223-08-05
        $sas | Should -BeLike "*spr=https*se=2223-08-04*sip=0.0.0.0-255.255.255.255*sp=raup*"
        $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $q = Get-AzStorageQueue -Name $queuename -Context $sasctx
        $q.Name | Should -Be $queuename
        $q.Context.StorageAccount.Credentials.IsSAS | Should -Be $true

        $sas = New-AzStorageQueueSASToken -Name $queuename -Context $ctx -Permission raup -ExpiryTime 2223-08-05 -FullUri
        $sas | Should -BeLike "https://$($storageAccountName).queue.core.windows.net/testq1*se=2223-08-04*"

        New-AzStorageQueueStoredAccessPolicy -Queue $queuename -Policy p001 -Permission ruap -StartTime 2023-5-1 -ExpiryTime 2223-08-05 -Context $ctx 
        $sas = New-AzStorageQueueSASToken -Name $queuename -Policy p001 -Context $ctx -Protocol HttpsOnly -IPAddressOrRange 0.0.0.0-255.255.255.255
        $sas | Should -BeLike "*spr=https*sip=0.0.0.0-255.255.255.255*si=p001*"
        $sasctx = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $q = Get-AzStorageQueue -Name $queuename -Context $sasctx
        $q.Name | Should -Be $queuename
        $q.Context.StorageAccount.Credentials.IsSAS | Should -Be $true

        $p = Set-AzStorageQueueStoredAccessPolicy -Queue $queuename -Policy p001 -Permission rau -NoStartTime -NoExpiryTime -Context $ctx
        $p.Policy | Should -Be "p001"
        $p.ExpiryTime | Should -Be $null
        $p.StartTime | Should -Be $null
        $p.Permissions | Should -Be "rau"

        $p = New-AzStorageQueueStoredAccessPolicy -Queue $queuename -Policy p002 -Permission ruap -Context $ctx
        $p = Get-AzStorageQueueStoredAccessPolicy -Queue $queuename -Context $ctx 
        $p.Count | Should -Be 2
        $p = Get-AzStorageQueueStoredAccessPolicy -Queue $queuename -Policy p001 -Context $ctx
        $p.Policy | Should -Be "p001"

        Remove-AzStorageQueueStoredAccessPolicy -Queue $queuename -Policy p001 -Context $ctx

        Remove-AzStorageQueue -Name $queuename -Context $ctx -Force 
        $q2 = Get-AzStorageQueue -Name testq2 -Context $ctxoauth1
        $q2 | Remove-AzStorageQueue -Force

        $Error.Count | should -be 0
    }

    It "File oauth"  {
        $Error.Clear()        

        $accountname = $testNode.SelectSingleNode("accountName[@id='4']").'#text'
        $accountname2 =$testNode.SelectSingleNode("accountName[@id='5']").'#text' 
 
        $localSrcFile = ".\data\testfile_1K_0"
        $localSrcFileName = "testfile_1K_0"
        $localLargeSrcFile = ".\data\testfile_307200K_0" # File of size 300M. Needs to be created beforehand
        $localDestFile = ".\created\testoauth" # test will create the file
        $localDestFileName = "testoauth"
        $shareName = "$(GetRandomContainerName)oauth"
        $filename = "filefileoauth"
        $dirname = "dir1"
        $filepath = "dir1\test1"

        # create oauth context
        #$secpasswd = ConvertTo-SecureString $globalNode.secPwd -AsPlainText -Force
        #$cred = New-Object System.Management.Automation.PSCredential ($globalNode.applicationId, $secpasswd)
        #Add-AzAccount -ServicePrincipal -Tenant $globalNode.tenantId -SubscriptionId $globalNode.subscriptionId -Credential $cred 

        $ctxoauth = New-AzStorageContext -StorageAccountName $accountname -EnableFileBackupRequestIntent
        $ctxkey = New-AzStorageContext -StorageAccountName $accountname -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $accountname)[0].Value
        $ctxoauth2 = New-AzStorageContext -StorageAccountName $accountname2 -EnableFileBackupRequestIntent
        #$ctxkey2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $accountname2).Context

        New-AzStorageShare -Name $shareName -Context $ctxkey
        Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path $filename -Context $ctxoauth -Force
        New-AzStorageDirectory -ShareName $shareName -Path $dirname -Context $ctxoauth

        # Share object w/o fetching properties with OAuth 
        $share = Get-AzStorageShare -Name $shareName -Context $ctxoauth -SkipGetProperty
        $dir = $share | Get-AzStorageFile -Path $dirname 
        $file = $share | Get-AzStorageFile -Path $filename

        # share API with Oauth
        $share2 = New-AzStorageShare -Name "$($shareName)2" -Context $ctxoauth
        $share2.Name | should -Be "$($shareName)2"
        $shares = Get-AzStorageShare -Context $ctxoauth
        $shares.Count | should -BeGreaterOrEqual 2
        $count1 = $shares.Count

        $share2 =  Set-AzStorageShareQuota -Name "$($shareName)2" -Context $ctxoauth -Quota 200
        $share2 = Get-AzStorageShare -Name "$($shareName)2" -Context $ctxoauth
        $share2.Name | should -Be "$($shareName)2"
        $share2.Quota | should -Be 200
        
        New-AzStorageShareStoredAccessPolicy -Name $shareName -Context $ctxoauth -Policy 123 -Permission rw
        New-AzStorageShareStoredAccessPolicy -Name $shareName -Context $ctxoauth -Policy 1234 -Permission r -StartTime (Get-Date) -ExpiryTime (Get-Date).Add(1)
        set-AzStorageShareStoredAccessPolicy -Name $shareName -Context $ctxoauth -Policy 123 -Permission rwd -StartTime (Get-Date)
        $policy = Get-AzStorageShareStoredAccessPolicy -Name $shareName -Context $ctxoauth
        $policy.Count | should -be 2
        Remove-AzStorageShareStoredAccessPolicy -Name $shareName -Context $ctxoauth -Policy 123

        Remove-AzStorageShare -Name "$($shareName)2" -Context $ctxoauth -Force
        $share2.Name | should -Be "$($shareName)2"
        $shares = Get-AzStorageShare -Context $ctxoauth
        $shares.Count | should -Be ($count1-1)

        

        # Set and get permission
        $permission = $testNode.permission 
        $inputpermission = new-object Azure.Storage.Files.Shares.Models.ShareFilePermission
        $inputpermission.Permission = $permission
        $response = $share.ShareClient.CreatePermission($inputpermission);
        $key = $response.Value.FilePermissionKey
        $outputPermission = $share.ShareClient.GetPermission($key)
        $outputPermission.Value.Permission | Should -Be $permission

        # file handler
        $handleCount = Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Context $ctxoauth -PassThru
        $handleCount | should -be 0
        Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Recursive -Context $ctxoauth
        $share | Close-AzStorageFileHandle -CloseAll
        $dir | Close-AzStorageFileHandle -CloseAll
        $file | Close-AzStorageFileHandle -CloseAll
        Get-AzStorageFileHandle -ShareName $shareName -Context $ctxoauth
        Get-AzStorageFileHandle -ShareName $shareName -Context $ctxoauth -Recursive        
        Get-AzStorageFileHandle -ShareName $shareName -Context $ctxoauth -Recursive -Skip 1 -First 3
        $share | Get-AzStorageFileHandle 
        $dir | Get-AzStorageFileHandle 
        $file | Get-AzStorageFileHandle 

        # upload and download file
        $file = Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path $filepath -Context $ctxoauth -PassThru -Force
        $file.ShareFileClient.Path | Should -BeLike $filepath
        Get-AzStorageFileContent -ShareName $shareName -Path $filepath -Destination $localDestFile -Context $ctxoauth -Force
        $src = (Get-ChildItem -Path ".\data" -Filter $localSrcFileName).FullName
        $dest = (Get-ChildItem -Path ".\created" -Filter $localDestFileName).FullName
        CompareFileMD5 $src $dest
        Remove-Item $localDestFile

        # file pipeline 
        $file = Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path $filepath -Context $ctxoauth -PassThru -Force
        $file.ShareFileClient.Path | should -be $filepath
        $file | Get-AzStorageFileContent -Destination $localDestFile -Force
        CompareFileMD5 $src $dest 
        Remove-Item $localDestFile

        # share pipeline 
        $file = $share | Set-AzStorageFileContent -Source $localSrcFile -Path $filepath -PassThru  -Force
        $file.ShareFileClient.Path | should -be $filepath
        $share | Get-AzStorageFileContent -Path $filepath -Destination $localDestFile -Force -Context $ctxoauth
        CompareFileMD5 $src $dest  
        Remove-Item $localDestFile

        # dir pipeline 
        $file = $dir | Set-AzStorageFileContent -Source $localSrcFile -Path test3 -PassThru  -Force    
        $file.ShareFileClient.Path | should -BeLike "dir1?test3"
        $dir | Get-AzStorageFileContent -Path test3 -Destination $localDestFile -Force -Context $ctxoauth
        CompareFileMD5 $src $dest  
        Remove-Item $localDestFile

        # Get and list files 
        $items = Get-AzStorageFile -ShareName $shareName -Context $ctxoauth
        $items.count | should -BeGreaterThan 1

        $items = Get-AzStorageFile -ShareName $shareName -Path $filepath -Context $ctxoauth
        $items.count | should -be 1
        $items[0].ShareFileClient.Path | should -be $filepath

        $items = $share | Get-AzStorageFile 
        $items.count | should -BeGreaterThan 1

        $items = $share | Get-AzStorageFile -Path $dirname
        $items.count | should -be 1
        $items[0].ShareDirectoryClient.Path | should -be $dirname

        $items = $dir | Get-AzStorageFile 
        $items.count | should -BeGreaterThan 1

        $items = $dir | Get-AzStorageFile -Path test1
        $items.count | should -be 1
        $items[0].ShareFileClient.Path | should -BeLike "dir1/test1"

        # Create and delete directory/file 
        $d0 = New-AzStorageDirectory -ShareName $shareName -Path "dirtoDelete" -Context $ctxoauth
        $d1 = $d0 | New-AzStorageDirectory -Path "dir1" 
        $d2 = $share | New-AzStorageDirectory -Path "dirtoDelete/dir2"
        $d3 = $share | New-AzStorageDirectory -Path "dirtoDelete/dir3"

        $f0 = $share | Set-AzStorageFileContent -Source $localSrcFile -Path "dirtoDelete/test0" -PassThru -Force
        $f1 = Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path "dirtoDelete/dir1/test1" -Context $ctxoauth -PassThru -Force
        $f2 = $d2 | Set-AzStorageFileContent -Source $localSrcFile -Path "test2" -PassThru -Force
        $f3 = $d2 | Set-AzStorageFileContent -Source $localSrcFile -Path "test3" -PassThru -Force

        $items1 = $d0 | Get-AzStorageFile 
        $items1.Count | should -be 4
        $items2 = $d1 | Get-AzStorageFile
        $items2.Count | should -be 1
        $items3 = $d2 | Get-AzStorageFile
        $items3.Count | should -be 2

        # delete them
        Remove-AzStorageFile -ShareName $shareName -Path "dirtoDelete/dir1/test1" -Context $ctxoauth -PassThru
        $d2 | Remove-AzStorageFile -Path "test2" 
        $f3 | Remove-AzStorageFile 
        $share  | Remove-AzStorageFile -Path "dirtoDelete/test0" 
        Remove-AzStorageDirectory -ShareName $shareName -Path "dirtoDelete/dir1" -Context $ctxoauth
        $d0  | Remove-AzStorageDirectory -Path "dir2" 
        $d3  | Remove-AzStorageDirectory 
        $items1 = $d0 | Get-AzStorageFile 
        $items1.Count | should -be 0
        $share  | Remove-AzStorageDirectory -Path "dirtoDelete" -PassThru

        New-AzStorageContainer -Name $shareName -Context $ctxoauth -ErrorAction SilentlyContinue
        $b = Set-AzStorageblobContent -Container $shareName -File $localSrcFile -blob testblob -Context $ctxoauth -Force
        New-AzStorageShare -Name $shareName -Context $ctxoauth2 -ErrorAction SilentlyContinue
        New-AzStorageDirectory -ShareName $shareName -Path dir1 -Context $ctxoauth2 -ErrorAction SilentlyContinue
        Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctxoauth -Force
        $Error.Clear()

        # copy 
        $fsrc = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctxoauth
        $f = Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctxkey -DestContext $ctxoauth2 -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -be $fsrc.Length
        $f = Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctxoauth -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -be $fsrc.Length

        $f = Start-AzStorageFileCopy -SrcContainerName  $shareName -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctxoauth -DestContext $ctxoauth2 -Force
        $copystatus = Get-AzStorageFileCopyState -ShareName $shareName -FilePath $f.ShareFileClient.Path -Context $ctxoauth2 -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -be $b.Length      
        $copystatus.Status | should -be Success
        #$copystatus.Source| should -BeLike "$($b.ICloudBlob.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $b.Length
        $copystatus.BytesCopied | should -be $b.Length

        $f = Start-AzStorageFileCopy -SrcContainerName  $shareName -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctxoauth -Force
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length


        $f1 = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctxoauth
        $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/copydest -Context $ctxoauth

        $f2 = $f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth 
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctxoauth.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length

        $f2 = Start-AzStorageFileCopy -SrcFile $f1.ShareFileClient  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctxoauth.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length
                
        $f1 = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctxkey
        $fdest = Get-AzStorageFile -ShareName $shareName -Path dir1/copydest -Context  $ctxoauth2
        $f2 = Start-AzStorageFileCopy -SrcFile $f1.ShareFileClient  -DestShareFileClient $fdest.ShareFileClient -Force -DestContext $ctxoauth2   
        $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length
         
        $f2 = $f1  | Start-AzStorageFileCopy  -DestShareFileClient $fdest.ShareFileClient -Force -DestContext $ctxoauth2 
        $copystatus = $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be $f1.Length       
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($f1.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $f1.Length
        $copystatus.BytesCopied | should -be $f1.Length

        $s = Get-AzStorageShare -Name $shareName -Context $ctxkey
        $f2 = Start-AzStorageFileCopy -SrcShare $s.ShareClient -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth2 
        $copystatus = $f2 | Get-AzStorageFileCopyState -WaitForComplete
        $f2.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f2.ShareFileClient.Path | should -be "dir1/copydest"
        $f2.FileProperties.ContentLength | should -Be (Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctxoauth).Length
        #check copy status
        $srcfile = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctxoauth       
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($srcfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $srcfile.Length
        $copystatus.BytesCopied | should -be $srcfile.Length

        $b = Get-AzStorageBlob -Containe $shareName -Blob testblob -Context $ctxoauth
        $bs = $b.ICloudBlob
        $bs.FetchAttributes()

        $f = $b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth2
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length

        $f = Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length

        $fdest = Get-AzStorageFile -ShareName $shareName -Path dir1/copydest -Context $ctxoauth2
        $f = Start-AzStorageFileCopy -SrcBlob $bs -DestShareFileClient $fdest.ShareFileClient -destContext $ctxoauth2 -Force
        $copystatus = $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $bs.Properties.Length
        #check copy status      
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($bs.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $bs.Properties.Length
        $copystatus.BytesCopied | should -be $bs.Properties.Length

        # from container object
        $c = Get-AzStorageContainer -Name  $shareName -Context $ctxoauth
        $f = Start-AzStorageFileCopy -SrcContainer $c.CloudBlobContainer -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth2
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        $f.FileProperties.ContentLength | should -Be $b.Length
        # from Uri
        $uri1 = New-AzStorageFileSASToken -ShareName $shareName -Path dir1/test1 -Permission rwdl -FullUri -Context $ctxkey 
        $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth2
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        #$f.FileProperties.ContentLength | should -Be $f1.Length

        $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareFileClient $fdest.ShareFileClient -destContext  $ctxoauth2 -Force 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"

        $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctxoauth2 
        $f | Get-AzStorageFileCopyState -WaitForComplete
        $f.ShareFileClient.AccountName | should -be $ctxoauth2.StorageAccountName
        $f.ShareFileClient.Path | should -be "dir1/copydest"
        #check copy status
        $copystatus = $f | Get-AzStorageFileCopyState 
        $srcfile = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctxoauth     
        $copystatus.Status | should -be Success
        # $copystatus.Source| should -BeLike "$($srcfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
        $copystatus.TotalBytes | should -be $srcfile.Length
        $copystatus.BytesCopied | should -be $srcfile.Length

        # Stop copy 

        $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/copydest -Context $ctxoauth 
        $error.Clear()
        $stopmessage = $fd | Stop-AzStorageFileCopy -CopyId $fd.FileProperties.CopyId -ErrorAction SilentlyContinue
        $error[0].Exception.Message | should -BeLike "There is currently no pending copy operation*"
        $error.Clear()
        $stopmessage = Stop-AzStorageFileCopy -ShareName $shareName  -FilePath dir1/copydest -Context $ctxoauth -Force -ErrorAction SilentlyContinue
        $error[0].Exception.Message | should -BeLike "There is currently no pending copy operation*"
        $error.Clear()
        $stopmessage = Stop-AzStorageFileCopy -ShareFileClient $fd.ShareFileClient -Context $ctxoauth -Force -ErrorAction SilentlyContinue
        $error[0].Exception.Message | should -BeLike "There is currently no pending copy operation*"
        $error.Clear()
     
        $Error.Count | should -be 0

        Set-AzStorageServiceMetricsProperty -ServiceType File -MetricsType Hour -Context $ctxoauth -ErrorAction SilentlyContinue
        $error[0].Exception.Message | should -BeLike "*Server failed to authenticate the request. Make sure the value of Authorization header is formed correctly including the signature.*"

        $error.Clear()

        # should fail since file sas can only create with sharedkey 
        $file | New-AzStorageFileSASToken -Permission rw -ErrorAction SilentlyContinue
        New-AzStorageFileSASToken -ShareName $shareName -Path $file.ShareFileClient.Path -Permission rw -Context $ctxoauth -ErrorAction SilentlyContinue
        $file | New-AzStorageFileSASToken -Policy 123 -ErrorAction SilentlyContinue
        New-AzStorageFileSASToken -ShareName $shareName -Path $file.ShareFileClient.Path -Policy 123 -Context $ctxoauth -ErrorAction SilentlyContinue
        $share | New-AzStorageShareSASToken -Permission rw  -ErrorAction SilentlyContinue
        New-AzStorageShareSASToken -ShareName $shareName  -Policy 123 -Context $ctxoauth -ErrorAction SilentlyContinue
        $share | New-AzStorageShareSASToken -Permission rw -ErrorAction SilentlyContinue
        New-AzStorageShareSASToken -ShareName $shareName  -Policy 123 -Context $ctxoauth -ErrorAction SilentlyContinue
        $error.Count | should -be 8
        foreach ($e in $error)
        {
            $e.Exception.Message | should -BeLike "*Create File service SAS only supported with SharedKey credential.*"
        }
        $error.Clear()
        
        Remove-AzStorageShare -Name $shareName -Context $ctxoauth -Force
        Remove-AzStorageShare -Name $shareName -Context $ctxoauth2 -Force

        $Error.Count | should -be 0
    }

    It "Trailing dot"  {
        $Error.Clear()     

        $sharename = "testsharedot"
        $share = New-AzStorageShare -Name $sharename -Context $ctx 
        $share = Get-AzStorageShare -Name $sharename -Context $ctx 

        # Default: allow 
        $f =  Get-AzStorageFile -ShareName $sharename -Context $ctx 
        $d = New-AzStorageDirectory -ShareName $shareName -Path "test1." -Context $ctx
        $d.Name | Should -Be "test1."
        $d = New-AzStorageDirectory -ShareName $shareName -Path "test1./test2.." -Context $ctx 
        $d.Name | Should -Be "test2.."
        $d = New-AzStorageDirectory -ShareName $shareName -Path "dir1" -Context $ctx
        $d.Name | Should -Be "dir1"
        
        $dir = Get-AzStorageFile -ShareName $shareName -Path "test1./test2.." -Context $ctx 
        $dir.Name | Should -Be "test2.."
        $dir.ShareDirectoryClient.Path | Should -Be "test1./test2.."
        $dir.ShareDirectoryClient.Name | Should -Be "test2.."

        $f = Set-AzStorageFileContent -ShareName $shareName -Path "testfile" -Source .\data\testfile_1K_0 -Context $ctx -PassThru -Force
        $f.Name | Should -Be "testfile"
        $f.Length | Should -Be 1024
        $f = Set-AzStorageFileContent -ShareName $shareName -Path "test1./test2../files..." -Source .\data\testfile_1024K_0 -Context $ctx -PassThru -Force
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."
        $f.ShareFileClient.ShareName | Should -Be $shareName

        if ($false){
            #  should fail
            $f = Set-AzStorageFileContent -ShareName $shareName -Path "test1/test2/files..." -Source C:\temp\512b -Context $ctx -PassThru
            $f = Set-AzStorageFileContent -ShareName $shareName -Path "test1/test2../files" -Source C:\temp\512b -Context $ctx -PassThru
            $f = Set-AzStorageFileContent -ShareName $shareName -Path "test1./test2/files" -Source C:\temp\512b -Context $ctx -PassThru
            $f = Set-AzStorageFileContent -ShareName $shareName -Path "test1/test2/files" -Source C:\temp\512b -Context $ctx -PassThru
        }

        # $f.CloudFile.FetchAttributes() # should fail
        $f = $dir | Set-AzStorageFileContent -Path "files..." -Source .\data\testfile_1024K_0  -PassThru -Force
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."
        $f.ShareFileClient.Name | Should -Be "files..."

        $f = $share | Set-AzStorageFileContent -Path "test1./test2../files..." -Source .\data\testfile_1024K_0 -PassThru -Force
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."
        $f.ShareFileClient.Name | Should -Be "files..."
        $f.Length | Should -Be (Get-Item .\data\testfile_1024K_0).Length

        $f = Set-AzStorageFileContent -ShareName $shareName -Path "test1./test2../files.1.." -Source .\data\testfile_10240K_0 -Context $ctx -PassThru -Force
        $f.Name | Should -Be "files.1.."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files.1.."
        $f.Length | Should -Be (Get-Item .\data\testfile_10240K_0).Length
        $f.ShareFileClient.Name | Should -Be "files.1.."

        # download file/dir
        $f = Get-AzStorageFileContent -ShareName $shareName -Path "test1./test2../files..." -Destination .\created\testtrailingdot -Context $ctx -Force -PassThru
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."
    
        $f = $f | Get-AzStorageFileContent -Destination .\created\testtrailingdot -Context $ctx -Force -PassThru
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."

        $f = $dir | Get-AzStorageFileContent -Path "files..."  -Destination .\created\testtrailingdot -Context $ctx -Force -PassThru
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."

        $f = $share | Get-AzStorageFileContent -Path "test1./test2../files..."  -Destination .\created\testtrailingdot -Context $ctx -Force -PassThru
        $f.Name | Should -Be "files..."
        $f.ShareFileClient.Path | Should -Be "test1./test2../files..."

        $f = Get-AzStorageFileContent -ShareName $shareName -Path "test1./test2../files.1.." -Destination .\created\testtrailingdot -Context $ctx -PassThru -Force

        #get file/dir
        $dir = Get-AzStorageFile -ShareName $shareName -Path "test1./test2.." -Context $ctx 
        $dir.Name | Should -Be "test2.."
        $dir.ShareDirectoryClient.Path | Should -Be "test1./test2.."

        $files = $dir | Get-AzStorageFile  
        $files.Count | Should -Be 2 

        $files = $dir | Get-AzStorageFile -Path "files..."  
        $files.Count | Should -Be 1 

        $files = $share | Get-AzStorageFile  
        $files.Count | Should -Be 3

        $f = $share | Get-AzStorageFile -Path "test1./test2.." 
        $f.Name | Should -Be "test2.."

        $file = $share | Get-AzStorageFile -Path "test1./test2../files..."
        $file.ShareFileClient.GetProperties()
        
        # $file.CloudFile.FetchAttributes() # should fail
 
    # SAS on file     
        $sas = $file | New-AzStorageFileSASToken -Permission rw -ExpiryTime (Get-date).AddDays(6) 
        $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $f = Get-AzStorageFile -ShareName $shareName -Path "test1.\test2..\files..." -Context $ctxsas
        $f.Name | Should -Be "test1.\test2..\files..."

        $sas = New-AzStorageFileSASToken -ShareName $shareName -Path "test1.\test2..\files..." -Context $ctx -Permission rw -ExpiryTime (Get-date).AddDays(6) 
        $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $f = Get-AzStorageFile -ShareName $shareName -Path "test1.\test2..\files..." -Context $ctxsas
        $f.Name | Should -Be "test1.\test2..\files..."
 
        $sas = New-AzStorageShareSASToken -ShareName $shareName -Permission rw -ExpiryTime (Get-date).AddDays(6) -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
        $dir = Get-AzStorageFile -ShareName $shareName -Path "test1./test2.." -Context $ctxsas
        $dir.Name | Should -Be "test2.."

        #file handle - test it cmdlets won't fail 
        Get-AzStorageFileHandle   -ShareName $shareName -Path "test1.\test2.." -Context $ctx  -Recursive 
        Get-AzStorageFileHandle   -ShareName $shareName -Path "test1.\test2..\files..." -Context $ctx  
        Close-AzStorageFileHandle   -ShareName $shareName -Path "test1.\test2.." -Context $ctx  -Recursive -CloseAll 
        Close-AzStorageFileHandle   -ShareName $shareName -Path "test1.\test2..\files..." -Context $ctx  -CloseAll
 
    #rename 
        $f = Rename-AzStorageFile  -ShareName $shareName -SourcePath "testfile" -DestinationPath "test1.\test2..\files.2.." -Context $ctx 
        $f.Name | Should -Be "test1.\test2..\files.2.."
        $f = Rename-AzStorageFile  -ShareName $shareName -DestinationPath "testfile" -SourcePath "test1.\test2..\files.2.." -Context $ctx 
        $f.Name | Should -Be "testfile"
        $d = Rename-AzStorageDirectory  -ShareName $shareName -SourcePath "dir1" -DestinationPath "test1.\test3.." -Context $ctx 
        $d.Name | Should -Be "test1.\test3.."
        $d = Rename-AzStorageDirectory  -ShareName $shareName -DestinationPath "dir1" -SourcePath "test1.\test3.." -Context $ctx 
        $d.Name | Should -Be "dir1"
        $d = New-AzStorageDirectory -ShareName $shareName -Path "dir1.." -Context $ctx
        $f = Set-AzStorageFileContent -ShareName $shareName -Path "test.file.." -Source .\data\testfile_1024K_0 -Context $ctx -PassThru -Force
        $f = Rename-AzStorageFile  -ShareName $shareName -SourcePath "test.file.." -DestinationPath "test1.\test2..\files.2.." -Context $ctx 
        $f.Name | Should -Be "test1.\test2..\files.2.."
        $f = Rename-AzStorageFile  -ShareName $shareName -DestinationPath "test.file.." -SourcePath "test1.\test2..\files.2.." -Context $ctx 
        $f.Name | Should -Be "test.file.."
        $d = Rename-AzStorageDirectory  -ShareName $shareName -SourcePath "dir1.." -DestinationPath "test1.\test3.." -Context $ctx 
        $d.Name | Should -Be "test1.\test3.."
        $d = Rename-AzStorageDirectory  -ShareName $shareName -DestinationPath "dir1.." -SourcePath "test1.\test3.." -Context $ctx
        $d.Name | Should -Be "dir1.." 


        Remove-AzStorageShare -Name $sharename -Context $ctx -Force
        $Error.Count | should -be 0
    }

    It "Upload file with write only SAS" {
        $Error.Clear()
        $sas = New-AzStorageAccountSASToken -Service File -ResourceType Container,Object,Service -Permission wc -ExpiryTime (Get-Date).AddDays(10) -Context $ctx 
        $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas 

        New-AzStorageDirectory -ShareName $containerName -Path testdirx1 -Context $ctx

        $f = Set-AzStorageFileContent -ShareName $containerName -Source $localSmallSrcFile -Path testdirx1/file1. -Context $ctxsas -Force
        $f = Get-AzStorageFile -ShareName $containerName -Path testdirx1/file1. -Context $ctx 
        $f.Name | Should -Be file1. 
        $Error.Count | Should -Be 0

        $f = Set-AzStorageFileContent -ShareName $containerName -Source $localSmallSrcFile -Path testdirx1 -Context $ctxsas -Force -PassThru -ErrorAction SilentlyContinue
        $error[0].Exception.Message
        $Error.Clear()


    }

    It "Storage Account Context works on both AllowSharedKeyAccess = true/false account."  {
        $Error.Clear()    
        
        # with get context with sharedkey
        $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context

        $result = Get-AzStorageContainer -Context $ctx -MaxCount 1
        $result | should -Not -Be $null 
        $result = Get-AzStorageShare -Context $ctx 
        $result | should -Not -Be $null 
        $result = Get-AzStorageTable -Context $ctx 
        $result | should -Not -Be $null 
        $result = Get-AzStorageQueue -Context $ctx 
        $result | should -Not -Be $null 

        try
        {
            # with get context with Oauth
            Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2 -AllowSharedKeyAccess $false
        
            $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context

            $result = Get-AzStorageContainer -Context $ctx -MaxCount 1
            $result | should -Not -Be $null 
            New-AzStorageDirectory -ShareName $containerName -Path diroauthtest -Context $ctx -ErrorAction SilentlyContinue
            $result = Get-AzStorageFile -ShareName $containerName -Context $ctx 
            $result | should -Not -Be $null 
            $result = Get-AzStorageTable -Context $ctx 
            $result | should -Not -Be $null 
            $result = Get-AzStorageQueue -Context $ctx 
            $result | should -Not -Be $null 
        }
        catch
        {
           Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2 -AllowSharedKeyAccess $true
           throw; 
        }
        Set-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2 -AllowSharedKeyAccess $true

        $Error.Count | should -be 0
    }

    It "Test case name"  {
        $Error.Clear()    

        $Error.Count | should -be 0
    }

    AfterAll {    
        $ProgressPreference = $OriginalPref
        Remove-AzStorageShare -Name $containerName -Force -Context $ctx -PassThru
        Remove-AzStorageContainer -Name $containerName -Force -Context $ctx -PassThru
        Remove-AzStorageContainer -Name $containerName -Context $ctxoauth2 -Force
    }
}