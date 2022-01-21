using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.DTOs
{
    public class LoginDto : DtoBase
    {
        [Required]
        public string UserCode { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
