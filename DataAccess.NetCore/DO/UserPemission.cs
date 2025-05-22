using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class UserPemission
    {
        [Key]
        public int PemissionID { get; set; }
        public int UserID { get; set; }
        public int FunctionID { get; set; }
        public int? IsView { get; set; }
        public int? IsInsert { get; set; }
        public int? IsDelete { get; set; }
        public int? IsUpdate { get; set; }
        public int? IsExport { get; set; }
    }
}
