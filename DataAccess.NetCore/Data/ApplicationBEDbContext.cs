using DataAccess.NetCore.DO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.Data
{
    public class ApplicationBEDbContext : DbContext
    {
        public ApplicationBEDbContext(DbContextOptions<ApplicationBEDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data for Room
            modelBuilder.Entity<HB_Rooms>().HasData(
                new HB_Rooms { RoomID = -1, HotelID = 0, RoomNumber = "lalala01", RoomSquare = 1, IsActive = 0 },
                new HB_Rooms { RoomID = -2, HotelID = 0, RoomNumber = "lalala02", RoomSquare = 1, IsActive = 0 },
                new HB_Rooms { RoomID = -3, HotelID = 0, RoomNumber = "lalala03", RoomSquare = 1, IsActive = 0 }
            );
        }        
        public DbSet<HB_Rooms> Room { get; set; }
    }
}
