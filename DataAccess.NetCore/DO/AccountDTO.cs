﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class AccountDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
    }

    public class AccountRequestData
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class AccountUpdateRefreshTokenRequestData
    {
        public int? UserID { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expired { get; set; }
    }
}
