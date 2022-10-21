using MongoDB.Driver;
using ProjAbracaPetsMongoDB.Models;
using ProjAbracaPetsMongoDB.Utils;
using System.Collections.Generic;

namespace ProjAbracaPetsMongoDB.Services
{
    public class AdoptionService
    {
        private readonly IMongoCollection<Adoption> _adoption;

        public AdoptionService(IDataBaseSettings settings)
        {
            var adoption = new MongoClient(settings.ConnectionString);
            var database = adoption.GetDatabase(settings.DataBaseName);
            _adoption = database.GetCollection<Adoption>(settings.AdoptionCollectionName);
        }

        public Adoption Create(Adoption adoption)
        {
            _adoption.InsertOne(adoption);
            return adoption;
        }

        public List<Adoption> Get() =>
            _adoption.Find<Adoption>(adoption => true).ToList(); 

        public Adoption Get(string id) =>
            _adoption.Find<Adoption>(adoption => adoption.Id == id).FirstOrDefault();

        public void Update(string id, Adoption adoptionIn) =>
            _adoption.ReplaceOne(adoption => adoption.Id == id, adoptionIn);

        public void Remove(string id) =>
           _adoption.DeleteOne(adoption => adoption.Id == id);
    }
}
