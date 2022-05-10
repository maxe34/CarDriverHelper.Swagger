using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connectionString); });
builder.Services.AddScoped<IGasStationRepository, GasStationRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICoffeeShopRepository, CoffeeShopRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IGasStationService, GasStationService>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ICoffeeShopService, CoffeeShopService>();
builder.Services.AddSwaggerGen();
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// app.MapGet("/", () => "Hello World!");

app.Run();