using API.Utilities.Enums;

namespace API.DTOs.Companies;
public class UpdateVendorStatusDto
{
     public Guid Guid { get; set; }
     public ApprovalStatusLevel ApprovalStatus { get; set; }
}
