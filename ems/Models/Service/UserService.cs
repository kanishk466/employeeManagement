using MongoDB.Driver;

namespace ems.Models.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IEmsDatabaseSetting setting , IMongoClient mongoClient) {

            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _user = database.GetCollection<User>(setting.UserCollectionName);
        
        }
        public User Create(User user)
        {
           _user.InsertOne(user);
            return user;

        }

        public List<User> GetUser() 
        {
            return _user.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _user.Find(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }

        public void Update(string id, User user)
        {
            _user.ReplaceOne(user => user.Id == id, user);
        }
    }
}
