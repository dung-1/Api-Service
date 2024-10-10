using Api_Service.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Api_Service.Common;
using Api_Service.Mappings;
using Microsoft.Extensions.FileProviders;
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder
        .WithOrigins("http://192.168.1.20:4200")
                //.WithOrigins()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();

    });
});
builder.Services.AddLogging();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();

}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "wwwroot")), // Sử dụng app.Environment.ContentRootPath
    RequestPath = "/static"
});
app.UseCors("AllowAllOrigins");
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
