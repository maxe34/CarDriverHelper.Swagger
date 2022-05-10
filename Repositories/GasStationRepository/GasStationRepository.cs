using Repositories.Entities;

namespace Repositories.GasStationRepository;

public class GasStationRepository : Repository<GasStation>, IGasStationRepository
{
    public GasStationRepository(AppDbContext context) : base(context)
    {
    }
}