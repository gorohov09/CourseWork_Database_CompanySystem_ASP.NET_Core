using Company.Clients.Employees;
using Company.Clients.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllersWithViews();
services.AddAutoMapper(Assembly.GetEntryAssembly());

//Clients
services.AddHttpClient("Company.WebAPI", client => client.BaseAddress = new(configuration["WebAPI"]))
    .AddTypedClient<IEmployeesClient, EmployeesClient>()
    .AddTypedClient<IProjectsClient, ProjectsClient>();


var app = builder.Build();

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
