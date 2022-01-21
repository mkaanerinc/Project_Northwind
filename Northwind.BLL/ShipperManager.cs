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
    public class ShipperManager : GenericService<Shipper, ShipperDto>, IShipperService
    {
        public readonly IShipperRepository _shipperRepository;

        public ShipperManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _shipperRepository = serviceProvider.GetService<IShipperRepository>();
        }
    }
}
