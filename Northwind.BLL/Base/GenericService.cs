using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        #endregion

        #region Constructor

        public GenericService(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            _repository = _unitOfWork.GetRepository<Entity>();
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region Methods
        
        public IResponse<Dto> Add(Dto item, bool saveChanges = true)
        {
            try
            {
                var EntityResult = _repository.Add(ObjectMapper.Mapper.Map<Dto,Entity>(item));

                if (saveChanges) 
                {
                    Save();
                }

                return new Response<Dto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Entity, Dto>(EntityResult)
                };
            }
            catch (Exception ex)
            {

                return new Response<Dto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<bool> Delete(Dto item)
        {
            throw new NotImplementedException();
        }

        public IResponse<bool> DeleteById(int itemId, bool saveChanges = true)
        {
            try
            {
                _repository.Delete(itemId);
                
                if(saveChanges) Save();

                return new Response<bool>
                {
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {

                return new Response<bool>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = false
                };
            }
        }

        public IResponse<Dto> Find(int itemId)
        {
            try
            {
                var result = _repository.Find(itemId);

                return new Response<Dto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Entity,Dto>(result)
                };

            }
            catch (Exception ex)
            {

                return new Response<Dto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };

            }
        }

        public IResponse<List<Dto>> GetAll()
        {
            try
            {
                List<Entity> list = _repository.GetAll();
                var dtoList = ObjectMapper.Mapper.Map<List<Entity>, List<Dto>>(list);

                return new Response<List<Dto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = dtoList
                };

            }
            catch (Exception ex)
            {

                return new Response<List<Dto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<Dto>> GetAll(Expression<Func<Entity, bool>> predicate)
        {
            try
            {
                List<Entity> list = _repository.GetAll(predicate).ToList();
                var dtoList = ObjectMapper.Mapper.Map<List<Entity>, List<Dto>>(list);

                return new Response<List<Dto>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = dtoList
                };

            }
            catch (Exception ex)
            {

                return new Response<List<Dto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IQueryable<Dto> GetIQueryable()
        {
            throw new NotImplementedException();
        }

        public IResponse<Dto> Update(Dto item)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _unitOfWork.SaveChanges();
        }

        public Task<Dto> AddAsync(Dto item)
        {
            throw new NotImplementedException();
        }

        public Task<Dto> UpdateAsync(Dto item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int itemId, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Dto item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
