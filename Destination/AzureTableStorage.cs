using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Logger
{
    public class AzureTableStorage<T> : IAzureTableStorage<T> where T : BaseMessage, new()
    {
        private AzureTableSettings azureTableSettings;

        public AzureTableStorage(AzureTableSettings azureTableSettings)
        {
            this.azureTableSettings = azureTableSettings;
        }

        public async Task Insert(T item)
        {
            //Table
            CloudTable table = await GetTableAsync();

            //Operation
            TableOperation operation = TableOperation.Insert(item);

            //Execute
            await table.ExecuteAsync(operation);
        }

        private async Task<CloudTable> GetTableAsync()
        {
            //Account
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                new StorageCredentials(this.azureTableSettings.StorageAccount, this.azureTableSettings.StorageKey), true);

            //Client
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Table
            CloudTable table = tableClient.GetTableReference(this.azureTableSettings.TableName);

            try
            {
                await table.CreateIfNotExistsAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error connecting to Azure - " + e.Message);
            }

            return table;
        }
    }
}