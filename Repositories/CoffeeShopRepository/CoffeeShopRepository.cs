using Repositories.Entities;

namespace Repositories.CoffeeShopRepository;

public class CoffeeShopRepository : Repository<CoffeeShop>, ICoffeeShopRepository
{
    public CoffeeShopRepository(AppDbContext context) : base(context)
    {
    }

    public CoffeeShop UpdateCoffeeShopById(int coffeeId, CoffeeShopViewModel coffeeShopViewModel)
    {
        var coffee = GetData().FirstOrDefault(c => c.Id == coffeeId);

        if (coffee != null)
        {
            coffee.Name = coffeeShopViewModel.Name;
            coffee.Rate = coffeeShopViewModel.Rate;
        }
        
        SaveChanges();
        return coffee!;
    }
}