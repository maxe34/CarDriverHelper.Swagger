using Microsoft.AspNetCore.Mvc;
using Services.CoffeeShopService;
using Services.CoffeeShopService.Models;

namespace CarDriveHelper.Swagger.Controllers;
[Route("coffee_shop")]
public class CoffeeShopController : Controller
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

    [HttpPost]
    public IActionResult AddCoffeeShop([FromBody] CoffeeShopModel coffeeShopModel)
    {
        _coffeeShopService.AddCoffeeShop(coffeeShopModel);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateCoffeeShop(int id, [FromBody] CoffeeShopModel coffeeShopModel )
    {
        var updatedCoffeeShop = _coffeeShopService.UpdateCoffeeShopById(id, coffeeShopModel);
        return Ok(updatedCoffeeShop);
    }

    [HttpDelete]
    public IActionResult DeleteCoffeeShopById(int id)
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