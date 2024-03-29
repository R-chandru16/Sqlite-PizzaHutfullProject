using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaHut.Models;
using PizzaHut.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut
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
            services.AddControllersWithViews();
            //services.AddDbContext<PizzaHutContext>(options =>
            //{
            //    options.UseSqlServer(Configuration["ConnectionStrings:conCompany"]);
            //});
           // services.AddSqlite<PizzaHutContext>("Data Source=Database.db");
            services.AddDbContext<PizzaHutContext>(options =>
               options.UseSqlite(Configuration.GetConnectionString("MyConStr")));
            services.AddScoped<IRepo<Users>, UsersRepo>();
            services.AddScoped<IRepo<Pizza>, PizzaRepo>();
            services.AddScoped<IRepo<Toppings>, ToppingsRepo>();
            services.AddScoped<IRepo<Orders>, OrdersRepo>();
            services.AddScoped<IRepo<OrderDetails>, OrderDetailsRepo>();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=Index}/{id?}");
            });
        }
    }
}