using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IGenericService<Entity,Dto> where Entity : IEntityBase where Dto : IDtoBase
    {

        List<Dto> GetAll();

        Task<List<Dto>> GetAllAsync();

        List<Dto> GetAll(Expression<Func<Entity,bool>> predicate);

        Task<List<Dto>> GetAllAsync(Expression<Func<Entity, bool>> predicate);

        Dto Find(int itemID);

        Task<Dto> FindAsync(int itemID);

        IQueryable<Dto> GetIQueryable();

        Dto Add(Dto item);

        Task<Dto> AddAsync(Dto item);

        Dto Update(Dto item);

        Task<Dto> UpdateAsync(Dto item);

        void DeleteById(int itemID);

        Task DeleteByIdAsync(int itemID);

        void Delete(Dto item);

        Task DeleteAsync(Dto item);

    }
}
