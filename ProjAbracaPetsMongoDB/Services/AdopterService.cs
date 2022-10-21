using MongoDB.Driver;
using ProjAbracaPetsMongoDB.Models;
using ProjAbracaPetsMongoDB.Utils;
using System.Collections.Generic;
using System.Net;

namespace ProjAbracaPetsMongoDB.Services
{
    public class AdopterService
    {
        private readonly IMongoCollection<Adopter> _adopter;

        public AdopterService(IDataBaseSettings settings)
        {
            var adopter = new MongoClient(settings.ConnectionString);
            var database = adopter.GetDatabase(settings.DataBaseName);
            _adopter = database.GetCollection<Adopter>(settings.AdopterCollectionName);
        }

        public Adopter Create(Adopter adopter)
        {
            _adopter.InsertOne(adopter);
            return adopter;
        }

        public List<Adopter> Get() =>
            _adopter.Find<Adopter>(adopter => true).ToList();

        public Adopter Get(string id) =>
            _adopter.Find<Adopter>(adopter => adopter.Id == id).FirstOrDefault();

        public void Update(string id, Adopter adopterIn) =>
            _adopter.ReplaceOne(adopter => adopter.Id == id, adopterIn);

        public void Remove(string id) =>
           _adopter.DeleteOne(adopter => adopter.Id == id);
    }
}
