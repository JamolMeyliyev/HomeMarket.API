namespace HomeMarket.API.Entities;

public class User
{
    public Guid Id { get; set; }
    public List<Cart>? Carts { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}
