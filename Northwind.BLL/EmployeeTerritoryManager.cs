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
    public class EmployeeTerritoryManager : GenericService<EmployeeTerritory, EmployeeTerritoryDto>, IEmployeeTerritoryService
    {
        public readonly IEmployeeTerritoryRepository _employeeTerritoryRepository;

        public EmployeeTerritoryManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _employeeTerritoryRepository = serviceProvider.GetService<IEmployeeTerritoryRepository>();
        }
    }
}
