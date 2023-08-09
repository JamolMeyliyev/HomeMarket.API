namespace HomeMarket.API.Entities;

public class Discount
{
    public Guid Id { get; set; }  
    public required int Percentage { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndDate { get; set; }
}

