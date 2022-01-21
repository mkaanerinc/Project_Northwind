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
    public class EmployeeManager : GenericService<Employee, EmployeeDto>, IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _employeeRepository = serviceProvider.GetService<IEmployeeRepository>();
        }
    }
}
