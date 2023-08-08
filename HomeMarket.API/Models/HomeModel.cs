using HomeMarket.API.Controllers;
using HomeMarket.API.Entities;

namespace HomeMarket.API.Models;

public class HomeModel
{
    public Guid Id { get; set; }
    public required List<Room> Rooms { get; set; }
    public long Price { get; set; }
    public float Area { get; set; }
    public EComfort Type { get; set; }
    public float EmptyArea { get; set; }
}

public static class ExtensionHomeModel
{
    public static HomeModel ToModel(this Home home)
    {
        var rooms = new List<Room>();
        if (home.Rooms != null)
        {
            foreach (var room in home.Rooms)
            {
                rooms.Add(room);
            }
        }
        return new HomeModel
        {
            Id= home.Id,
            Rooms = rooms,
            Price = home.Price,
            Area = home.Area,
            Type = home.Type
        };
    }
}
       
