using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MheanMaa.Models
{
    public class Dog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string[] Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string AgeUnit { get; set; }

        public string Sex { get; set; }

        public string Description { get; set; }

        public bool IsAlive { get; set; }

        public string CollarColor { get; set; }

        public string Caretaker { get; set; }

        public string[] CaretakerPhone { get; set; }

        public string Location { get; set; }
    }
}
