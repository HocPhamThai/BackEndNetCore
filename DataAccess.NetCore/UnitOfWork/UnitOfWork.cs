using DataAccess.NetCore.Data;
using DataAccess.NetCore.IServices;
using DataAccess.NetCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IRoomGenericRepository RoomGenericRepository { get; set; }
        public IHotelGenericRepository HotelGenericRepository { get; set; }
        private readonly ApplicationBEDbContext _context;

        public UnitOfWork(IRoomGenericRepository roomGenericRepository, IHotelGenericRepository hotelGenericRepository, ApplicationBEDbContext context) 
        {
            RoomGenericRepository = roomGenericRepository;
            HotelGenericRepository = hotelGenericRepository;
            _context = context;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
