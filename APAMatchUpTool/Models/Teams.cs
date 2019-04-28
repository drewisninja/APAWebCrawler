using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APAMatchUpTool.Models
{
    [BsonIgnoreExtraElements]
    public class Teams
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TeamID")]
        public string TeamID { get; set; }

        [BsonElement("TeamName")]
        public string TeamName { get; set; }

        [BsonElement("DvisionID")]
        public string Division { get; set; }

        [BsonElement("HomeLocation")]
        public string Format { get; set; }

    }
}
