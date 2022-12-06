using Company.Application.Interfaces;
using Company.Application.Services;
using Company.DAL;
using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(Assembly.GetEntryAssembly());

services.AddDbContext<CompanyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Services
services.AddScoped<IEmployeesService, EmployeesService>();
services.AddScoped<IProjectsService, ProjectsService>();
services.AddScoped<IAccountService, AccountService>();
services.AddScoped<IHistoryActionService, HistoryActionService>();
services.AddTransient<ITimeService, TimeService>();
services.AddTransient<IDbInitializer, DbInitializer>();


//Repository
services.AddScoped<IEmployeesRepository, EmployeesRepository>();
services.AddScoped<IProjectRepository, ProjectRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();
services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IHistoryActionRepository, HistoryActionRepository>();

services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

//Initialize Data
await using (var scope = app.Services.CreateAsyncScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await db_initializer.InitializeAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllHeaders");

app.UseAuthorization();

app.MapControllers();

app.Run();
