using CarDriverHelper.Repositories.CustomRepositories.CoffeeShopRepository;
using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CoffeeShopService.Models;
using Mapster;

namespace CarDriverHelper.Services.CoffeeShopService;

public class CoffeeShopService : ICoffeeShopService
{
    private readonly ICoffeeShopRepository _coffeeShopRepository;

    public CoffeeShopService(ICoffeeShopRepository coffeeShopRepository)
    {
        _coffeeShopRepository = coffeeShopRepository;
    }

    public void AddCoffeeShop(CoffeeShopModel coffeeShopModel)
    {
        var myCoffeeShop = coffeeShopModel.Adapt<CoffeeShop>();
        
        _coffeeShopRepository.Add(myCoffeeShop);
    }

    public IQueryable<CoffeeShop> GetAllCoffeeShops()
    {
        
        return _coffeeShopRepository.GetAll();
    }

    public CoffeeShop UpdateCoffeeShopById(Guid coffeeShopId, CoffeeShopModel coffeeShopModel)
    {
        var coffeeShop = coffeeShopModel.Adapt<CoffeeShop>();
        
        return _coffeeShopRepository.UpdateCoffeeShopById(coffeeShopId, coffeeShop);
    }

    public void DeleteCoffeeShopById(Guid coffeeShopId)
    {
        var coffeeShop = _coffeeShopRepository.Get(coffeeShopId);
        if (coffeeShop != null)
            _coffeeShopRepository.Remove(coffeeShop);
    }
}