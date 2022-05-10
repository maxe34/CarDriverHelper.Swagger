using Repositories.Entities;

namespace Repositories.CompanyRepository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public Company UpdateCompanyById(int companyId, CompanyViewModel companyViewModel)
    {
        var company = GetData().FirstOrDefault(c => c.Id == companyId);

        if (company != null)
        {
            company.Name = companyViewModel.Name;
            company.Rate = companyViewModel.Rate;
        }
        
        SaveChanges();
        return company!;
    }
}