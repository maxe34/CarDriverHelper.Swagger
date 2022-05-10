using Microsoft.AspNetCore.Mvc;
using Services.GasStationService;
using Services.GasStationService.Models;

namespace CarDriveHelper.Swagger.Controllers;

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
    public IActionResult AddGasStation([FromBody] GasStationModel gasStationModel)
    {
        _gasStationService.AddGasStation(gasStationModel);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGasStationById(int id)
    {
        _gasStationService.DeleteGasStationById(id);
        return Ok();
    }
}