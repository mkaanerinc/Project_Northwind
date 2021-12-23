using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        // TODO: Repository'ler eklenecek...

        bool BeginTransaction();

        bool RollBackTransaction();

        int SaveChanges();
    }
}
