namespace HomeMarket.API.Entities;

public class Discount
{
    public Guid Id { get; set; }
    public Guid? HomeId { get; set; }
    public Home? Home { get; set; }
    public int Percentage { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndDate { get; set; }
}
