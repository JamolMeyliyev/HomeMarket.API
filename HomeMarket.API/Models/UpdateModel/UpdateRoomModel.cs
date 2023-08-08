using HomeMarket.API.Entities;

namespace HomeMarket.API.Models.UpdateModel;

public class UpdateRoomModel
{
    public ERoomType? Type { get; set; }
    public EComfort? ComfortType { get; set; }
    public float? Length { get; set; }
    public float? Width { get; set; }
}
