// ----------------------------------------------------------------------------------
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
    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    using System.Globalization;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class OAuthUtil
    {
        /// <summary>
        /// Default resourceId for storage OAuth tokens
        /// </summary>
        public const string StorageOAuthEndpointResourceValue = "https://storage.azure.com";

        /// <summary>
        /// The extension key to use for the storage token audience value
        /// </summary>
        public const string StorageOAuthEndpointResourceKey = "StorageOAuthEndpointResourceId";


        public static RenewTokenFuncAsync GetTokenRenewer(IAccessToken accessToken)
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            RenewTokenFuncAsync renewer = async (Object state, CancellationToken cancellationToken) =>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            {
                var tokenStr = GetTokenStrFromAccessToken(accessToken);
                return new NewTokenAndFrequency(tokenStr, new TimeSpan(0, 1, 0));
            };
            return renewer;
        }

        public static IAzureEnvironment EnsureStorageOAuthAudienceSet(IAzureEnvironment environment)
        {
            if (environment != null)
            {
                if (!environment.IsPropertySet(StorageOAuthEndpointResourceKey))
                {
                    environment.SetProperty(StorageOAuthEndpointResourceKey, StorageOAuthEndpointResourceValue);
                }
            }

            return environment;
        }

        /// <summary>
        /// Create a OAuth Token
        /// </summary>
        /// <returns>the token</returns>
        public static IAccessToken CreateOAuthToken(IAzureContext DefaultContext)
        {
            IAccessToken accessToken = AzureSession.Instance.AuthenticationFactory.Authenticate(
               DefaultContext.Account,
               EnsureStorageOAuthAudienceSet(DefaultContext.Environment),
               DefaultContext.Tenant.Id,
               null,
               ShowDialog.Never,
               null,
               StorageOAuthEndpointResourceKey);
            return accessToken;
        }

        /// <summary>
        /// Get the token string from the accesstoken
        /// </summary>
        /// <param name="accessToken">the token</param>
        /// <returns>token string</returns>
        public static string GetTokenStrFromAccessToken(IAccessToken accessToken)
        {
            var tokenStr = string.Empty;
            accessToken.AuthorizeRequest((tokenType, tokenValue) =>
            {
                tokenStr = tokenValue;
            });
            //WriteDebug(DateTime.Now.ToString() + ": token:" + tokenStr);
            return tokenStr;
        }
    }
}
