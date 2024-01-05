using API.Contracts;
using API.Data;
using API.DTOs.Companies;
using API.Models;
using API.Utilities.Handlers;

namespace API.Repositories;
public class CompanyRepository : GeneralRepository<Company>, ICompanyRepository{

    public CompanyRepository(SupplyManagementDbContext context) : base(context) { }

    public bool UpdateCompanyStatus(UpdateCompanyStatusDto companyDto)
    {
        try
        {
            var companyToUpdate = _context.Companies.FirstOrDefault(co => co.Guid == companyDto.Guid);
            companyToUpdate.ApprovalStatus = companyDto.ApprovalStatus;
            companyToUpdate.ModifiedDate = DateTime.Now;

            // Simpan perubahan ke database
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {

            throw new ExceptionHandler(ex.InnerException?.Message ?? ex.Message);
        }
    }
    public Company GetByAccountGuid(Guid guid)
    {
        var entity = _context.Set<Company>().FirstOrDefault(c => c.AccountGuid == guid);
        _context.ChangeTracker.Clear();
        return entity;
    }

}
