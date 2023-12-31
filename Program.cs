using HRMS.Data;
using HRMSCore.Services.DataSourceService;
using HRMSCore.Services.FieldService;
using HRMSCore.Services.FormService;
using HRMSCore.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(
  opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IDataSourceService, DataSourceService>();
builder.Services.AddScoped<IFieldService, FieldService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
