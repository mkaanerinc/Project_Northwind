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
    public class CategoryManager : GenericService<Category,CategoryDto>, ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryManager(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _categoryRepository = serviceProvider.GetService<ICategoryRepository>();
        }
    }
}
