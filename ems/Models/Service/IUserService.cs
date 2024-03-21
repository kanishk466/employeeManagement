namespace ems.Models.Service
{
    public interface IUserService
    {

        List<User> GetUser();

        User Get(string id);
        User Create(User user);
        void Update(string id,User user);

        void Remove(string id);
    }
}
