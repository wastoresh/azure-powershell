using Azure.ResourceManager;
using Track2 = Azure.ResourceManager.Storage;
using Track2Model = Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Resources;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System.Collections.Generic;
using Azure.ResourceManager.Storage;
using Azure;
using Azure.Core;

namespace Microsoft.Azure.Commands.Management.Storage
{
    public class Track2StorageManagementClient
    {
        private ArmClient _armClient;
        private string _subscription;
        private IClientFactory _clientFactory;

        public Track2StorageManagementClient(IClientFactory clientFactory, IAzureContext context)
        {
            _clientFactory = clientFactory;
            _armClient = _clientFactory.CreateArmClient(context, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
            _subscription = context.Subscription.Id;
        }

        /// <summary>
        /// Get resource group instance
        /// </summary>
        /// <param name="resourcegroup"></param>
        public ResourceGroup GetResourceGroup(string resourcegroup) =>
            _armClient.GetResourceGroup(new ResourceIdentifier(
                string.Format("/subscriptions/{0}/resourceGroups/{1}", _subscription, resourcegroup)));

        /// <summary>
        /// List accounts from subscription
        /// </summary>
        public Pageable<Track2.StorageAccount> ListStorageAccounts() =>
            _armClient.GetSubscription(new ResourceIdentifier(
                string.Format("/subscriptions/{0}", _subscription))).GetStorageAccounts();

        /// <summary>
        /// List accounts from Resource group
        /// </summary>
        public Pageable<Track2.StorageAccount> ListStorageAccounts(string resourcegroup) =>
            GetResourceGroup(resourcegroup).GetStorageAccounts().GetAll();

        /// <summary>
        /// Get single storage account
        /// </summary>
        public Track2.StorageAccount GetStorageAccount(string resourcegroup, string storageAccountName) =>
            _armClient.GetStorageAccount(Track2.StorageAccount.CreateResourceIdentifier(_subscription, resourcegroup, storageAccountName));

        //public Track2Model.StorageAccount CreateStorageAccount(string resourcegroup, string storageAccountName, Track2Model.StorageAccountCreateParameters parameters) =>
        //    GetResourceGroup(resourcegroup).GetStorageAccounts().CreateOrUpdate(storageAccountName, parameters).Value;
        
    }
}
