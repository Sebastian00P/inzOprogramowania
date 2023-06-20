using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace inzOprogramowania.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<UserDto> GetUserByUserNameAndPassword(string userName, string password)
        {
            var user = await _databaseContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
            var userDto = new UserDto().MapUserDto(user);
            
            return userDto;
        }
        public async Task CreateUser(UserDto userDto)
        {
            userDto.Role = "User";
            userDto.Password = GetMd5Hash(userDto.Password);
            var user = new User();
            _databaseContext.Users.Add(user.MapUser(userDto));
            await _databaseContext.SaveChangesAsync();
        }
        public string GetMd5Hash(string password)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
