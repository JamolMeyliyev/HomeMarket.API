namespace HomeMarket.API.FilterModels;

public class HomeFilter
{
    public long? FromPrice { get; set; }
    public long? ToPrice { get; set; }
    public float? FromArea { get; set; }
    public float? ToArea { get; set; }
    public string? Type { get; set; }
    public int? RoomCount { get; set; }
}
