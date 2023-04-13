using inzOprogramowania.DataContext;
using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace inzOprogramowania.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _databaseContext;
        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<User> GetUserByUserNameAndPassword(string userName, string password)
        {
            return await _databaseContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
        }
        public async Task CreateUser(User user)
        {
            user.Role = "User";
            user.Password = GetMd5Hash(user.Password);
            _databaseContext.Users.Add(user);
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
