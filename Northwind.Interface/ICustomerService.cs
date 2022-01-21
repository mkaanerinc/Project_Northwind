using Northwind.Entity.Models;
using Northwind.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entity.IBase;

namespace Northwind.Interface
{
    public interface ICustomerService : IGenericService<Customer,CustomerDto>
    {
        IQueryable CustomerReport(int customerID);

        IResponse<CustomerDto> FindCustomer(string customerId);

    }
}
