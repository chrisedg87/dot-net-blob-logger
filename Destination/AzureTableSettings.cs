using System;

namespace Logger
{
    public class AzureTableSettings
    {
        public string StorageAccount;
        public string StorageKey;
        public string TableName;

        public AzureTableSettings(string storageAccount, string storageKey, string tableName)
        {
            if (string.IsNullOrEmpty(storageAccount))
                throw new ArgumentNullException(nameof(storageAccount));

            if (string.IsNullOrEmpty(storageKey))
                throw new ArgumentNullException(nameof(storageKey));

            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException(nameof(tableName));

            this.StorageAccount = storageAccount;
            this.StorageKey = storageKey;
            this.TableName = tableName;
        }
    }
}