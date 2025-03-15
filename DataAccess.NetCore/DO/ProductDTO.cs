using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Price { get; set; }
        public string? Image { get; set; }
    }

    //public class ProductRequestData
    //{
    //    public string? ProductName { get; set; }
    //    public string? Price { get; set; }
    //    public string? Image { get; set; }
    //}
}
