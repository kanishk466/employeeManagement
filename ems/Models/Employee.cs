using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ems.Models
{
    public class Employee
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? EmployeeID { get; set; } = string.Empty;

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [BsonElement("updateBy")]
        public string UpdatedBy { get; set; }



        [BsonElement("updateAt")]
        public DateTime UpdatedAt { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;// Reference to the User


        [BsonIgnoreIfNull]
        public string? UserName { get; set; }
        internal void Update(string id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
