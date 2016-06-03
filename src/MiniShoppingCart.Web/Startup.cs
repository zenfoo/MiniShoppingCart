namespace MiniShoppingCart.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using MiniShoppingCart.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using MiniShoppingCart.Web.Mvc;

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure in memory 
            services
                .AddEntityFramework()
                .AddInMemoryDatabase();
            services
                .AddDbContext<DataContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase(options => options.IgnoreTransactions()));

            services.AddScoped<IUnitOfWork>(provider => provider.GetService<DataContext>());
            services.AddScoped<UnitOfWorkFilter>();

            services.AddMvc(options =>
            {
                options.Filters.AddService(typeof(UnitOfWorkFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IUnitOfWork context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
            //
            // Setup initial customer data for the sake of a trivial demo
            //
            context.Customers.Add(new Domain.Customer("Peter", "Doobes", "peter@doobes.com", "123 Test Street", "", "New York", "NY", "US"));
            context.Products.Add(new Domain.Product("Widget XYZ", 12.45M));
            context.Products.Add(new Domain.Product("Test Foo", 2.53M));
            context.Products.Add(new Domain.Product("Product 1", 5.05M));
            context.Products.Add(new Domain.Product("Gizmo 2000", 3.56M));
            context.SaveChanges();
        }
    }
}
