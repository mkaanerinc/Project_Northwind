﻿using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.DTOs
{
    public class UserLoginDto : DtoBase
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }

        public string UserCode { get; set; }

    }
}
