using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories.CustomRepositories.CoffeeShopRepository;

public class CoffeeShopRepository : Repository<CoffeeShop>, ICoffeeShopRepository
{
    public CoffeeShopRepository(AppDbContext context) : base(context)
    {
    }

    public CoffeeShop UpdateCoffeeShopById(Guid coffeeId, CoffeeShop coffeeShop)
    {
        var coffee = Get(coffeeId);

        if (coffee != null)
        {
            coffee.Name = coffeeShop.Name;
            coffee.Rate = coffeeShop.Rate;
        }

        SaveChanges();
        return coffee!;
    }
}