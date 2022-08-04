using Microsoft.EntityFrameworkCore;
using Sample.Models;
using Sample.Repository;
using Sample.Services;
using Services.UOW;

var builder = WebApplication.CreateBuilder(args);

//Register services for DI
//TODO::
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("dbconn")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
