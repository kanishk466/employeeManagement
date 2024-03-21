using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ems.Models.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeService(IEmsDatabaseSetting setting ,IMongoClient mongoClient) {

            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _employee = database.GetCollection<Employee>(setting.EmployeeCollectionName);
        
        }

        public async Task<IEnumerable<Employee>> GetAllAsyc()
        {
            // Define the pipeline for the aggregation query
            var pipeline = new BsonDocument[]
            {
              new BsonDocument("$lookup", new BsonDocument
              {
                { "from", "User" },
                { "localField", "UserId" },
                { "foreignField", "_id" },
                { "as", "user_data" }
              }),
              new BsonDocument("$unwind", "user_data"),
              new BsonDocument("$project", new BsonDocument
              {
                { "_id", 1 },
                { "UserId", 1},
                { "Code",1 },
                { "UserName", "user_data" }
              })
            };

            var results = await _employee.Aggregate<Employee>(pipeline).ToListAsync();

            return results;
        }






        public Employee Create(Employee employee)
        {
            _employee.InsertOne(employee);
            return employee;
        }

        public List<Employee> Get()
        {
            return _employee.Find(employee => true).ToList();
        }

        public Employee Get(string id)
        {
            return _employee.Find(employee => employee.EmployeeID == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _employee.DeleteOne(employee => employee.EmployeeID == id);
        }

        public void Update(string id, Employee employee)
        {
            _employee.ReplaceOne(employee => employee.EmployeeID == id, employee);
        }
    }
}
