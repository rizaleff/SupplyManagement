using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_project_tenders")]
public class ProjectTender : BaseEntity
{

    [Column("title", TypeName = "varchar(100)")]
    public string title { get; set; }

    [Column("description", TypeName = "longtext")]
    public string description { get; set; }
    [Column("project_status")]
    public ProjectStatusLevel ProjectStatus { get; set; }


    /*Cardinality*/
    public ICollection<VendorOffer>? VendorOffers { get; set; }
}
