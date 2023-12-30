using API.Utilities.Enums;

namespace API.DTOs.Companies;
public class UpdateCompanyStatusDto
{
     public Guid Guid { get; set; }
     public ApprovalStatusLevel ApprovalStatus { get; set; }
}
