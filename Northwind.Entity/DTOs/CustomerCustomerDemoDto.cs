using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.DTOs
{
    public  class CustomerCustomerDemoDto : DtoBase
    {
        public string CustomerId { get; set; }
        public string CustomerTypeId { get; set; }
    }
}
