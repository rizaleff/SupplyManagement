using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Vendors;
public class CreateVendorDto
{
    public Guid Guid { get; set; }
    public string CompanyType { get; set; }
    public string CompanyField { get; set; }

    public static implicit operator Vendor(CreateVendorDto vendorDto)
    {
        return new Vendor
        {
            Guid = vendorDto.Guid,
            CompanyType = vendorDto.CompanyType,
            CompanyField = vendorDto.CompanyField,
            ApprovalStatus = 0,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

}
