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
    public class HotelGenericRepository : GenericRepository<HB_Hotels>, IHotelGenericRepository
    {
        private readonly ApplicationBEDbContext _context;
        public HotelGenericRepository(ApplicationBEDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
