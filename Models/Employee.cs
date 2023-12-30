using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_m_employees")]
public class Employee : BaseEntity
{

    [Column("first_name", TypeName = "varchar(100)")]
    public string FirstName { get; set; }

    [Column("last_name", TypeName = "varchar(100)")]
    public string? LastName { get; set; }

    [Column("nik", TypeName ="nvarchar(6)")]
    public string nik {  get; set; }
    [Column("gender")]
    public GenderLevel Gender { get; set; }

    [Column("email", TypeName = "nvarchar(100)")]
    public string Email { get; set; }

    [Column("account_guid")]
    public Guid AccountGuid { get; set; }

    /*
     * Cardinality
     */

    public Account? Account { get; set; }

}
