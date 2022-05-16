using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CoffeeShopService.Models;

namespace CarDriverHelper.Services.CoffeeShopService;

public interface ICoffeeShopService
{
    public void AddCoffeeShop(CoffeeShopModel coffeeShopModel);
    public IQueryable<CoffeeShop> GetAllCoffeeShops();
    public CoffeeShopModel? GetCoffeeShopById(Guid id);
    public CoffeeShop UpdateCoffeeShopById(Guid coffeeShopId, CoffeeShopModel coffeeShopModel);
    public void DeleteCoffeeShopById(Guid coffeeShopId);
}