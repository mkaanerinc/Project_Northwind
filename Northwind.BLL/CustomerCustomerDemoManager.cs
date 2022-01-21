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
    public class CustomerCustomerDemoManager : GenericService<CustomerCustomerDemo, CustomerCustomerDemoDto>, ICustomerCustomerDemoService
    {
        public readonly ICustomerCustomerDemoRepository _customerCustomerDemoRepository;

        public CustomerCustomerDemoManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _customerCustomerDemoRepository = serviceProvider.GetService<ICustomerCustomerDemoRepository>();
        }
    }
}
