using HomeMarket.API.Controllers;
using HomeMarket.API.Entities;

namespace HomeMarket.API.Models;

public class HomeModel
{
    public Guid Id { get; set; }
    public required List<RoomModel> Rooms { get; set; }
    public float Price { get; set; }
    public float Area { get; set; }
    public EComfort Type { get; set; }
    public float EmptyArea { get; set; }
    public float Dagree { get; set; }
}

public static class ExtensionHomeModel
{
    public static HomeModel ToModel(this Home home)
    {
        var rooms = new List<RoomModel>();
        if (home.Rooms != null)
        {
            foreach (var room in home.Rooms)
            {
                rooms.Add(room.ToModel());
            }
        }
        return new HomeModel
        {
            Id= home.Id,
            Rooms = rooms,
            Price = home.Price,
            Area = home.Area,
            Type = home.Type,
            EmptyArea = home.EmptyArea,
            Dagree = home.Dagree,
            
        };
    }
}
       
