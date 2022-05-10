using Repositories.Entities;
using Services.CoffeeShopService.Models;

namespace Services.CoffeeShopService;

public interface ICoffeeShopService
{
    public void AddCoffeeShop(CoffeeShopModel coffeeShopModel);
    public IQueryable<CoffeeShop> GetAllCoffeeShops();
    public CoffeeShop UpdateCoffeeShopById(int coffeeShopId, CoffeeShopModel coffeeShopModel);
    public void DeleteCoffeeShopById(int coffeeShopId);
}