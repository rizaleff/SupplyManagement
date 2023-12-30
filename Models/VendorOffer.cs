using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
[Table("tb_vendor_offers")]
public class VendorOffer : BaseEntity
{

    [Column("project_tender_guid")]
    public Guid ProjectTenderGuid { get; set; }
    [Column("vendor_guid")]
    public Guid VendorGuid { get; set; }
    [Column("offer_price")]
    public float OfferPrice { get; set; }
    [Column("offer_status")]
    public OfferStatusLevel OfferStatus { get; set; }

    /*Cardinality*/
    public ProjectTender? ProjectTender {get; set;} 
    
    public Vendor? Vendor { get; set;}
}
