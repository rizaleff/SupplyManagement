using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_vendors")]
public class Vendor : BaseEntity
{
    [Column("company_type", TypeName = "varchar(100)")]
    public string CompanyType { get; set; }
    [Column("company_field", TypeName = "varchar(100)")]
    public string CompanyField {  get; set; }
    [Column("approval_status")]
    public ApprovalStatusLevel ApprovalStatus { get; set; }

    /*Cardinality*/

    public Company? Company { get; set; }
    public ICollection<VendorOffer>? VendorOffers { get; set; }
}

