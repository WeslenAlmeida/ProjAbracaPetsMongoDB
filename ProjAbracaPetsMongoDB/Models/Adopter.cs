using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProjAbracaPetsMongoDB.Models
{
    public class Adopter
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        #endregion
    }
}
