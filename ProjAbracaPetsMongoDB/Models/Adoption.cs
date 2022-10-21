using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace ProjAbracaPetsMongoDB.Models
{
    public class Adoption
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id { get; set; }
        public string AdopterId { get; set; }
        public string AnimalId { get; set; }
        public string DataAdocao { get; set; }
        #endregion
    }
}
