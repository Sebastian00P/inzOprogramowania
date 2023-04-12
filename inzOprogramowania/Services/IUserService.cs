using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services
{
    public interface IUserService
    {
        public string GetMd5Hash(string password);
        public Task<User> GetUserByUserNameAndPassword(string userName, string password);
    }
}
