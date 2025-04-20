using DataAccess.NetCore.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.IServices
{
    public interface IRoomService
    {
        Task<List<HB_Rooms>> Room_GetAll(Room_GetAllRequestData requestData);
        Task<ReturnData> Room_Insert(Room_InsertRequestData requestData);
        Task<ReturnData> Room_Update(Room_UpdateRequestData requestData);
        Task<ReturnData> Room_Delete(int roomId);
    }
}
