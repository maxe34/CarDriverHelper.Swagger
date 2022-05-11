using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.GasStationService.Models;

namespace CarDriverHelper.Services.GasStationService;

public interface IGasStationService
{
    public IQueryable<GasStation> GetAllStations();
    public GasStation AddGasStation(GasStationModel gasStationModel);
    public void DeleteGasStationById(Guid stationId);
    public GasStationCompanyCoffeeModel? GetStationWithCompanyCoffeeShopCarWashById(Guid stationId);
}