using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services
{
    public interface IUserService
    {
        string GetMd5Hash(string password);
        Task<User> GetUserByUserNameAndPassword(string userName, string password);
        Task CreateUser(User user);
    }
}
