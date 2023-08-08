using HomeMarket.API.Entities;
using System.Runtime.CompilerServices;

namespace HomeMarket.API.Models;

public class RoomModel
{
    public Guid Id { get; set; }
    public Guid HomeId { get; set; }
    public ERoomType Type { get; set; }
    public EComfort ComfortType { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
}

public static class ExtensionRoomModel
{
    public static RoomModel ToModel(this Room room)
    {
        return new RoomModel
        {
            Id = room.Id,
            HomeId = room.HomeId,
            Type = room.Type,
            Length = room.Length,
            Width = room.Width,
        };
    }
}