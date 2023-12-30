using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class VendorOfferRepository : GeneralRepository<VendorOffer>, IVendorOfferRepository{

    public VendorOfferRepository(SupplyManagementDbContext context) : base(context) { }
}
