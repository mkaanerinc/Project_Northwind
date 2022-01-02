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

        IResponse<List<Dto>> GetAll();

        Task<List<Dto>> GetAllAsync();

        IResponse<List<Dto>> GetAll(Expression<Func<Entity,bool>> predicate);

        Task<List<Dto>> GetAllAsync(Expression<Func<Entity, bool>> predicate);

        IResponse<Dto> Find(int itemID);

        Task<Dto> FindAsync(int itemID);

        IQueryable<Dto> GetIQueryable();

        IResponse<Dto> Add(Dto item,bool saveChanges = true);

        Task<Dto> AddAsync(Dto item);

        Dto Update(Dto item);

        Task<Dto> UpdateAsync(Dto item);

        void DeleteById(int itemID);

        Task DeleteByIdAsync(int itemID);

        void Delete(Dto item);

        Task DeleteAsync(Dto item);

        void Save();

    }
}
