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
            // seed data for Hotel
            modelBuilder.Entity<HB_Hotels>().HasData(
                new HB_Hotels { HotelID = -1, HotelName = "Hotel 1", Description = "Hotel 1", CreatedDate = DateTime.Now },
                new HB_Hotels { HotelID = -2, HotelName = "Hotel 2", Description = "Hotel 2", CreatedDate = DateTime.Now },
                new HB_Hotels { HotelID = -3, HotelName = "Hotel 3", Description = "Hotel 3", CreatedDate = DateTime.Now }
            );
        }
        public DbSet<HB_Rooms>? HB_Rooms { get; set; }
        public DbSet<HB_Hotels>? HB_Hotels { get; set; }    
        public DbSet<User>? User { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<UserPemission> UserPemission { get; set; }
    }
}
