using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.Base;
using Northwind.Entity.DTOs;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebApi.Base;
using System;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiBaseController<ICustomerService,Customer,CustomerDto>
    {

        public CustomerController(ICustomerService customerService) : base(customerService)
        {
        }

        [HttpGet("FindCustomer")]
        public IResponse<CustomerDto> FindCustomer(string id)
        {
            try
            {
                var entity = _service.FindCustomer(id);

                return entity;
            }
            catch (Exception ex)
            {
                return new Response<CustomerDto>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}
