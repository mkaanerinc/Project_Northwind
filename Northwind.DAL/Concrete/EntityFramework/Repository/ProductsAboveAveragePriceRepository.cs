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
    public class ProductsAboveAveragePriceRepository : GenericRepository<ProductsAboveAveragePrice>, IProductsAboveAveragePriceRepository
    {
        public ProductsAboveAveragePriceRepository(DbContext context) : base(context)
        { }

    }
}
