using API.Contracts;
using API.Data;
using API.DTOs.Companies;
using API.Models;
using API.Utilities.Handlers;

namespace API.Repositories;
public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository{

    public VendorRepository(SupplyManagementDbContext context) : base(context) { }
    public bool UpdateVendorStatus(UpdateVendorStatusDto vendorDto)
    {
        try
        {
            var vendorToUpdate = _context.Companies.FirstOrDefault(co => co.Guid == vendorDto.Guid);
            vendorToUpdate.ApprovalStatus = vendorDto.ApprovalStatus;
            vendorToUpdate.ModifiedDate = DateTime.Now;

            // Simpan perubahan ke database
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {

            throw new ExceptionHandler(ex.InnerException?.Message ?? ex.Message);
        }
    }
}
