using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Repos
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUserNameAndPassword(string userName, string password);
        Task CreateUser(UserDto userDto);
        string GetMd5Hash(string password);
    }
}