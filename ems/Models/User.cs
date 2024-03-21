using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ems.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        [BsonElement("middleName")]
        public string MiddleName { get; set; } = string.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = string.Empty;

        [BsonElement("mobile")]
        public int Mobile { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("password")]
        public string PasswordHash { get; set; } = string.Empty;

        [BsonElement("registered")]
        public DateTime RegisteredAt { get; set; }


        [BsonElement("intro")]
        public string Intro { get; set; }

        [BsonElement("profile")]
        public string Profile { get; set; }


        [BsonElement("gender")]
        public string Gender { get; set; }



        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("updateBy")]
        public string UpdatedBy { get; set; }

        

        [BsonElement("updateAt")]
        public DateTime UpdatedAt { get; set; }

        internal void Update(string id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
