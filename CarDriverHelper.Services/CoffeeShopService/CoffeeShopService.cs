using CarDriverHelper.Repositories.CustomRepositories.CoffeeShopRepository;
using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CoffeeShopService.Models;
using CarDriverHelper.Services.Helper.Paging;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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

    public IQueryable<CoffeeShopModel> GetAllCoffeeShops(int? pageNumber)
    {
        var allShops = _coffeeShopRepository.GetAll();
        var myShopsModel = allShops.Select(shop => shop.Adapt<CoffeeShopModel>());
        
        if (pageNumber != 0 && pageNumber is not null)
        {
            int pageSize = 5;
            myShopsModel = PaginatedList<CoffeeShopModel>.Create(myShopsModel, pageNumber ?? 1, pageSize)
                .AsQueryable();
        }

        return myShopsModel;
    }

    public CoffeeFilterResponse<CoffeeShopModel> GetList()
    {
        var myShops = _coffeeShopRepository.GetAll().ToList();

        var myShopsModel = myShops.Select(shop => shop.Adapt<CoffeeShopModel>()).ToList();

        var myResponse = new CoffeeFilterResponse<CoffeeShopModel>
        {
            Items = myShopsModel,
            TotalCount = myShopsModel.Count
        };
        return myResponse;
    }

    public CoffeeShopModel? GetCoffeeShopById(Guid id)
    {
        return _coffeeShopRepository.Get(id)!.Adapt<CoffeeShopModel>();
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