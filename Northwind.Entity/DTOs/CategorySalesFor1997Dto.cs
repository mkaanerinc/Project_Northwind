using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.DTOs
{
    public class CategorySalesFor1997Dto : DtoBase
    {
        public string CategoryName { get; set; }
        public decimal? CategorySales { get; set; }
    }
}
