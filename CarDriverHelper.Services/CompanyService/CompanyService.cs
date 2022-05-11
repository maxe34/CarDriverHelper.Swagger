using CarDriverHelper.Repositories.CustomRepositories.CompanyRepository;
using CarDriverHelper.Repositories.Entities;
using CarDriverHelper.Services.CompanyService.Models;
using Mapster;

namespace CarDriverHelper.Services.CompanyService;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public void AddCompany(CompanyModel companyModel)
    {
        var myCompany = companyModel.Adapt<Company>();

        _companyRepository.Add(myCompany);
    }

    public IQueryable<Company> GetAllCompanies()
    {
        return _companyRepository.GetAll();
    }

    public Company UpdateCompanyById(Guid companyId, CompanyModel companyModel)
    {
        var myCompany = companyModel.Adapt<Company>();

        return _companyRepository.UpdateCompanyById(companyId, myCompany);
    }

    public void DeleteCompanyById(Guid companyId)
    {
        var company = _companyRepository.Get(companyId);
        if (company != null)
            _companyRepository.Remove(company);
    }
}