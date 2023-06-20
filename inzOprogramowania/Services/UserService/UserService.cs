using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using inzOprogramowania.Repos;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace inzOprogramowania.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> GetUserByUserNameAndPassword(string userName, string password)
        {
            return await _userRepository.GetUserByUserNameAndPassword(userName, password);
        }
        public async Task CreateUser(UserDto user)
        {
          await _userRepository.CreateUser(user);
        }
        public string GetMd5Hash(string password)
        {
           return _userRepository.GetMd5Hash(password);
        }
    }
}
