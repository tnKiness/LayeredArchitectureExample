using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LayeredArchitectureExample.Domain.Entities
{
    public class Customer
    {
        [BsonId]
        public ObjectId _id { get; set; }  // Dùng `_id` của MongoDB nhưng không hiển thị trong API

        [BsonElement("Id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
