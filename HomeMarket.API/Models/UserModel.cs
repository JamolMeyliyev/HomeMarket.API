using HomeMarket.API.Entities;

namespace HomeMarket.API.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public List<Cart>? Carts { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}
public static class ExtensionUser
{
    public static UserModel ToModel(this User user)
    {
        return new UserModel()
       {
           Id= user.Id,
           FirstName= user.FirstName,
           LastName= user.LastName,
           Email= user.Email,
           PasswordHash= user.PasswordHash,
           Carts= user.Carts,
       };
    }
}
