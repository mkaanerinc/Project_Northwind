using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Entity> GetRepository<Entity>() where Entity : EntityBase;

        bool BeginTransaction();

        bool RollBackTransaction();

        int SaveChanges();
    }
}
