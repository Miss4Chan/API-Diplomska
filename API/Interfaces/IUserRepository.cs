using System;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    Task<AppUser> GetUserByUsernameAsync(string username);
    Task<AppUser> GetUserByUserIdAsync(int userid);
    
}
