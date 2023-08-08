namespace HomeMarket.API.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public Guid HomeId { get; set; }
    public Home? Home { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public long TotalPrice { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime EndDate { get; set; }

}
