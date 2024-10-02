using System;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class UserRepository(DataContext _context) : IUserRepository
{
    public async Task<AppUser> GetUserByUserIdAsync(int userid)
    {
       var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userid) ?? throw new Exception("User not found");
        return user;
    }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username) ?? throw new Exception("User not found");
        return user;
    }
}