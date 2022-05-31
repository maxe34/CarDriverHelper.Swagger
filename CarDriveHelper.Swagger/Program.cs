using CarDriverHelper.Repositories;
using CarDriverHelper.Repositories.CustomRepositories.CoffeeShopRepository;
using CarDriverHelper.Repositories.CustomRepositories.CompanyRepository;
using CarDriverHelper.Repositories.CustomRepositories.GasStationRepository;
using CarDriverHelper.Services.CoffeeShopService;
using CarDriverHelper.Services.CompanyService;
using CarDriverHelper.Services.GasStationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
var configuration = builder.Configuration;


services.AddControllers();
services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connectionString); });
services.AddScoped<IGasStationRepository, GasStationRepository>();
services.AddScoped<ICompanyRepository, CompanyRepository>();
services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();
services.AddEndpointsApiExplorer();
services.AddTransient<IGasStationService, GasStationService>();
services.AddTransient<ICompanyService, CompanyService>();
services.AddTransient<ICoffeeShopService, CoffeeShopService>();
services.AddSwaggerGen();

services.AddCors(options =>
{
    options.AddPolicy("AllowSetOrigins",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});
services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarDriverHelper");
        c.RoutePrefix = string.Empty;
    });
}

//app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors("AllowSetOrigins");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});
app.Run();