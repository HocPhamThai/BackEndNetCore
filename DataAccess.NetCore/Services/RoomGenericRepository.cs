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
    public class RoomGenericRepository : GenericRepository<HB_Rooms>, IRoomGenericRepository
    {
        public RoomGenericRepository(ApplicationBEDbContext context) : base(context)
        {
        }
    }
}
