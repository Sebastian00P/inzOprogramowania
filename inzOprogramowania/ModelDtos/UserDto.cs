using inzOprogramowania.Modeles;

namespace inzOprogramowania.ModelDtos
{
    public class UserDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }    

        public UserDto MapUserDto(User user)
        {
            var userDto = new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive             
            };
            return userDto;
        }
    }
}
