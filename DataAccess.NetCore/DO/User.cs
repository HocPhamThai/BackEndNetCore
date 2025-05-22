using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }   
        public string? RefreshToken { get; set; }   
        public DateTime Expired { get; set; }
    }
}
