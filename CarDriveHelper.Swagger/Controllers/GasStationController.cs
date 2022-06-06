using CarDriverHelper.Services.GasStationService;
using CarDriverHelper.Services.GasStationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDriveHelper.Swagger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GasStationController : ControllerBase
{
    private readonly IGasStationService _gasStationService;

    public GasStationController(IGasStationService gasStationService)
    {
        _gasStationService = gasStationService;
    }

    [HttpGet]
    public IActionResult GetAllGasStations()
    {
        var allStations = _gasStationService.GetAllStations();
        return Ok(allStations);
    }
    
    [HttpGet()]
    [Route("list")]
    public IActionResult GetList()
    {
        var list = _gasStationService.GetList();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult GetStationById(Guid id)
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
    public IActionResult DeleteGasStationById(Guid id)
    {
        _gasStationService.DeleteGasStationById(id);
        return Ok();
    }
}