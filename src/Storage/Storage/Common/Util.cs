﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Auth;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using global::Azure.Storage.Sas;
    using global::Azure.Storage.Blobs.Specialized;
    using System.Collections.Generic;
    using System.Collections;
    using global::Azure.Storage.Blobs;

    internal static class Util
    {
        /// <summary>
        /// Size formats
        /// </summary>
        private static string[] sizeFormats =
        {
            Resources.HumanReadableSizeFormat_Bytes,
            Resources.HumanReadableSizeFormat_KiloBytes,
            Resources.HumanReadableSizeFormat_MegaBytes,
            Resources.HumanReadableSizeFormat_GigaBytes,
            Resources.HumanReadableSizeFormat_TeraBytes,
            Resources.HumanReadableSizeFormat_PetaBytes,
            Resources.HumanReadableSizeFormat_ExaBytes
        };

        /// <summary>
        /// Translate a size in bytes to human readable form.
        /// </summary>
        /// <param name="size">Size in bytes.</param>
        /// <returns>Human readable form string.</returns>
        public static string BytesToHumanReadableSize(double size)
        {
            int order = 0;

            while (size >= 1024 && order + 1 < sizeFormats.Length)
            {
                ++order;
                size /= 1024;
            }

            return string.Format(sizeFormats[order], size);
        }

        public static CloudBlob GetBlobReferenceFromServer(
            CloudBlobContainer container,
            string blobName,
            AccessCondition accessCondition = null,
            BlobRequestOptions options = null,
            OperationContext operationContext = null,
            DateTimeOffset? snapshotTime = null)
        {
            CloudBlob blob = container.GetBlobReference(blobName, snapshotTime);
            return GetBlobReferenceFromServer(blob, accessCondition, options, operationContext);
        }

        public static CloudBlob GetBlobReferenceFromServer(CloudBlobClient client, Uri blobUri)
        {
            CloudBlob blob = new CloudBlob(blobUri, client.Credentials);
            return GetBlobReferenceFromServer(blob);
        }

        private static CloudBlob GetBlobReferenceFromServer(
            CloudBlob blob,
            AccessCondition accessCondition = null,
            BlobRequestOptions options = null,
            OperationContext operationContext = null,
            DateTimeOffset? snapshotTime = null)
        {
            try
            {
                Task.Run(() => blob.FetchAttributesAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
            {
                if (((StorageException)e.InnerException).RequestInformation == null ||
                    (((StorageException)e.InnerException).RequestInformation.HttpStatusCode != (int)HttpStatusCode.NotFound))
                {
                    throw e.InnerException;
                }

                return null;
            }
            catch (StorageException se)
            {
                if (se.RequestInformation == null ||
                    (se.RequestInformation.HttpStatusCode != (int)HttpStatusCode.NotFound))
                {
                    throw;
                }

                return null;
            }

            return GetCorrespondingTypeBlobReference(blob);
        }

        public static CloudBlob GetCorrespondingTypeBlobReference(CloudBlob blob)
        {
            CloudBlob targetBlob;
            switch (blob.Properties.BlobType)
            {
                case BlobType.BlockBlob:
                    targetBlob = new CloudBlockBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
                    break;
                case BlobType.PageBlob:
                    targetBlob = new CloudPageBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
                    break;
                case BlobType.AppendBlob:
                    targetBlob = new CloudAppendBlob(blob.SnapshotQualifiedUri, blob.ServiceClient.Credentials);
                    break;
                default:
                    throw new InvalidOperationException(string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidBlobType,
                        blob.Properties.BlobType,
                        blob.Name));
            }

            try
            {
                Task.Run(() => targetBlob.FetchAttributesAsync()).Wait();
            }
            catch (AggregateException e) when (e.InnerException is StorageException)
            {
                throw e.InnerException;
            }

            return targetBlob;
        }

        public static CloudBlob GetBlobReference(CloudBlobContainer container, string blobName, BlobType blobType)
        {
            switch (blobType)
            {
                case BlobType.BlockBlob:
                    return container.GetBlockBlobReference(blobName);
                case BlobType.PageBlob:
                    return container.GetPageBlobReference(blobName);
                case BlobType.AppendBlob:
                    return container.GetAppendBlobReference(blobName);
                default:
                    throw new ArgumentException(String.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidBlobType,
                        blobType,
                        blobName));
            }
        }

        public static CloudBlob GetBlobReference(Uri blobUri, StorageCredentials storageCredentials, BlobType blobType)
        {
            switch (blobType)
            {
                case BlobType.BlockBlob:
                    return new CloudBlockBlob(blobUri, storageCredentials);
                case BlobType.PageBlob:
                    return new CloudPageBlob(blobUri, storageCredentials);
                case BlobType.AppendBlob:
                    return new CloudAppendBlob(blobUri, storageCredentials);
                case BlobType.Unspecified:
                    return new CloudBlob(blobUri, storageCredentials);
                default:
                    throw new ArgumentException(String.Format(
                        CultureInfo.CurrentCulture,
                        Resources.InvalidBlobType,
                        blobType,
                        blobUri));
            }
        }

        public static IPAddressOrRange SetupIPAddressOrRangeForSAS(string inputIPACL)
        {
            if (string.IsNullOrEmpty(inputIPACL)) return null;

            int separator = inputIPACL.IndexOf('-');

            if (-1 == separator)
            {
                return new IPAddressOrRange(inputIPACL);
            }
            else
            {
                return new IPAddressOrRange(inputIPACL.Substring(0, separator), inputIPACL.Substring(separator + 1));
            }
        }

        /// <summary>
        /// Create SAS IP range for use in SAS created
        /// </summary>
        /// <param name="inputIPACL">The input string should not be null as already checked outside</param>
        public static SasIPRange SetupIPAddressOrRangeForSASTrack2(string inputIPACL)
        {
            int separator = inputIPACL.IndexOf('-');

            if (-1 == separator)
            {
                return new SasIPRange(IPAddress.Parse(inputIPACL));
            }
            else
            {
                return new SasIPRange(IPAddress.Parse(inputIPACL.Substring(0, separator)), IPAddress.Parse(inputIPACL.Substring(separator + 1)));
            }
        }

        public static XTable.IPAddressOrRange SetupTableIPAddressOrRangeForSAS(string inputIPACL)
        {
            if (string.IsNullOrEmpty(inputIPACL)) return null;

            int separator = inputIPACL.IndexOf('-');

            if (-1 == separator)
            {
                return new XTable.IPAddressOrRange(inputIPACL);
            }
            else
            {
                return new XTable.IPAddressOrRange(inputIPACL.Substring(0, separator), inputIPACL.Substring(separator + 1));
            }
        }

        /// <summary>
        /// Used in DMlib ShouldOverwriteCallback, to convert object to blob/file/localpath, and return path
        /// </summary>
        /// <param name="instance">object instace</param>
        /// <returns>path of the object</returns>
        public static string ConvertToString(this object instance)
        {
            CloudBlob blob = instance as CloudBlob;

            if (null != blob)
            {
                return blob.SnapshotQualifiedUri.AbsoluteUri;
            }

            CloudFile file = instance as CloudFile;

            if (null != file)
            {
                return file.SnapshotQualifiedUri.AbsoluteUri;
            }

            return instance.ToString();
        }

        /// <summary>
        /// Get VersionID of a blob Uri.
        /// </summary>
        public static string GetVersionIdFromBlobUri(Uri BlobUri)
        {
            string versionIdQueryParameter = "versionid=";
            string[] queryBlocks = BlobUri.Query.Split(new char[] { '&', '?' });
            foreach (string block in queryBlocks)
            {
                if (block.StartsWith(versionIdQueryParameter))
                {
                    return block.Replace(versionIdQueryParameter, "");
                }
            }
            return null;
        }

        /// <summary>
        /// Get snapshot Time of a blob Uri.
        /// </summary>
        public static DateTimeOffset? GetSnapshotTimeFromBlobUri(Uri BlobUri)
        {
            string snapshotQueryParameter = "snapshot=";
            string[] queryBlocks = BlobUri.Query.Split(new char[] { '&', '?' });
            foreach (string block in queryBlocks)
            {
                if (block.StartsWith(snapshotQueryParameter))
                {
                    return DateTimeOffset.Parse(block.Replace(snapshotQueryParameter, "")).ToUniversalTime();
                }
            }
            return null;
        }

        public static global::Azure.Storage.Blobs.Models.BlobType? convertBlobType_Track1ToTrack2(Azure.Storage.Blob.BlobType track1type)
        {
            switch (track1type)
            {
                case Azure.Storage.Blob.BlobType.AppendBlob:
                    return global::Azure.Storage.Blobs.Models.BlobType.Append;
                case Azure.Storage.Blob.BlobType.PageBlob:
                    return global::Azure.Storage.Blobs.Models.BlobType.Page;
                case Azure.Storage.Blob.BlobType.BlockBlob:
                    return global::Azure.Storage.Blobs.Models.BlobType.Block;
                default:
                    return null;
            }
        }

        public static Azure.Storage.Blob.BlobType convertBlobType_Track2ToTrack1(global::Azure.Storage.Blobs.Models.BlobType? track2type)
        {
            if (track2type == null)
            {
                return Azure.Storage.Blob.BlobType.Unspecified;
            }
            switch (track2type.Value)
            {
                case global::Azure.Storage.Blobs.Models.BlobType.Append:
                    return Azure.Storage.Blob.BlobType.AppendBlob;
                case global::Azure.Storage.Blobs.Models.BlobType.Page:
                    return Azure.Storage.Blob.BlobType.PageBlob;
                default:
                    return Azure.Storage.Blob.BlobType.BlockBlob;
            }
        }

        /// <summary>
        /// Convert a directory to hashtable
        /// Used in mata data convert
        /// </summary>
        public static Hashtable GetHashtableFromDictionary(IDictionary<string, string> dic)
        {
            if (dic == null)
            {
                return null;
            }
            Hashtable table = new Hashtable();
            foreach (string key in dic.Keys)
            {
                table.Add(key, dic[key]);
            }
            return table;
        }

        /// <summary>
        /// Get the Blob Type of the Track2 Blob client type
        /// </summary>
        /// <param name="blob"></param>
        /// <param name="CheckOnServer"> If Track2 blob Client don't contain blob type inforamtion, try to get it on server</param>
        public static global::Azure.Storage.Blobs.Models.BlobType? GetBlobType(BlobBaseClient blob, bool CheckOnServer = false)
        {
            if (blob is BlockBlobClient)
            {
                return global::Azure.Storage.Blobs.Models.BlobType.Block;
            }
            if (blob is PageBlobClient)
            {
                return global::Azure.Storage.Blobs.Models.BlobType.Page;
            }
            if (blob is AppendBlobClient)
            {
                return global::Azure.Storage.Blobs.Models.BlobType.Append;
            }
            if (!CheckOnServer)
            {
                return null;
            }
            else
            {
                return blob.GetProperties().Value.BlobType;
            }
        }

        public static BlobBaseClient GetTrack2BlobClient(BlobContainerClient track2container, string blobName, AzureStorageContext context, string versionId = null, bool? IsCurrentVersion = null, string snapshot = null, BlobClientOptions options = null, global::Azure.Storage.Blobs.Models.BlobType? blobType = null)
        {
            //Get Track2 Blob Client
            BlobBaseClient blobClient;
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(track2container.Uri)
            {
                BlobName = blobName
            };
            if (context.StorageAccount.Credentials.IsToken) //Oauth
            {
                if (blobType == null)
                {
                    blobClient = new BlobBaseClient(blobUriBuilder.ToUri(), context.Track2OauthToken, options);
                }
                else
                {
                    switch (blobType.Value)
                    {
                        case global::Azure.Storage.Blobs.Models.BlobType.Page:
                            blobClient = new PageBlobClient(blobUriBuilder.ToUri(), context.Track2OauthToken, options);
                            break;
                        case global::Azure.Storage.Blobs.Models.BlobType.Append:
                            blobClient = new AppendBlobClient(blobUriBuilder.ToUri(), context.Track2OauthToken, options);
                            break;
                        default: //Block
                            blobClient = new BlockBlobClient(blobUriBuilder.ToUri(), context.Track2OauthToken, options);
                            break;
                    }
                }
            }
            else  //sas , key or Anonymous, use connection string
            {
                string connectionString = context.ConnectionString;

                // remove the "?" at the begin of SAS if any
                if (context.StorageAccount.Credentials.IsSAS)
                {
                    connectionString = connectionString.Replace("SharedAccessSignature=?", "SharedAccessSignature=");
                }

                if (blobType == null)
                {
                    blobClient = new BlobBaseClient(connectionString, track2container.Name, blobName, options);
                }
                else
                {
                    switch (blobType.Value)
                    {
                        case global::Azure.Storage.Blobs.Models.BlobType.Page:
                            blobClient = new PageBlobClient(connectionString, track2container.Name, blobName, options);
                            break;
                        case global::Azure.Storage.Blobs.Models.BlobType.Append:
                            blobClient = new AppendBlobClient(connectionString, track2container.Name, blobName, options);
                            break;
                        default: //Block
                            blobClient = new BlockBlobClient(connectionString, track2container.Name, blobName, options);
                            break;
                    }
                }
            }
            if (versionId != null && (IsCurrentVersion == null || !IsCurrentVersion.Value)) // only none current version blob need versionId in Uri
            {
                blobClient = blobClient.WithVersion(versionId);
            }
            blobClient = blobClient.WithSnapshot(snapshot);
            return blobClient;
        }

        public static BlobBaseClient GetTrack2BlobClientWithType(BlobBaseClient blob, AzureStorageContext context, global::Azure.Storage.Blobs.Models.BlobType blobType, BlobClientOptions options = null)
        {
            BlobBaseClient blobClient;
            if (context.StorageAccount.Credentials.IsToken) //Oauth
            {
                switch (blobType)
                {
                    case global::Azure.Storage.Blobs.Models.BlobType.Page:
                        blobClient = new PageBlobClient(blob.Uri, context.Track2OauthToken, options);
                        break;
                    case global::Azure.Storage.Blobs.Models.BlobType.Append:
                        blobClient = new AppendBlobClient(blob.Uri, context.Track2OauthToken, options);
                        break;
                    default: //Block
                        blobClient = new BlockBlobClient(blob.Uri, context.Track2OauthToken, options);
                        break;
                }
            }
            else  //sas , key or Anonymous, use connection string
            {
                string connectionString = context.ConnectionString;

                // remove the "?" at the begin of SAS if any
                if (context.StorageAccount.Credentials.IsSAS)
                {
                    connectionString = connectionString.Replace("SharedAccessSignature=?", "SharedAccessSignature=");
                }
                switch (blobType)
                {
                    case global::Azure.Storage.Blobs.Models.BlobType.Page:
                        blobClient = new PageBlobClient(connectionString, blob.BlobContainerName, blob.Name, options);
                        break;
                    case global::Azure.Storage.Blobs.Models.BlobType.Append:
                        blobClient = new AppendBlobClient(connectionString, blob.BlobContainerName, blob.Name, options);
                        break;
                    default: //Block
                        blobClient = new BlockBlobClient(connectionString, blob.BlobContainerName, blob.Name, options);
                        break;
                }
            }
            return blobClient;
        }

        public static BlobServiceClient GetTrack2BlobServiceClient(AzureStorageContext context, BlobClientOptions options = null)
        {
            BlobServiceClient blobServiceClient;
            if (context.StorageAccount.Credentials.IsToken) //Oauth
            {
                blobServiceClient = new BlobServiceClient(context.StorageAccount.BlobEndpoint, context.Track2OauthToken, options);
            }
            else  //sas , key or Anonymous, use connection string
            {
                string connectionString = context.ConnectionString;

                // remove the "?" at the begin of SAS if any
                if (context.StorageAccount.Credentials.IsSAS)
                {
                    connectionString = connectionString.Replace("SharedAccessSignature=?", "SharedAccessSignature=");
                }
                blobServiceClient = new BlobServiceClient(connectionString, options);
            }
            return blobServiceClient;
        }

        /// <summary>
        /// Validate if Start Time and Expire time meet the requirement of userDelegationKey
        /// </summary>
        /// <param name="userDelegationKeyStartTime"></param>
        /// <param name="userDelegationKeyEndTime"></param>
        public static void ValidateUserDelegationKeyStartEndTime(DateTimeOffset userDelegationKeyStartTime, DateTimeOffset userDelegationKeyEndTime)
        {
            //Check the Expire Time and Start Time, should remove this if server can rerturn clear error message
            const double MAX_LIFE_TIME_DAYS = 7;
            TimeSpan maxLifeTime = TimeSpan.FromDays(MAX_LIFE_TIME_DAYS);
            if (userDelegationKeyEndTime <= DateTimeOffset.UtcNow)
            {
                throw new ArgumentException(string.Format("Expiry time {0} is earlier than now.", userDelegationKeyEndTime.ToString()));
            }
            else if (userDelegationKeyStartTime >= userDelegationKeyEndTime)
            {
                throw new ArgumentException(string.Format("Start time {0} is later than expiry time {1}.", userDelegationKeyStartTime.ToString(), userDelegationKeyEndTime.ToString()));
            }
            else if (userDelegationKeyEndTime - DateTimeOffset.UtcNow > maxLifeTime)
            {
                throw new ArgumentException(string.Format("Generate User Delegation SAS with OAuth bases Storage context. User Delegate Key expiry time {0} must be in {1} days from now.",
                    userDelegationKeyEndTime.ToString(),
                    MAX_LIFE_TIME_DAYS));
            }
        }

        public static global::Azure.Storage.Blobs.Models.AccessTier? ConvertAccessTier_Track1ToTrack2(PremiumPageBlobTier? pageBlobTier)
        {
            if (pageBlobTier == null)
            {
                return null;
            }

            switch(pageBlobTier)
            {
                case PremiumPageBlobTier.P4:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P4;
                case PremiumPageBlobTier.P6:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P6;
                case PremiumPageBlobTier.P10:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P10;
                case PremiumPageBlobTier.P20:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P20;
                case PremiumPageBlobTier.P30:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P30;
                case PremiumPageBlobTier.P40:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P40;
                case PremiumPageBlobTier.P50:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P50;
                case PremiumPageBlobTier.P60:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P60;
                case PremiumPageBlobTier.P70:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P70;
                case PremiumPageBlobTier.P80:
                    return global::Azure.Storage.Blobs.Models.AccessTier.P80;
                default:
                    return null;
            }
        }

        public static global::Azure.Storage.Blobs.Models.AccessTier? ConvertAccessTier_Track1ToTrack2(StandardBlobTier? standardBlobTier)
        {
            if (standardBlobTier == null)
            {
                return null;
            }

            switch (standardBlobTier)
            {
                case StandardBlobTier.Hot:
                    return global::Azure.Storage.Blobs.Models.AccessTier.Hot;
                case StandardBlobTier.Cool:
                    return global::Azure.Storage.Blobs.Models.AccessTier.Cool;
                case StandardBlobTier.Archive:
                    return global::Azure.Storage.Blobs.Models.AccessTier.Archive;
                default:
                    return null;
            }
        }

        public static global::Azure.Storage.Blobs.Models.RehydratePriority? ConvertRehydratePriority_Track1ToTrack2(RehydratePriority? rehydratePriority)
        {
            if (rehydratePriority == null)
            {
                return null;
            }

            switch (rehydratePriority)
            {
                case RehydratePriority.High:
                    return global::Azure.Storage.Blobs.Models.RehydratePriority.High;
                case RehydratePriority.Standard:
                    return global::Azure.Storage.Blobs.Models.RehydratePriority.Standard;
                default:
                    return null;
            }
        }
    }
}
