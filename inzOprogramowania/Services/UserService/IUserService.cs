﻿using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services
{
    public interface IUserService
    {
        string GetMd5Hash(string password);
        Task<UserDto> GetUserByUserNameAndPassword(string userName, string password);
        Task CreateUser(UserDto user);
    }
}
