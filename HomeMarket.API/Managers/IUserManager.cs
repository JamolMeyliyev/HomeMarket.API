using HomeMarket.API.Context;
using HomeMarket.API.Entities;
using HomeMarket.API.Models;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.EntityFrameworkCore;

namespace HomeMarket.API.Managers;

public interface IUserManager
{
    Task<List<UserModel>> GetUsers();
    Task<UserModel> GetUser(Guid userId);
    Task<User> GetUserByUserId(Guid userId);
    Task<UserModel> CreateUser(CreateUserModel model);
    Task<UserModel> UpdateUser(User user,UpdateUserModel model);
    Task DeleteUser(User user);
}
