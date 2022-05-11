using CarDriverHelper.Services.CompanyService;
using CarDriverHelper.Services.CompanyService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDriveHelper.Swagger.Controllers;

[Route("Company")]
public class CompanyController : Controller
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public IActionResult GetAllCompanies()
    {
        var allCompanies = _companyService.GetAllCompanies();
        return Ok(allCompanies);
    }

    [HttpPost]
    public IActionResult AddCompany([FromBody] CompanyModel companyModel)
    {
        try
        {
            _companyService.AddCompany(companyModel);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest($"{e.Message} oops, smth get wrong");
        }
    }

    [HttpPut]
    public IActionResult UpdateCompany(Guid id, [FromBody] CompanyModel companyModel)
    {
        var updatedCompany = _companyService.UpdateCompanyById(id, companyModel);
        return Ok(updatedCompany);
    }

    [HttpDelete]
    public IActionResult DeleteCompanyById(Guid id)
    {
        try
        {
            _companyService.DeleteCompanyById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} sorry");
        }
    }
}