using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.VendorOffers;
public class VendorOfferDto
{
    public Guid Guid {  get; set; }
    public Guid ProjectTenderGuid { get; set; }
    public Guid VendorGuid { get; set; }
    public float OfferPrice { get; set; }
    public OfferStatusLevel OfferStatus {  get; set; }

    public static implicit operator VendorOffer(VendorOfferDto dto)
    {
        return new VendorOffer
        {
            Guid = dto.Guid,
            ProjectTenderGuid = dto.ProjectTenderGuid,
            VendorGuid = dto.VendorGuid,
            OfferPrice = dto.OfferPrice,
            ModifiedDate = DateTime.Now,
            OfferStatus = dto.OfferStatus
        }; 
    }

    public static explicit operator VendorOfferDto(VendorOffer vendorOffer)
    {
        return new VendorOfferDto
        { 
            Guid = vendorOffer.Guid,
            OfferPrice = vendorOffer.OfferPrice,   
            OfferStatus = vendorOffer.OfferStatus,
            ProjectTenderGuid = vendorOffer.ProjectTenderGuid
            
        };
    }
}
