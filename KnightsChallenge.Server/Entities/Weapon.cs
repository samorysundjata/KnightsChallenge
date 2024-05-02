﻿using MongoDB.Bson.Serialization.Attributes;

namespace KnightsChallenge.Server.Entities
{
    public class Weapon
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("mod")]
        public int Mod { get; set; }

        [BsonElement("attr")]
        public string Attr { get; set; }

        [BsonElement("equipped")]
        public bool Equipped { get; set; }
    }
}
