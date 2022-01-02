using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DAL.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.IBase;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Base
{
    public class GenericService<Entity, Dto> : IGenericService<Entity, Dto> where Entity : EntityBase where Dto : DtoBase
    {

        #region Variables

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IGenericRepository<Entity> _repository;
        Mapper mapper;

        #endregion

        #region Constructor

        public GenericService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            _repository = _unitOfWork.GetRepository<Entity>();
            _serviceProvider = serviceProvider;
            mapper = new Mapper((IConfigurationProvider)serviceProvider);
        }

        #endregion

        #region Methods
        
        public IResponse<Dto> Add(Dto item, bool saveChanges = true)
        {
            try
            {
                var EntityResult = _repository.Add(mapper.Map<Dto,Entity>(item));

                if (saveChanges) 
                {
                    Save();
                }

                return new Response<Dto>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Data = mapper.Map<Entity, Dto>(EntityResult)
                };
            }
            catch (Exception ex)
            {

                return new Response<Dto>
                {
                    StatusCode = 500,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public Task<Dto> AddAsync(Dto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Dto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Dto item)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int itemID)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int itemID)
        {
            throw new NotImplementedException();
        }

        public IResponse<Dto> Find(int itemID)
        {
            try
            {
                return new Response<Dto>
                {
                    StatusCode = 200,
                    Message = "Success",
                    Data = mapper.Map<Entity,Dto>(_repository.Find(itemID))
                };

            }
            catch (Exception ex)
            {

                return new Response<Dto>
                {
                    StatusCode = 500,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };

            }
        }

        public Task<Dto> FindAsync(int itemID)
        {
            throw new NotImplementedException();
        }

        public IResponse<List<Dto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResponse<List<Dto>> GetAll(Expression<Func<Entity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Dto>> GetAllAsync(Expression<Func<Entity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Dto> GetIQueryable()
        {
            throw new NotImplementedException();
        }
        public Dto Update(Dto item)
        {
            throw new NotImplementedException();
        }

        public Task<Dto> UpdateAsync(Dto item)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _unitOfWork.SaveChanges();
        }

        #endregion
    }
}
