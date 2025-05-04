using DataAccess.NetCore.Data;
using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationBEDbContext _context;
        public RoomRepository(ApplicationBEDbContext context)
        {
            _context = context;
        }
        public Task<List<HB_Rooms>> Room_GetAll(Room_GetAllRequestData requestData)
        {
            var list = new List<HB_Rooms>();
            try
            { 
                list = _context.Room.ToList();
                if (requestData != null)
                {
                    if (!string.IsNullOrEmpty(requestData.RoomNumber))
                    {
                        list = list.FindAll(x => x.RoomNumber.ToLower().Contains(requestData.RoomNumber)).ToList();
                    }
                }
                return Task.FromResult(list);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ReturnData> Room_Insert(Room_InsertRequestData requestData)
        {
            ReturnData returnData = new ReturnData();
            try
            {
                if (requestData == null || requestData.HotelID <= 0 || string.IsNullOrEmpty(requestData.RoomNumber) || requestData.IsActive < 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Dữ liệu không hợp lệ";
                    return returnData;
                }

                var req = new HB_Rooms()
                {
                    HotelID = requestData.HotelID,
                    RoomNumber = requestData.RoomNumber,
                    RoomSquare = requestData.RoomSquare,
                    IsActive = requestData.IsActive
                };

                _context.Room.Add(req);

                var rs = _context.SaveChanges();
                if (rs == 0)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMessage = "Lưu thất bại";
                    return returnData;
                }

                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Lưu thành công";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -99;
                returnData.ReturnMessage = ex.Message;
                return returnData;
            }
        }

        public async Task<ReturnData> Room_Update(Room_UpdateRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                if (requestData == null || requestData.RoomID <= 0 || requestData.HotelID <= 0 || string.IsNullOrEmpty(requestData.RoomNumber) || requestData.IsActive < 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Dữ liệu không hợp lệ";
                    return returnData;
                }
                var req = _context.Room.FirstOrDefault(x => x.RoomID == requestData.RoomID);
                if (req == null)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMessage = "Không tìm thấy phòng";
                    return returnData;
                }
                req.HotelID = requestData.HotelID;
                req.RoomNumber = requestData.RoomNumber;
                req.RoomSquare = requestData.RoomSquare;
                req.IsActive = requestData.IsActive;
                var rs = _context.SaveChanges();
                if (rs == 0)
                {
                    returnData.ReturnCode = -3;
                    returnData.ReturnMessage = "Cập nhật thất bại";
                    return returnData;
                }
                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Cập nhật thành công";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -99;
                returnData.ReturnMessage = ex.Message;
                return returnData;
            }
        }

        public async Task<ReturnData> Room_Delete(int roomId)
        {
            var returnData = new ReturnData();
            try
            {
                if (roomId <= 0)
                {
                    returnData.ReturnCode = -1;
                    returnData.ReturnMessage = "Dữ liệu không hợp lệ";
                    return returnData;
                }
                var req = _context.Room.FirstOrDefault(x => x.RoomID == roomId);
                if (req == null)
                {
                    returnData.ReturnCode = -2;
                    returnData.ReturnMessage = "Không tìm thấy phòng";
                    return returnData;
                }
                _context.Room.Remove(req);
                var rs = _context.SaveChanges();
                if (rs == 0)
                {
                    returnData.ReturnCode = -3;
                    returnData.ReturnMessage = "Xóa thất bại";
                    return returnData;
                }
                returnData.ReturnCode = 1;
                returnData.ReturnMessage = "Xóa thành công";
                return returnData;
            }
            catch (Exception ex)
            {
                returnData.ReturnCode = -99;
                returnData.ReturnMessage = ex.Message;
                return returnData;
            }
        }

    }
}
