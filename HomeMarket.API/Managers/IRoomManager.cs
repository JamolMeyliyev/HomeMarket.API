using HomeMarket.API.Entities;
using HomeMarket.API.FilterModels;
using HomeMarket.API.Models;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;

namespace HomeMarket.API.Managers;

public interface IRoomManager
{
    Task<List<RoomModel>> GetAllRooms(Guid homeId,RoomFilter filter);
    Task<Room> GetRoomByRoomId(Guid homeId, Guid roomId);
    Task<RoomModel> CreateRoom(Guid homeId, CreateRoomModel model);
    Task<RoomModel> UpdateRoom( Room room,UpdateRoomModel model);
    Task DeleteRoom( Room room);
}
