using CarDriverHelper.Repositories.CustomRepositories.CoffeeShopRepository;
using CarDriverHelper.Repositories.CustomRepositories.CompanyRepository;
using CarDriverHelper.Repositories.CustomRepositories.GasStationRepository;
using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CoffeeShopService.Models;
using CarDriverHelper.Services.CompanyService.Models;
using CarDriverHelper.Services.GasStationService.Models;
using Mapster;

namespace CarDriverHelper.Services.GasStationService;

public class GasStationService : IGasStationService
{
    private readonly IGasStationRepository _gasStationRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICoffeeShopRepository _coffeeShopRepository;

    public GasStationService(IGasStationRepository gasStationRepository, ICompanyRepository companyRepository,
        ICoffeeShopRepository coffeeShopRepository)
    {
        _gasStationRepository = gasStationRepository;
        _companyRepository = companyRepository;
        _coffeeShopRepository = coffeeShopRepository;
    }

    public IQueryable<GasStation> GetAllStations()
    {
        return _gasStationRepository.GetAll();
    }

    public GasStationCompanyCoffeeModel? GetStationWithCompanyCoffeeShopCarWashById(Guid stationId)
    {
        var newStation = _gasStationRepository.Get(stationId);

        if (newStation == null) return null;

        newStation.Company = _companyRepository.Get(newStation.CompanyId)!;
        newStation.CoffeeShop = _coffeeShopRepository.Get(newStation.CoffeeShopId);

        var newModel = newStation.Adapt<GasStationCompanyCoffeeModel>();
        newModel.Company = newStation.Company.Adapt<CompanyModel>();
        newModel.CoffeeShop = newStation.CoffeeShop!.Adapt<CoffeeShopModel>();
        if (newStation.CoffeeShop != null) newModel.CoffeeShop = newStation.CoffeeShop.Adapt<CoffeeShopModel>();

        return newModel;
    }

    public GasStation AddGasStation(GasStationModel gasStationModel)
    {
        var gasStation = gasStationModel.Adapt<GasStation>();

        _gasStationRepository.Add(gasStation);
        return gasStation;
    }

    public void DeleteGasStationById(Guid stationId)
    {
        var station = _gasStationRepository.Get(stationId);
        if (station != null)
            _gasStationRepository.Remove(station);
    }
}