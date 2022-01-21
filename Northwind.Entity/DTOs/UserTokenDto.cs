using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.DTOs
{
    public class UserTokenDto : DtoBase
    {
        public UserLoginDto UserLoginDto { get; set; }
        public object AccessToken { get; set; }
    }
}
