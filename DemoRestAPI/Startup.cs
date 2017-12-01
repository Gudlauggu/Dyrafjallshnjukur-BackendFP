using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		//public Startup(IHostingEnvironment env)
		//{
		//	var builder = new ConfigurationBuilder()
		//		.SetBasePath(env.ContentRootPath)
		//		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		//		.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
		//		.AddEnvironmentVariables();
		//	Configuration = builder.Build();
		//}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
				builder.WithOrigins("http://localhost:4200")
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

            //services.AddSingleton(Configuration);
            
        
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();

                
                //var pub = facade.PubService.Create(
                //    new PubBO()
                //    {
                //        Name = "Esbjerg City",
                //        Address = "Bobparkerway 52"
                //    }
                //    );
                //facade.SupplierService.Create(
                //    new SupplierBO()
                //    {
                //        Name = "Vodka supplier",
                //        Address = "Beercity 8C",
                //        PhoneNumber = 66332288,
                //        Email = "email@email.com"
                //    }
                //    );
                //var order = facade.OrderService.Create(
                //    new OrderBO()
                //    {
                //        OrderDate = DateTime.Now,
                //        DeliveryDate = DateTime.Now.AddDays(30),
                //        OrderPrice = 10000000,
                //        PubId = pub.Id
                //    });
                //facade.ItemService.Create(
                //    new ItemBO()
                //    {
                //        Name = "Somersby",
                //        OrderId = order.Id
                //    });
                //facade.ItemTypeService.Create(
                //    new ItemTypeBO()
                //    {
                //        Name = "Cyder"
                //    }
                //    );




            }

            app.UseMvc();
        }
    
    }
}

