using HomeMarket.API.Context;
using HomeMarket.API.Entities;
using HomeMarket.API.Exceptions;
using HomeMarket.API.Models;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeMarket.API.Managers;

public class UserManager:IUserManager
{
    private readonly AppDbContext _context;
    public UserManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserModel> CreateUser(CreateUserModel model)
    {
        var user = new User()
        {
            LastName = model.LastName,
            Email = model.Email,
            FirstName = model.FirstName,
            Carts = new List<Cart>(),
            PasswordHash  = model.Password
        };
        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.ToModel();
    }

    public Task DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel> GetUser(Guid userId)
    {
        var user =  await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new NotFoundException("User");
        }
        return user.ToModel();
    }
    public async Task<User> GetUserByUserId(Guid userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new NotFoundException("User");
        }
        return user;
    }

    public async Task<List<UserModel>> GetUsers()
    {
        var users = await _context.Users.Select(u => u.ToModel()).ToListAsync();
        return users;
    }

    public async Task<UserModel> UpdateUser(User user, UpdateUserModel model)
    {
        user.LastName = model.LastName ?? user.LastName;
        user.FirstName = model.FirstName ?? user.FirstName;
        user.Email = model.Email?? user.Email;
        if(model.Password is not null)
        {
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);
        }
        await _context.SaveChangesAsync();
        return user.ToModel();
    }


    

   
}
