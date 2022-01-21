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


        IResponse<List<Dto>> GetAll(Expression<Func<Entity,bool>> predicate);

        IResponse<Dto> Find(int itemId);

        IQueryable<Dto> GetIQueryable();

        IResponse<Dto> Add(Dto item,bool saveChanges = true);

        Task<Dto> AddAsync(Dto item);

        IResponse<Dto> Update(Dto item);

        Task<Dto> UpdateAsync(Dto item);

        IResponse<bool> DeleteById(int itemId, bool saveChanges = true);

        Task<bool> DeleteByIdAsync(int itemId, bool saveChanges = true);

        IResponse<bool> Delete(Dto item);

        Task<bool> DeleteAsync(Dto item);

        void Save();

    }
}
