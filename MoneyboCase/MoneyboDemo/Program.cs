using AutoMapper;
using MoneyboDemo.API.Middleware;
using MoneyboDemo.Dto.Mapper;
using MoneyboDemo.Model.Helpers;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Concrete;
using MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapping());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces.IUserService, MoneyboDemo.Services.RemoteServices.GoRestApi.Concrete.UserService>();
builder.Services.AddSingleton<IRequestHelper,RequestHelper>();
builder.Services.AddSingleton<MoneyboDemo.Services.RemoteServices.GoRestApi.Interfaces.IToDoService, MoneyboDemo.Services.RemoteServices.GoRestApi.Concrete.ToDoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
