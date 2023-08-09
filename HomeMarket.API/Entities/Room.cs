using System.Text.Json.Serialization;

namespace HomeMarket.API.Entities;

public class Room
{
    public Guid Id { get; set; }
    public Guid HomeId { get; set; }
    [JsonIgnore]
    public Home? Home { get; set; }
    public EComfort ComfortType { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
}
