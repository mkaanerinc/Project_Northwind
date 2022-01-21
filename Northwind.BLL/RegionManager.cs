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
    public class RegionManager : GenericService<Region, RegionDto>, IRegionService
    {
        public readonly IRegionRepository _regionRepository;

        public RegionManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _regionRepository = serviceProvider.GetService<IRegionRepository>();
        }
    }
}
