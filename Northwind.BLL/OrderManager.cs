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
    public class OrderManager : GenericService<Order, OrderDto>, IOrderService
    {

        public readonly IOrderRepository _orderRepository;

        public OrderManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _orderRepository = serviceProvider.GetService<IOrderRepository>();
        }

        public IQueryable OrderReport(int orderID)
        {
            return _orderRepository.OrderReport(orderID);
        }
    }
}
