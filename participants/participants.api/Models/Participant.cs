using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace participants.api.Models
{
    public class Participant
    {

        public Participant()
        {
           
        }
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("firstName")]
        public string firstName { get; set; }

        [BsonElement("lastName")]
        public string lastName { get; set; }
        [BsonElement("email")]
        public string email { get; set; }


    }
}