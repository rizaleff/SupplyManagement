using API.DTOs.Companies;
using API.Models;

namespace API.Contracts;
public interface IVendorRepository : IGeneralRepository<Vendor>
{
    public bool UpdateVendorStatus(UpdateVendorStatusDto vendorDto);
}
