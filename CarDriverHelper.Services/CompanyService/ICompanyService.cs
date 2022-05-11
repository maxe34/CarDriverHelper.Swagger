using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CompanyService.Models;

namespace CarDriverHelper.Services.CompanyService;

public interface ICompanyService
{
    public void AddCompany(CompanyModel companyModel);
    public IQueryable<Company> GetAllCompanies();
    public Company UpdateCompanyById(Guid companyId, CompanyModel companyModel);
    public void DeleteCompanyById(Guid companyId);
}