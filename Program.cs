using CTPortaria.Data;
using CTPortaria.Middlewares;
using CTPortaria.Repositories.Implementations;
using CTPortaria.Repositories.Interfaces;
using CTPortaria.Services.Implementations;
using CTPortaria.Services.Interfaces;
using CTPortaria.Utils.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<DataContext>();
// Dependency Injections
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IGateLogRepository, GateLogRepository>();
builder.Services.AddScoped<IGateLogService, GateLogService>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IVisitorService, VisitorService>();
builder.Services.AddTransient<IPersonValidator, PersonValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
