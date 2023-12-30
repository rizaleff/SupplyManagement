using API.DTOs.Roles;
using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Companies;
public class CompanyDto
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? CompanyLogo { get; set; }
    public string ApprovalStatus {  get; set; }

    public static explicit operator CompanyDto(Company company)
    {
        return new CompanyDto
        {
            Guid = company.Guid, 
            Name = company.Name,
            Address = company.Address,
            Email = company.Email,
            PhoneNumber = company.PhoneNumber,
            CompanyLogo = company.CompanyLogo,
            ApprovalStatus = company.ApprovalStatus.ToString()
        };
    }
}