using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> Room_GetAll([FromBody] Room_GetAllRequestData requestData)
        {
            try
            {
                var rooms = await _roomService.Room_GetAll(requestData);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Room_Insert([FromBody] Room_InsertRequestData requestData)
        {
            try
            {
                var rs = await _roomService.Room_Insert(requestData);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Room_Update([FromBody] Room_UpdateRequestData requestData)
        {
            try
            {
                var rs = await _roomService.Room_Update(requestData);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Room_Delete([FromBody] int roomId)
        {
            try
            {
                var rs = await _roomService.Room_Delete(roomId);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
