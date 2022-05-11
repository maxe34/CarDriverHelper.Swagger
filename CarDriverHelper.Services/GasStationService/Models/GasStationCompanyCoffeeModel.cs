using CarDriverHelper.Services.CoffeeShopService.Models;
using CarDriverHelper.Services.CompanyService.Models;

namespace CarDriverHelper.Services.GasStationService.Models;

public class GasStationCompanyCoffeeModel
{
    public int Rate { get; set; }
    public string Name { get; set; }
    public double GasolinePrice { get; set; }
    public double DieselPrice { get; set; }
    public double? GplPrice { get; set; }
    public double? MetanPrice { get; set; }
    public bool Market { get; set; }
    public bool Coffee { get; set; }
    public bool CarWash { get; set; }

    public CompanyModel Company { get; set; }
    public CoffeeShopModel? CoffeeShop { get; set; }
}