using Company.Clients.Account;
using Company.Clients.Employees;
using Company.Clients.Interfaces;
using Company.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<CompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

services.AddControllersWithViews();
services.AddAutoMapper(Assembly.GetEntryAssembly());

//Clients
services.AddHttpClient("Company.WebAPI", client => client.BaseAddress = new(configuration["WebAPI"]))
    .AddTypedClient<IEmployeesClient, EmployeesClient>()
    .AddTypedClient<IProjectsClient, ProjectsClient>()
    .AddTypedClient<IAccountClient, AccountClient>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
