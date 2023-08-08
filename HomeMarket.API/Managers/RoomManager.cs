using HomeMarket.API.Context;
using HomeMarket.API.Entities;
using HomeMarket.API.Exceptions;
using HomeMarket.API.FilterModels;
using HomeMarket.API.Models;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.EntityFrameworkCore;

namespace HomeMarket.API.Managers;

public class RoomManager : IRoomManager
{
    private readonly AppDbContext _context;
    public RoomManager(AppDbContext context)
    {
        _context = context;
    }
    public  async Task<RoomModel> CreateRoom(Guid homeId, CreateRoomModel model)
    {
        var room = new Room()
        {
            HomeId= homeId,
            Type = model.Type,
            ComfortType= model.ComfortType,
            Width= model.Width,
            Length= model.Length,
        };
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room.ToModel();
    }

    public async Task DeleteRoom(Room room)
    {
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
    }

    public async Task<List<RoomModel>> GetAllRooms(Guid homeId, RoomFilter filter)
    {

        var query = _context.Rooms.AsQueryable();
        query  = query.Where(r => r.HomeId == homeId);
        if(filter.Type is not null)
        {
            query = query.Where(s => s.Type.ToString().Contains(filter.Type));
        }
        if (filter.ComfortType is not null)
        {
            query = query.Where(s => s.ComfortType.ToString().Contains(filter.ComfortType));
        }
        if(filter.FromLength is not null)
        {
            query = query.Where(s => s.Length >= filter.FromLength);
        }
        if (filter.ToLength is not null)
        {
            query = query.Where(s => s.Length <= filter.ToLength);
        }
        if (filter.FromWidth is not null)
        {
            query = query.Where(s => s.Width >= filter.FromWidth);
        }
        if (filter.ToWidth is not null)
        {
            query = query.Where(s => s.Width <= filter.ToWidth);
        }

        var roomList = await query.Select(s => s.ToModel()).ToListAsync();
        return roomList;
    }

    public async Task<Room> GetRoomByRoomId(Guid homeId,Guid roomId)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(s => s.Id == roomId && s.HomeId == homeId);
        if(room == null)
        {
            throw new NotFoundException("Room");
        }
        return room;
    }

    public async Task<RoomModel> UpdateRoom(Room room,UpdateRoomModel model)
    {
        room.Type = model.Type ?? room.Type;
        room.ComfortType = model.ComfortType ?? room.ComfortType;
        room.Width = model.Width ?? room.Width;
        room.Length = model.Length ?? room.Length;
        await _context.SaveChangesAsync();
        return room.ToModel();
    }

}
