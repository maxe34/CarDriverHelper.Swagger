using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories.CustomRepositories.CoffeeShopRepository;

public interface ICoffeeShopRepository : IRepository<CoffeeShop>
{
    public CoffeeShop UpdateCoffeeShopById(Guid coffeeId, CoffeeShop coffeeShop);
}