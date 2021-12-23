using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface IGenericRepository<Entity> where Entity : IEntityBase
    {
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        List<Entity> GetAll();
        IQueryable<Entity> GetAll(Expression<Func<Entity,bool>> predicate);
        Entity Find(int entityID);
        void Delete(Entity entity);
        void Delete(int entityID);
    }
}
