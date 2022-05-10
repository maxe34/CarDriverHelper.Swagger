using Mapster;

namespace Repositories.Entities;

public class GasStation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Rate { get; set; }
    public double GasolinePrice { get; set; }
    public double DieselPrice { get; set; }
    public double? GplPrice { get; set; }
    public double? MetanPrice { get; set; }
    public bool Market { get; set; }
    public bool Coffee { get; set; }
    public bool CarWash { get; set; }

    public int CompanyId { get; set; }
    public int? CoffeeShopId { get; set; }
    public int? CarWashId { get; set; }

    public Company Company { get; set; }
    [AdaptIgnore] public CoffeeShop? CoffeeShop { get; set; }
    public CarWash? CarWashData { get; set; }
}