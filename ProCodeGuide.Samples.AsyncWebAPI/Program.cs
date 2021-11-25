using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.AsyncWebAPI.DBContext;
using ProCodeGuide.Samples.AsyncWebAPI.Interfaces;
using ProCodeGuide.Samples.AsyncWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection"),
        ef => ef.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
