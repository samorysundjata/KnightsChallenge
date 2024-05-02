using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KnightsChallenge.Server.Entities
{
    public class Knight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("nickname")]
        public string Nickname { get; set; }

        [BsonElement("birthday")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Birthday { get; set; }

        [BsonElement("weapons")]
        public List<Weapon> Weapons { get; set; }

        [BsonElement("attributes")]
        public Attributes Attributes { get; set; }

        [BsonElement("keyAttribute")]
        public string KeyAttribute { get; set; }

        [BsonElement("isHero")]
        public bool IsHero { get; set; }

        [BsonElement("attack")]
        public int Attack { get; set; }

        [BsonElement("exp")]
        public int Exp { get; set; }
    }
}
