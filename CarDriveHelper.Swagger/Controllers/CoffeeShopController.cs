using Microsoft.AspNetCore.Mvc;

namespace CarDriverHelper.ClassLibrary.Controllers;
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
    public IActionResult AddCoffeeShop([FromBody] CoffeeShopViewModel coffeeShopViewModel)
    {
        _coffeeShopService.AddCoffeeShop(coffeeShopViewModel);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateCoffeeShop(int id, [FromBody] CoffeeShopViewModel coffeeShopViewModel)
    {
        var updatedCoffeeShop = _coffeeShopService.UpdateCoffeeShopById(id, coffeeShopViewModel);
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