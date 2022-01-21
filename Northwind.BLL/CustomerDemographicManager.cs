using Microsoft.Extensions.DependencyInjection;
using Northwind.BLL.Base;
using Northwind.DAL.Abstract;
using Northwind.Entity.DTOs;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL
{
    public class CustomerDemographicManager : GenericService<CustomerDemographic, CustomerDemographicDto>, ICustomerDemographicService
    {
        public readonly ICustomerDemographicRepository _customerDemographicRepository;

        public CustomerDemographicManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _customerDemographicRepository = serviceProvider.GetService<ICustomerDemographicRepository>();
        }
    }
}
