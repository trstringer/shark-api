using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace SharkData.Models
{
    public class SharkEntity : TableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Binomial { get; set; }
        public int MaxLength { get; set; }

        public static IEnumerable<Shark> GetShark()
        {
            foreach (SharkEntity sharkEntity in (new DataRetriever(ConfigurationManager.ConnectionStrings["AzureTableStorage"].ConnectionString, "sharks").GetAllSharks()))
                yield return new Shark() { Id = sharkEntity.Id, Name = sharkEntity.Name, Binomial = sharkEntity.Binomial, MaxLength = sharkEntity.MaxLength };
        }

        public static Shark GetShark(int id)
        {
            return GetShark().Where(s => s.Id == id).First();
        }

        public static Shark GetShark(string name)
        {
            return GetShark().Where(s => s.Name.ToLower() == name.ToLower()).First();
        }

        public static Shark ModifyShark(int id, Shark shark)
        {
            SharkEntity updatedSharkEntity = new DataRetriever(ConfigurationManager.ConnectionStrings["AzureTableStorage"].ConnectionString, "sharks").ModifyShark(id, shark);

            if (updatedSharkEntity == null)
                return null;
            else
                return new Shark() {
                    Id = updatedSharkEntity.Id,
                    Name = updatedSharkEntity.Name,
                    Binomial = updatedSharkEntity.Binomial,
                    MaxLength = updatedSharkEntity.MaxLength };
        }
    }
}