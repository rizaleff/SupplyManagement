using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_m_roles")]
public class Role : BaseEntity
{
    [Column("name", TypeName = "varchar(25)")]
    public string Name { get; set; }

    public ICollection<Account>? Accounts { get; set; }

}