using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.VendorOffers;
public class CreateVendorOfferDto
{
    public Guid ProjectTenderGuid { get; set; }
    public Guid VendorGuid { get; set; }
    public float OfferPrice { get; set; }
    public OfferStatusLevel OfferStatus { get; set; }

    public static implicit operator VendorOffer(CreateVendorOfferDto dto)
    {
        return new VendorOffer
        {
            Guid = Guid.NewGuid(),
            ProjectTenderGuid = dto.ProjectTenderGuid,
            VendorGuid = dto.VendorGuid,
            OfferPrice = dto.OfferPrice,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            OfferStatus = 0
        };
    }
}   