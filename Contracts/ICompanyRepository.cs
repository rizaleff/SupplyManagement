using API.DTOs.Companies;
using API.Models;

namespace API.Contracts;
public interface ICompanyRepository : IGeneralRepository<Company>
{
    public bool UpdateCompanyStatus(UpdateCompanyStatusDto companyDto);
}
