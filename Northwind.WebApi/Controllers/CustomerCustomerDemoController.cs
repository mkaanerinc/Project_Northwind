using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entity.DTOs;
using Northwind.Entity.Models;
using Northwind.Interface;
using Northwind.WebApi.Base;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCustomerDemoController : ApiBaseController<ICustomerCustomerDemoService, CustomerCustomerDemo, CustomerCustomerDemoDto>
    {
        public CustomerCustomerDemoController(ICustomerCustomerDemoService customerCustomerDemoService) : base(customerCustomerDemoService)
        {

        }
    }
}
