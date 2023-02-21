using FarmasiDemo.DataAccessLayer.Repository;
using FarmasiDemo.DataAccessLayer.Settings;
using FarmasiDemo.Models.Helper.CacheHelper;
using FarmasiDemo.Models.Mapper;
using FarmasiDemo.Services.Concrete;
using FarmasiDemo.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiDemo.WebApp
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
            services.AddScoped(typeof(IRepository<>), typeof(MongoDbRepositoryBase<>));
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICacheHelper, CacheHelper>();
            services.Configure<MongoSettings>(options => {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("Redis").Value;
                options.InstanceName = "RedisInstance";
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Products}/{id?}");
            });
        }
    }
}
