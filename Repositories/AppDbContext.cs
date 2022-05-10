
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<GasStation> GasStations { get; set; }
    public virtual DbSet<CarWash> CarWashes { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<CoffeeShop> CoffeeShops { get; set; }
}