using Repositories.Entities;

namespace Repositories.GasStationRepository;

public interface IGasStationRepository : IRepository<GasStation>
{
    public GasStationWithCompanyCoffeeShopCarWashViewModel GetStationCompanyCoffeeWashById(int stationId);
    public GasStation AddGasStation(GasStationViewModel gasStationViewModel);
}