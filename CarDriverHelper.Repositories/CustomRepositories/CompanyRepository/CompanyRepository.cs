using CarDriverHelper.Repositories.Entities;

namespace CarDriverHelper.Repositories.CustomRepositories.CompanyRepository;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public Company UpdateCompanyById(Guid companyId, Company company)
    {
        var myCompany = Get(companyId);

        if (myCompany != null)
        {
            myCompany.Name = company.Name;
            myCompany.Rate = company.Rate;
        }

        SaveChanges();
        return myCompany!;
    }
}