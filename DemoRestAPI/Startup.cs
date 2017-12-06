using BLL;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Swashbuckle.AspNetCore.Swagger;

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

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Old Irish RestAPI", Version = "v1" });
            });

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
                //var itemType = facade.ItemTypeService.Create(
                //   new ItemTypeBO()
                //   {
                //       Name = "Cyder"
                //   }
                //   );
                //var somersby = facade.ItemService.Create(
                //    new ItemBO()
                //    {
                //        Name = "Somersby",
                //        ItemTypeId = itemType.Id
                //    });

                //var order = facade.OrderService.Create(
                //    new OrderBO()
                //    {
                //        OrderDate = DateTime.Now,
                //        DeliveryDate = DateTime.Now.AddDays(30),
                //        OrderPrice = 10000000,
                //        Supplier = "SUPPLIER!",
                //        PubId = pub.Id
                        
                //    });







            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Old Irish RestAPI V1");
            });

            app.UseMvc();
        }
    
    }
}

