using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace ProjAbracaPetsMongoDB.Models
{
    public class Animal
    {

        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        #endregion
    }
}
