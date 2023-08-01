using Universeauto.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
//builder.Services.AddMvc();
builder.Services.AddTransient<IRepository, DataRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IOrderLinesRepository, OrderLinesRepository>();
//builder.Services.AddScoped<IRepository, DataRepository>(); Вот из-за этой строчки ничего Не работало!! ГЫ)

//var connectionString = Configuration.GetConnectionString("DefaultConnection");
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(connectionString));


//builder.Services.AddSingleton<IRepository, DataRepository>();



var app = builder.Build();

//app.MapGet("/", () => "Hello World!");        ?????

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();