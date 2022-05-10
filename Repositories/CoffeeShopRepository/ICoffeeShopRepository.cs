using Repositories.Entities;

namespace Repositories.CoffeeShopRepository;

public interface ICoffeeShopRepository : IRepository<CoffeeShop>
{
    public CoffeeShop UpdateCoffeeShopById(int coffeeId,  CoffeeShop coffeeShop);
}