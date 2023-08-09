using HomeMarket.API.Entities;

namespace HomeMarket.API.Models.UpdateModel;

public class UpdateRoomModel
{
    public EComfort? ComfortType { get; set; }
    public float? Length { get; set; }
    public float? Width { get; set; }
}
