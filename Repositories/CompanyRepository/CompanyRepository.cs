using Repositories.Entities;

namespace Repositories.CompanyRepository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public Company UpdateCompanyById(int companyId, Company company)
    {
        var myCompany = GetData().FirstOrDefault(c => c.Id == companyId);

        if (myCompany != null)
        {
            myCompany.Name = company.Name;
            myCompany.Rate = company.Rate;
        }
        
        SaveChanges();
        return myCompany!;
    }
}