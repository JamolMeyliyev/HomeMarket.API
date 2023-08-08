using HomeMarket.API.Context;

namespace HomeMarket.API.FilterModels;

public class RoomFilter
{
    public string? Type { get; set; }
    public string? ComfortType { get; set; }
    public float? FromLength { get; set; } 
    public float? FromWidth { get; set; }
    public float? ToLength { get; set; }
    public float? ToWidth { get; set; }
}
