using HomeMarket.API.Entities;

namespace HomeMarket.API.Models.CreateModels
{
    public class CreateRoomModel
    {
        public ERoomType Type { get; set; }
        public EComfort ComfortType { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
    }
}
