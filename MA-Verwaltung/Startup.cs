using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MA_Verwaltung.Models.Db_Context;
using MA_Verwaltung.Models.Repositories;
using MA_Verwaltung.Models.Seed_Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MA_Verwaltung
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                                       Configuration["MAVerwaltung:ConnectionString"]
                                   )
               );

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployee_RollRepository, Employee_RollRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseNodeModules();


            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                        "StandardRoute",
                        "{controller}/{action}/{id?}",
                        new { controller = "Home", action = "Index" }
                    );

            });

            SeedData.EnsurePopulated(app);
        }
    }
}
