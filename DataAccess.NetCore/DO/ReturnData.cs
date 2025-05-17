using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string? ReturnMessage { get; set; }
    }

    public class LoginResponseData : ReturnData
    {
        public User? User { get; set; }
        public string? Token { get; set; }  
    }

}
