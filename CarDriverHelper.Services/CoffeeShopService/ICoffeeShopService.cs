using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CoffeeShopService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDriverHelper.Services.CoffeeShopService;

public interface ICoffeeShopService
{
    public void AddCoffeeShop(CoffeeShopModel coffeeShopModel);
    public IQueryable<CoffeeShopModel> GetAllCoffeeShops(int? pageNumber);
    public CoffeeShopModel? GetCoffeeShopById(Guid id);
    public CoffeeShop UpdateCoffeeShopById(Guid coffeeShopId, CoffeeShopModel coffeeShopModel);
    public void DeleteCoffeeShopById(Guid coffeeShopId);
    public CoffeeFilterResponse<CoffeeShopModel> GetList();

}