using Mapster;
using Repositories.CompanyRepository;
using Repositories.Entities;
using Repositories.GasStationRepository;
using Services.GasStationService.Models;

namespace Services.GasStationService;

public class GasStationService : IGasStationService
{
    private readonly IGasStationRepository _gasStationRepository;
    private readonly ICompanyRepository _companyRepository;

    public GasStationService(IGasStationRepository gasStationRepository, ICompanyRepository companyRepository)
    {
        _gasStationRepository = gasStationRepository;
        _companyRepository = companyRepository;
    }

    public IQueryable<GasStation> GetAllStations()
    {
        return _gasStationRepository.GetAll();
    }

    public GasStationWithCompanyCoffeeShopCarWashModel GetStationWithCompanyCoffeeShopCarWashById(int stationId)
    {
        
        var newStations = _gasStationRepository.GetData()
            .Where(s => s.Id == stationId)
            .Select(station => new GasStationWithCompanyCoffeeShopCarWashModel()
            {
                Name = station.Name,
                Rate = station.Rate,
                GasolinePrice = station.GasolinePrice,
                DieselPrice = station.DieselPrice,
                GplPrice = station.GplPrice,
                Market = station.Market,
                Coffee = station.Coffee,
                CarWash = station.CarWash,
                CompanyName = station.Company.Name,
                CoffeeShopName = station.CoffeeShop!.Name,
                CarWashDataName = station.CarWashData!.Name
            }).FirstOrDefault();

        return newStations;
    }

    public GasStation AddGasStation(GasStationModel gasStationModel)
    {
        var gasStation = gasStationModel.Adapt<GasStation>();

        _gasStationRepository.Add(gasStation);
        return gasStation;
    }

    public void DeleteGasStationById(int stationId)
    {
        var station = _gasStationRepository.Get(stationId);
        if (station != null)
            _gasStationRepository.Remove(station);
    }
}