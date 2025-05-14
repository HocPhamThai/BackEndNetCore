using DataAccess.NetCore.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRoomGenericRepository RoomGenericRepository { get; set; }
        IHotelGenericRepository HotelGenericRepository { get; set; }
        Task<int> SaveChanges();
    }
}
