using HomeMarket.API.Entities;

namespace HomeMarket.API.Models.UpdateModel;

public class UpdateUserModel
{ 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
