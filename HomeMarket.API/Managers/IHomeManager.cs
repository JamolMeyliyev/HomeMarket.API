using HomeMarket.API.Entities;
using HomeMarket.API.FilterModels;
using HomeMarket.API.Models;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;

namespace HomeMarket.API.Managers;

public interface IHomeManager
{
    Task<List<HomeModel>> GetAllHome(HomeFilter homeFilter);
    Task<HomeModel> GetHomeModelByHomeId(Guid homeId);
    Task<Home> GetHomeByHomeId(Guid homeId);
    Task<HomeModel> CreateHome(CreateHomeModel model);
    Task<HomeModel> UpdateHome(Home home,UpdateHomeModel model);
    Task DeleteHome(Home home);
    Task<HomeModel> AddRoomByHomeId(Home home, Room room);
    
}
