using HomeMarket.API.Exceptions;
using HomeMarket.API.FilterModels;
using HomeMarket.API.Managers;
using HomeMarket.API.Models.CreateModels;
using HomeMarket.API.Models.UpdateModel;
using Microsoft.AspNetCore.Mvc;

namespace HomeMarket.API.Controllers
{
    [Route("api/homes/{homeId}/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomManager _roomManager;
        private readonly IHomeManager _homeManager;
        public RoomsController(IRoomManager roomManager, IHomeManager homeManager)
        {
            _roomManager = roomManager;
            _homeManager = homeManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoomsByRoomFilter(Guid homeId, [FromQuery] RoomFilter filter)
        {
            try
            {
              return Ok( await _roomManager.GetAllRooms(homeId,filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(Guid homeId, [FromBody]CreateRoomModel model)
        {
            try
            {   var roomModel  = await _roomManager.CreateRoom(homeId,model);
                var room = await _roomManager.GetRoomByRoomId(homeId,roomModel.Id); 
                var home = await _homeManager.GetHomeByHomeId(homeId);
                await _homeManager.AddRoomByHomeId(home, room);
                return Ok(roomModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoomByRoomId(Guid homeId,Guid roomId)
        {
            try
            {
               return Ok( await _roomManager.GetRoomByRoomId(homeId,roomId));
                
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{roomId}")]
        public async Task<IActionResult> UpdateRoom(Guid homeId, Guid roomId,UpdateRoomModel model)
        {
            try
            {
                var room = await _roomManager.GetRoomByRoomId(homeId,roomId);
                return Ok(await _roomManager.UpdateRoom(room,model));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteRoom(Guid homeId,Guid roomId)
        {
            try
            {
                var room = await _roomManager.GetRoomByRoomId(homeId, roomId);
                
                await _roomManager.DeleteRoom(room);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
