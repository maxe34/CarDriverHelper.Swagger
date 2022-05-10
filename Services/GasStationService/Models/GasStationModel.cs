namespace Services.GasStationService.Models;

public class GasStationModel
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
    
    public int CompanyId { get; set; }
    public int? CoffeeShopId { get; set; }
    public int? CarWashId { get; set; }
}