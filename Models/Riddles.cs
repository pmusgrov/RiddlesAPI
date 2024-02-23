using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiddlesAPI.Models
{
    public class Riddles
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int Number { get; set; }

        public string Riddle { get; set; } = null!;

        public string Answer { get; set; } = null!;
    }
}
