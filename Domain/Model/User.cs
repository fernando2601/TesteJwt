using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [JsonIgnore]
        public string Id { get; set; }

        [BsonElement("Email")]

        public string Email { get; set; }

        [BsonElement("Password")]

        public string Password { get; set; }

    }
}
