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
    public class AlphabeticalListOfProductRepository : GenericRepository<AlphabeticalListOfProduct>, IAlphabeticalListOfProductRepository
    {
        public AlphabeticalListOfProductRepository(DbContext context) : base(context)
        { }

    }
}
