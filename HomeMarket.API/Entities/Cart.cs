namespace HomeMarket.API.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public Guid HomeId { get; set; }
    public Home? Home { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid DiscountId { get; set; }
    public Discount? Discount { get; set; }
    public long TotalPrice { get; set; }
    public DateTime CreateDate { get; set; }

}
