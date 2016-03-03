using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using SharkData.Models;


namespace SharkData.Models
{
    public class DataRetriever
    {
        private CloudStorageAccount _storageAccount;
        private CloudTable _table;
        private CloudTableClient _tableClient;
        private string _partitionKey;

        public DataRetriever(string azureStorageConnectionString, string tableName) : this(azureStorageConnectionString, tableName, "default") { }
        public DataRetriever(string azureStorageConnectionString, string tableName, string partitionName)
        {
            _storageAccount = CloudStorageAccount.Parse(azureStorageConnectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
            _table = _tableClient.GetTableReference(tableName);
            _partitionKey = partitionName;
        }

        public IEnumerable<SharkEntity> GetAllSharks()
        {
            TableQuery<SharkEntity> query = new TableQuery<SharkEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, _partitionKey));
            return _table.ExecuteQuery(query);
        }

        public SharkEntity ModifyShark(int id, Shark shark)
        {
            TableOperation operation = TableOperation.Retrieve<SharkEntity>(_partitionKey, id.ToString());
            TableResult result = _table.Execute(operation);
            SharkEntity oldSharkEntity = (SharkEntity)result.Result;

            if (oldSharkEntity != null && shark.Id == oldSharkEntity.Id)
            {
                oldSharkEntity.Name = shark.Name;
                oldSharkEntity.Binomial = shark.Binomial;
                oldSharkEntity.MaxLength = shark.MaxLength;
                TableOperation update = TableOperation.Replace(oldSharkEntity);
                _table.Execute(update);

                return oldSharkEntity;
            }

            return null;
        }
    }
}