using API.Models;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Vendors;
public class VendorDto
{
    public Guid Guid { get; set; }
    public string CompanyType { get; set; }
    public string CompanyField { get; set; }
    public ApprovalStatusLevel ApprovalStatus { get; set; }
    public DateTime? ModifiedDate {  get; set; }

    public static implicit operator Vendor(VendorDto vendorDto)
    {
        return new Vendor
        {
            Guid = vendorDto.Guid,
            CompanyType = vendorDto.CompanyType,
            CompanyField = vendorDto.CompanyField,
            ApprovalStatus = vendorDto.ApprovalStatus,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator VendorDto(Vendor vendor)
    {
        return new VendorDto
        {
            Guid = vendor.Guid,
            CompanyField = vendor.CompanyField,
            CompanyType = vendor.CompanyType,
            ApprovalStatus = vendor.ApprovalStatus,
            ModifiedDate = vendor.ModifiedDate
        };
    }
}
