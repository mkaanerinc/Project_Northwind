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
    public class ProductManager : GenericService<Product, ProductDto>, IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _productRepository = serviceProvider.GetService<IProductRepository>();
        }
    }
}
