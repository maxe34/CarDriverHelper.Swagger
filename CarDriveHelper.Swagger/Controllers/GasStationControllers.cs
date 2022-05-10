using Microsoft.AspNetCore.Mvc;

namespace CarDriverHelper.ClassLibrary.Controllers;

[Route("gas_station")]
public class GasStationControllers : Controller
{
    private readonly IGasStationService _gasStationService;

    public GasStationControllers(IGasStationService gasStationService)
    {
        _gasStationService = gasStationService;
    }

    [HttpGet]
    public IActionResult GetAllGasStations()
    {
        var allStations = _gasStationService.GetAllStations();
        return Ok(allStations);
    }

    [HttpGet("{id}")]
    public IActionResult GetStationById(int id)
    {
        var station = _gasStationService.GetStationWithCompanyCoffeeShopCarWashById(id);
        return Ok(station);
    }

    [HttpPost]
    public IActionResult AddGasStation([FromBody] GasStationViewModel gasStationViewModel)
    {
        _gasStationService.AddGasStation(gasStationViewModel);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGasStationById(int id)
    {
        _gasStationService.DeleteGasStationById(id);
        return Ok();
    }
}