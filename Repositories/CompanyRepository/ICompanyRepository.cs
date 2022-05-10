using Repositories.Entities;

namespace Repositories.CompanyRepository;

public interface ICompanyRepository : IRepository<Company>
{
    public Company UpdateCompanyById(int companyId, CompanyViewModel companyViewModel);
}