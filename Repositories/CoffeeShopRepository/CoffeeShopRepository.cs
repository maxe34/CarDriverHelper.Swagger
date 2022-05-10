using Repositories.Entities;

namespace Repositories.CoffeeShopRepository;

public class CoffeeShopRepository : Repository<CoffeeShop>, ICoffeeShopRepository
{
    public CoffeeShopRepository(AppDbContext context) : base(context)
    {
    }

    public CoffeeShop UpdateCoffeeShopById(int coffeeId, CoffeeShop coffeeShop)
    {
        var coffee = GetData().FirstOrDefault(c => c.Id == coffeeId);

        if (coffee != null)
        {
            coffee.Name = coffeeShop.Name;
            coffee.Rate = coffeeShop.Rate;
        }
        
        SaveChanges();
        return coffee!;
    }
}