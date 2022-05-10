using Repositories.Entities;
using Services.GasStationService.Models;

namespace Services.GasStationService;

public interface IGasStationService
{
    public IQueryable<GasStation> GetAllStations();
    public GasStation AddGasStation(GasStationModel gasStationModel);
    public void DeleteGasStationById(int stationId);
    public GasStationWithCompanyCoffeeShopCarWashModel GetStationWithCompanyCoffeeShopCarWashById(int stationId);
}