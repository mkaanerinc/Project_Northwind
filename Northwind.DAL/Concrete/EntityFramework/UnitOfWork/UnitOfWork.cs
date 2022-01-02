using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Northwind.DAL.Abstract;
using Northwind.DAL.Concrete.EntityFramework.Repository;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variables

        private readonly DbContext _context;
        private IDbContextTransaction _dbContextTransaction;
        bool _disposed;

        #endregion

        #region Constructor

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        #endregion

        public bool BeginTransaction()
        {
            try
            {
                _dbContextTransaction = _context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<Entity> GetRepository<Entity>() where Entity : EntityBase
        {
            return new GenericRepository<Entity>(_context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                _dbContextTransaction.Rollback();
                _dbContextTransaction = null;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = _dbContextTransaction != null ? _dbContextTransaction : _context.Database.BeginTransaction();

            using (_transaction)
            {
                try
                {
                    if(_context == null)
                    {
                        throw new ArgumentException("Context is null.");
                    }

                    int result = _context.SaveChanges();

                    _transaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {

                    _dbContextTransaction.Rollback();

                    throw new Exception("Error on save changes", ex);
                }
            }
        }

    }
}
