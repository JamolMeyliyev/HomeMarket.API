using HomeMarket.API.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HomeMarket.API.Models.CreateModels;

public class CreateUserModel
{
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    [Compare("Password")]
    public required string ConfirmPassword { get; set; }
}
