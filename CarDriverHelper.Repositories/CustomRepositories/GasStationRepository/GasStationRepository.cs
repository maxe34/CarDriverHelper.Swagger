using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories.CustomRepositories.GasStationRepository;

public class GasStationRepository : Repository<GasStation>, IGasStationRepository
{
    public GasStationRepository(AppDbContext context) : base(context)
    {
    }
}