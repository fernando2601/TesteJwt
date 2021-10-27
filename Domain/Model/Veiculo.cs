using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class Veiculo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }


        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NumeroPassageiros { get; set; }
        public bool Automatico { get; set; }

    }
}
