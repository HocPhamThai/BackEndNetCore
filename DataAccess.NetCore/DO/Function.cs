﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.NetCore.DO
{
    public class Function
    {
        [Key]
        public int FunctionID { get; set; }
        public string? FunctionCode { get; set; }
        public string? FunctionName { get; set; }
    }
}
