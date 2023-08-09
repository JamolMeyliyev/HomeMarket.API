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
        var home = await _context.Homes.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == homeId);
        if (home == null)
        {
            throw new NotFoundException("Home");
        }
        if (home.EmptyArea < model.Width * model.Length)
        {
            throw new Exception("xona hajmini qisqartiring!!!");

        }

        home.Dagree = home.Dagree + ((int)model.ComfortType + 1) *(float)(home.Rooms.Count+1) * model.Length * model.Length/(20*(home.Rooms.Count+3));
        home.EmptyArea = home.EmptyArea - model.Width * model.Length;

        var room = new Room()
        {
            HomeId= homeId,
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
        
        room.ComfortType = model.ComfortType ?? room.ComfortType;
        room.Width = model.Width ?? room.Width;
        room.Length = model.Length ?? room.Length;
        await _context.SaveChangesAsync();
        return room.ToModel();
    }

}
