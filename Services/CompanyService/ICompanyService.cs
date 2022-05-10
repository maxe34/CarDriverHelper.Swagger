using Repositories.Entities;
using Services.CompanyService.Models;

namespace Services.CompanyService;

public interface ICompanyService
{
    public void AddCompany(CompanyModel companyModel);
    public IQueryable<Company> GetAllCompanies();
    public Company UpdateCompanyById(int companyId, CompanyModel companyModel);
    public void DeleteCompanyById(int companyId);
}