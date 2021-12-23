using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.DTOs
{
    public class EmployeeTerritoryDto : DtoBase
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
