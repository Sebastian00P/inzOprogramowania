using inzOprogramowania.ModelDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inzOprogramowania.Modeles
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Ads>? Ads { get; set;}
        public virtual ICollection<Comments>? Comments { get; set;  }

        public User MapUser(UserDto userDto)
        {
            var user = new User()
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Password = userDto.Password,
                Email = userDto.Email,
                Role = userDto.Role,
                IsActive = userDto.IsActive
          
            };
            return user;
        }
    }
}
