using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.DTOs;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class CustomerManager : GenericService<Customer, CustomerDto>, ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;

        public CustomerManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _customerRepository = serviceProvider.GetService<ICustomerRepository>();
        }

        public IQueryable CustomerReport(int customerID)
        {
            throw new NotImplementedException();
        }

        public IResponse<CustomerDto> FindCustomer(string customerId)
        {
            try
            {
                return new Response<CustomerDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = ObjectMapper.Mapper.Map<Customer, CustomerDto>(_customerRepository.FindCustomer(customerId))
                };
            }
            catch (Exception ex)
            {
                return new Response<CustomerDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
