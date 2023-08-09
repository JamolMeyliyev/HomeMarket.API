using HomeMarket.API.Context;
using HomeMarket.API.Entities;
using HomeMarket.API.Exceptions;
using HomeMarket.API.FilterModels;
using HomeMarket.API.Models;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.EntityFrameworkCore;

namespace HomeMarket.API.Managers;
public class HomeManager : IHomeManager
{
    private readonly AppDbContext _context;
    public HomeManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<HomeModel> CreateHome(CreateHomeModel model)
    {
       var price = 600 * model.Area *(((float)model.Type + 1F) / 6 + 1);
        var home = new Home()
        {
            
            Rooms = new List<Room>(),
            Price = price,
            Area = model.Area,
            Type= model.Type,
            EmptyArea = model.Area,
            Dagree = (model.Area * ((int)model.Type +1))/30
        };

        _context.Homes.Add(home);
        await _context.SaveChangesAsync();
        return home.ToModel();
    }

    public async Task<List<HomeModel>> GetAllHome(HomeFilter homeFilter)
    {
       var query = _context.Homes.Include(h => h.Rooms).AsQueryable();
       
       if(homeFilter.RoomCount is not null)
        {
            query = query.Where(h => h.Rooms.Count == homeFilter.RoomCount);
        }
       if(homeFilter.Type is not null)
        {
            query = query.Where(h => h.Type.ToString().Contains(homeFilter.Type));
        }
        if (homeFilter.FromArea is not null)
        {
            query = query.Where(h => h.Area >= homeFilter.FromArea);
        }
        if(homeFilter.ToArea is not null)
        {
            query = query.Where(h => h.Area <= homeFilter.ToArea);
        }
        if (homeFilter.FromPrice is not null)
        {
            query = query.Where(h => h.Price >= homeFilter.FromPrice);
        }
        if (homeFilter.ToPrice is not null)
        {
            query = query.Where(h => h.Price <= homeFilter.ToPrice);
        }
        var hooms = await query.Select(h => h.ToModel()).ToListAsync();

        return hooms;

    }

    public async Task<Home> GetHomeByHomeId(Guid homeId)
    {
       var home = await _context.Homes.Where(h => h.Id == homeId).Include(h => h.Rooms).FirstOrDefaultAsync();
       if(home == null)
        {
            throw new NotFoundException($"{homeId}");
        }
       return home;
    }

    public async Task<HomeModel> GetHomeModelByHomeId(Guid homeId)
    {
        var home = await _context.Homes.Where(h => h.Id == homeId).Include(h => h.Rooms).FirstOrDefaultAsync();
        if(home is null)
        {
            throw new NotFoundException($"{homeId}");
        }
        return home.ToModel();
    }

    public async Task<HomeModel> UpdateHome(Home home, UpdateHomeModel model)
    {
        
        
        if(model.Area != null)
        {

            if(home.Area - home.EmptyArea > (float)model.Area)
            {
                throw new Exception($"Siz uyingizdagi maydonini {home.Area - home.EmptyArea} gacha qisqartira olasiz yoki xonalarni qisqartiring");
            }
            if(home.Area - home.EmptyArea == (float)model.Area)
            {
                throw new Exception("Siz uy yer maydoni maksimal qisqartirdingiz sizda endi xona qo'shish imkoniyati mavjud emas");
            }

            home.Dagree = home.Dagree - (home.Area * ((int)home.Type + 1)) / 30;
            home.Type = model.Type ?? home.Type;
            home.EmptyArea =(float)model.Area - home.Area + home.EmptyArea;
            home.Area = model.Area ?? home.Area;
            home.Dagree = home.Dagree + (home.Area * ((int)home.Type + 1)) / 30;
            home.Price = 600 * home.Area * (((float)home.Type + 1F) / 6 + 1);
        }
        
       
         _context.Homes.Update(home);
         await _context.SaveChangesAsync();
         return home.ToModel();

    }

    public async Task DeleteHome(Home home)
    {
        _context.Homes.Remove(home);
        await _context.SaveChangesAsync();
    }

    public async Task<HomeModel> AddRoomByHomeId(Home home, Room room)
    {
       
            home.EmptyArea = home.EmptyArea - room.Width * room.Length;
            home.Rooms.Add(room);
            await _context.SaveChangesAsync();
        
        
        return home.ToModel();
    }
}
