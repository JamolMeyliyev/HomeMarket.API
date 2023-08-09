using HomeMarket.API.Managers;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserManager _userManager;
    public UsersController(IUserManager userManager)
    {
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            return Ok(await _userManager.GetUsers());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody]CreateUserModel model)
    {
        try
        {
            return Ok(await _userManager.CreateUser(model));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserByUserId(Guid userId)
    {
        try
        {
            return Ok(await _userManager.GetUser(userId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserModel model)
    {
        try
        {
            var user = await _userManager.GetUserByUserId(userId);
            return Ok(await _userManager.UpdateUser(user,model));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        try
        {
            var user = await _userManager.GetUserByUserId(userId);
            await _userManager.DeleteUser(user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
