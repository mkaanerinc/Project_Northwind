using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Northwind.BLL;
using Northwind.DAL.Abstract;
using Northwind.DAL.Concrete.EntityFramework.Context;
using Northwind.DAL.Concrete.EntityFramework.Repository;
using Northwind.DAL.Concrete.EntityFramework.UnitOfWork;
using Northwind.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Northwind.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region JwtTokenService
            //JwtSecurityTokenHandler
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.SaveToken = true;
                cfg.RequireHttpsMetadata = false;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],

                    RoleClaimType = "Roles",
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateLifetime = true,


                    ValidateAudience = true,
                    ValidAudience = Configuration["Tokens:Issuer"],

                    RequireSignedTokens = true,
                    RequireExpirationTime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))


                };
            });
            #endregion

            #region ApplicationContext
            // Db baðlantý için yöntem 1
            //services.AddDbContext<NORTHWNDContext>();
            //services.AddScoped<DbContext, NORTHWNDContext>();

            services.AddScoped<DbContext, NORTHWNDContext>();
            services.AddDbContext<NORTHWNDContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"), sqlOpt =>
                 {
                     sqlOpt.MigrationsAssembly("Northwind.DAL");
                 });
            });
            #endregion

            #region Business IoC
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICustomerCustomerDemoService, CustomerCustomerDemoManager>();
            services.AddScoped<ICustomerDemographicService, CustomerDemographicManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IEmployeeTerritoryService, EmployeeTerritoryManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IRegionService, RegionManager>();
            services.AddScoped<IShipperService, ShipperManager>();
            services.AddScoped<ISupplierService, SupplierManager>();
            services.AddScoped<ITerritoryService, TerritoryManager>();
            services.AddScoped<IUserService, UserManager>();
            #endregion

            #region Data Access IoC
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerCustomerDemoRepository, CustomerCustomerDemoRepository>();
            services.AddScoped<ICustomerDemographicRepository, CustomerDemographicRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeTerritoryRepository, EmployeeTerritoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITerritoryRepository, TerritoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region UnitOfWorks
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Northwind.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
