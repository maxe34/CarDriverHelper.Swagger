using CarDriverHelper.Services.CoffeeShopService;
using CarDriverHelper.Services.CoffeeShopService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDriveHelper.Swagger.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoffeeShopController : ControllerBase
{
    private readonly ICoffeeShopService _coffeeShopService;

    public CoffeeShopController(ICoffeeShopService coffeeShopService)
    {
        _coffeeShopService = coffeeShopService;
    }

    [HttpGet]
    public IActionResult GetAllCoffeeShops()
    {
        var allCoffeeShops = _coffeeShopService.GetAllCoffeeShops();
        return Ok(allCoffeeShops);
    }

    [HttpGet("{id}")]
    public IActionResult GetCoffeeShopById(Guid id)
    {
        var coffeeShop = _coffeeShopService.GetCoffeeShopById(id);
        return Ok(coffeeShop);
    }

    [HttpGet()]
    [Route("list")]
    public IActionResult GetList()
    {
        var list = _coffeeShopService.GetList();
        return Ok(list);
    }

    [HttpPost]
    public IActionResult AddCoffeeShop([FromBody] CoffeeShopModel coffeeShopModel)
    {
        _coffeeShopService.AddCoffeeShop(coffeeShopModel);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateCoffeeShop(Guid id, [FromBody] CoffeeShopModel coffeeShopModel)
    {
        var updatedCoffeeShop = _coffeeShopService.UpdateCoffeeShopById(id, coffeeShopModel);
        return Ok(updatedCoffeeShop);
    }

    [HttpDelete]
    public IActionResult DeleteCoffeeShopById(Guid id)
    {
        try
        {
            _coffeeShopService.DeleteCoffeeShopById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} sorry");
        }
    }
}