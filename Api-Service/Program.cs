using Api_Service.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;  
using Microsoft.Extensions.DependencyInjection;
using Api_Service.Common;
using Api_Service.Mappings;
var builder = WebApplication.CreateBuilder(args);


// Thêm dịch vụ DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Thêm dịch vụ Global
GlobalHelper.RegisterServices(builder.Services);
GlobalHelper.AddMappingProfiles(builder.Services);

// Thêm dịch vụ AddAutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
