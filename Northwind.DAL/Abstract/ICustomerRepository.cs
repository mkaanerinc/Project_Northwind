﻿using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IQueryable CustomerReport(int customerID);

        Customer FindCustomer(string customerId);
    }
}
