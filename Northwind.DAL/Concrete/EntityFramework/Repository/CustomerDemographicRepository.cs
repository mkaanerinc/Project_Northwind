using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Concrete.EntityFramework.Repository
{
    public class CustomerDemographicRepository : GenericRepository<CustomerDemographic>, ICustomerDemographicRepository
    {
        public CustomerDemographicRepository(DbContext context) : base(context)
        { }
    }
}
