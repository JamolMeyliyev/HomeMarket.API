using HomeMarket.API.FilterModels;
using HomeMarket.API.Managers;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeMarket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomesController : ControllerBase
{
    private readonly IHomeManager _homeManager;
    private readonly IRoomManager _roomManager;
    public HomesController(IHomeManager homeManager, IRoomManager roomManager)
    {
        _homeManager = homeManager;
        _roomManager = roomManager;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllHomes([FromQuery] HomeFilter filter)
    {
        try
        {
            return Ok(await _homeManager.GetAllHome(filter));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateHome([FromBody]CreateHomeModel model)
    {
        try
        {
            return Ok(await _homeManager.CreateHome(model));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{homeId}")]
    public async Task<IActionResult> GetHomeByHomeId(Guid homeId)
    {
        try
        {
            return Ok(await _homeManager.GetHomeByHomeId(homeId));  
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{homeId}")]
    public async Task<IActionResult> UpdateHome(Guid homeId,UpdateHomeModel model)
    {
        try
        {
            var home = await _homeManager.GetHomeByHomeId(homeId);
            return Ok(await _homeManager.UpdateHome(home,model));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{homeId}")]
    public async Task<IActionResult> DeleteHome(Guid homeId)
    {
        try
        {
            var home = await _homeManager.GetHomeByHomeId(homeId);
            await _homeManager.DeleteHome(home);
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    
}
