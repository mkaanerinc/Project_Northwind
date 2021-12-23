using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Concrete.EntityFramework.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : EntityBase
    {
        #region Variables

        protected readonly DbContext _context;
        protected DbSet<Entity> _dbset;

        #endregion

        #region Constructor

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<Entity>();
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #endregion

        #region Methods

        public Entity Add(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _dbset.Add(entity);

            return entity;
        }

        public void Delete(Entity entity)
        {

            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Attach(entity);
            }

            _dbset.Remove(entity);
        }

        public void Delete(int entityID)
        {
            Delete(Find(entityID));
        }

        public Entity Find(int entityID)
        {
            return _dbset.Find(entityID);
        }

        public List<Entity> GetAll()
        {
            return _dbset.ToList();
        }

        public IQueryable<Entity> GetAll(Expression<Func<Entity, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public Entity Update(Entity entity)
        {
            _context.Entry(entity).State= EntityState.Modified;
            _dbset.Update(entity);

            return entity;
        }

        #endregion
    }
}
