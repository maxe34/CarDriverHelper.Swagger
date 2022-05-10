using Repositories.Entities;

namespace Repositories.GasStationRepository;

public class GasStationRepository : Repository<GasStation>, IGasStationRepository
{
    public GasStationRepository(AppDbContext context) : base(context)
    {
    }

    public GasStationWithCompanyCoffeeShopCarWashViewModel GetStationCompanyCoffeeWashById(int stationId)
    {
        var newStations = GetData()
            .Where(s => s.Id == stationId)
            .Select(station => new GasStationWithCompanyCoffeeShopCarWashViewModel()
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

    public GasStation AddGasStation(GasStationViewModel gasStationViewModel)
    {
        var newGasStation = new GasStation()
        {
            Name = gasStationViewModel.Name,
            Rate = gasStationViewModel.Rate,
            GasolinePrice = gasStationViewModel.GasolinePrice,
            DieselPrice = gasStationViewModel.DieselPrice,
            GplPrice = gasStationViewModel.GplPrice,
            Market = gasStationViewModel.Market,
            Coffee = gasStationViewModel.Coffee,
            CarWash = gasStationViewModel.CarWash,
            CompanyId = gasStationViewModel.CompanyId,
            CoffeeShopId = gasStationViewModel.CoffeeShopId,
            //CarWashId = gasStationViewModel.CarWashId
        };
        Add(newGasStation);

        return newGasStation;
    }
}