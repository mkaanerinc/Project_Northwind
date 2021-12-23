using Northwind.Entity.DTOs;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IOrderService : IGenericService<Order,OrderDto>
    {
        IQueryable OrderReport(int orderID);
    }
}
