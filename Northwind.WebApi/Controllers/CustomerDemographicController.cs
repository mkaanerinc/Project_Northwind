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
    public class CustomerDemographicController : ApiBaseController<ICustomerDemographicService, CustomerDemographic, CustomerDemographicDto>
    {
        public CustomerDemographicController(ICustomerDemographicService customerDemographicService) : base(customerDemographicService)
        {

        }
    }
}
