using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories.CustomRepositories.CompanyRepository;

public interface ICompanyRepository : IRepository<Company>
{
    public Company UpdateCompanyById(Guid companyId, Company company);
}