using AutoMapper;
using MoneyboDemo.Dto.Mapper;
using MoneyboDemo.Model.Helpers;
using MoneyboDemo.Services.RemoteServices.MoneyBoApi.Concrete;
using MoneyboDemo.Services.RemoteServices.MoneyBoApi.Interfaces;


namespace MoneyboDemo.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddSingleton<IRequestHelper,RequestHelper>();
            builder.Services.AddSingleton<IUserService,UserService>();
            builder.Services.AddSingleton<IToDoService,ToDoService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Users}/{id?}");

            app.Run();
        }
    }
}