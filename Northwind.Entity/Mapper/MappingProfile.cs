using AutoMapper;
using Northwind.Entity.DTOs;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<AlphabeticalListOfProduct,AlphabeticalListOfProductDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<CategorySalesFor1997,CategorySalesFor1997Dto>().ReverseMap();
            CreateMap<CurrentProductList,CurrentProductListDto>().ReverseMap();
            CreateMap<CustomerAndSuppliersByCity,CustomerAndSuppliersByCityDto>().ReverseMap();
            CreateMap<CustomerCustomerDemo,CustomerCustomerDemoDto>().ReverseMap();
            CreateMap<CustomerDemographic,CustomerDemographicDto>().ReverseMap();
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<EmployeeTerritory,EmployeeTerritoryDto>().ReverseMap();
            CreateMap<Invoice,InvoiceDto>().ReverseMap();
            CreateMap<OrderDetail,OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetailsExtended,OrderDetailsExtendedDto>().ReverseMap();
            CreateMap<OrdersQry,OrdersQryDto>().ReverseMap();
            CreateMap<OrderSubtotal,OrderSubtotalDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<ProductsAboveAveragePrice,ProductsAboveAveragePriceDto>().ReverseMap();
            CreateMap<ProductSalesFor1997,ProductSalesFor1997Dto>().ReverseMap();
            CreateMap<ProductsByCategory,ProductsByCategoryDto>().ReverseMap();
            CreateMap<QuarterlyOrder,QuarterlyOrderDto>().ReverseMap();
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<SalesByCategory,SalesByCategoryDto>().ReverseMap();
            CreateMap<SalesTotalsByAmount,SalesTotalsByAmountDto>().ReverseMap();
            CreateMap<Shipper,ShipperDto>().ReverseMap();
            CreateMap<SummaryOfSalesByQuarter,SummaryOfSalesByQuarterDto>().ReverseMap();
            CreateMap<SummaryOfSalesByYear,SummaryOfSalesByYearDto>().ReverseMap();
            CreateMap<Supplier,SupplierDto>().ReverseMap();
            CreateMap<Territory,TerritoryDto>().ReverseMap();
        }
    }
}
