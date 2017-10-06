using AutoMapper;
using EntityFramework.Core.Generic;
using EntityFramework.Core.Generic.Pattern.Repository;
using JwDelivery.Data.SqlServer.Context;
using JwDelivery.Data.SqlServer.Extensions;
using JwDelivery.Data.SqlServer.Models;
using JwDelivery.Logistics.Core;
using JwDelivery.Logistics.Core.Dto;
using JwDelivery.Logistics.Repositories.Contract;
using JwDelivery.Logistics.Repositories.Implementation;
using JwDelivery.Logistics.Services.Contract;
using JwDelivery.Logistics.Services.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JwDelivery.Logistics.Web.Api
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
            services.AddMvc();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IDbContext, JwDeliveryContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton(Configuration);
            // Add our Config object so it can be injected
            services.Configure<ConnectionStrings>(option => Configuration.GetSection("ConnectionStrings").Bind(option));
            //automapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDto, Employee>();
                cfg.CreateMap<Employee, EmployeeDto>();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddEntityFramework(Configuration.GetConnectionString("JwDeliveryContext"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
