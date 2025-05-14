using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelGenericRepository _hotelGenericRepository;
        private readonly IRoomGenericRepository _roomGenericRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HotelsController(IHotelGenericRepository hotelGenericRepository, IRoomGenericRepository roomGenericRepository, IUnitOfWork unitOfWork)
        {
            _hotelGenericRepository = hotelGenericRepository;
            _roomGenericRepository = roomGenericRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> Hotel_GetAll([FromBody] Hotel_GetAllRequestData requestData)
        {
            try
            {
                //var rooms = await _roomService.Hotel_GetAll(requestData);
                var hotels = await _hotelGenericRepository.GetAll();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("Room_Insert")]
        public async Task<IActionResult> Room_Insert([FromBody] Room_InsertRequestData requestData)
        {
            try
            {
                var hotel = new HB_Hotels()
                {
                    CreatedDate = DateTime.Now,
                    Description = "test",
                    HotelName = "lalala"
                };

                var room = new HB_Rooms()
                {
                    RoomID = -1,
                    HotelID = 0,
                    IsActive = 1,
                    RoomNumber = "lalala01",
                    RoomSquare = 1
                };

                await _unitOfWork.RoomGenericRepository.Insert(room);
                await _unitOfWork.HotelGenericRepository.Insert(hotel);

                var result = await _unitOfWork.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
