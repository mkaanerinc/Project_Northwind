using Northwind.Entity.Models;
using Northwind.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface ICustomerService : IGenericService<Customer,CustomerDto>
    {
        IQueryable CustomerReport(int customerID);
    }
}
