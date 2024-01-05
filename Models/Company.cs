using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_companies")]
public class Company : BaseEntity
{
    [Column("name", TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    [Column("address", TypeName = "longtext")]
    public string Address {  get; set; }
    [Column("phone_number", TypeName = "varchar(20)")]
    public string PhoneNumber {  get; set; }
    [Column("company_logo")]
    public string? CompanyLogo { get; set; }
    [Column("approval_status")]

    public ApprovalStatusLevel ApprovalStatus {  get; set; }
    [Column ("account_Guid")]
    public Guid AccountGuid { get; set; }


    /*
     * Cardinality
     */

    public Vendor? Vendor { get; set; }
    public Account? Account { get; set; }

}
