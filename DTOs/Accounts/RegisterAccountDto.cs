using API.Models;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.Accounts;
public class RegisterAccountDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
   // public IFormFile? CompanyLogo { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public static implicit operator Account(RegisterAccountDto accountDto)
    {
        return new()
        {

            Email = accountDto.Email,
            Password = accountDto.Password,
            RoleGuid = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static implicit operator Company(RegisterAccountDto accountDto)
    {
        return new()
        {
            Guid = Guid.NewGuid(),
            Name = accountDto.Name,
            Address = accountDto.Address,
            PhoneNumber = accountDto.PhoneNumber,
            AccountGuid = Guid.NewGuid(),
            CompanyLogo = null,
            ApprovalStatus = ApprovalStatusLevel.WaitingApproval,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }
}
