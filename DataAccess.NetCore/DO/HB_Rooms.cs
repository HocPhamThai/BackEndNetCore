using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class HB_Rooms
    {
        [Key]
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public int RoomSquare { get; set; }
        public int IsActive { get; set; }
    }

    public class Room_GetAllRequestData()
    {
        public string? RoomNumber { get; set; }
    }

    public class Room_InsertRequestData()
    {
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public int RoomSquare { get; set; }
        public int IsActive { get; set; }
    }

    public class Room_UpdateRequestData()
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public int RoomSquare { get; set; }
        public int IsActive { get; set; }
    }
}
