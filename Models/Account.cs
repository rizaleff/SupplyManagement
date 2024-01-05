using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_m_accounts")]
public class Account : BaseEntity
{
    [Column("password", TypeName = "LONGTEXT")]
    public string Password { get; set; }

    [Column("email", TypeName = "varchar(100)")]
    public string Email { get; set; }

    [Column("role_guid")]
    public Guid RoleGuid { get; set; }


    /*
     * Cardinality
     */

    public Company? Company { get; set; }
    public Employee? Employee { get; set; }
    public Role? Role { get; set; }
}
