﻿using Microsoft.Extensions.DependencyInjection;
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
    public class OrderDetailManager : GenericService<OrderDetail, OrderDetailDto>, IOrderDetailService
    {
        public readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _orderDetailRepository = serviceProvider.GetService<IOrderDetailRepository>();
        }
    }
}
