using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class RoleRepository : GeneralRepository<Role>, IRoleRepository{

    public RoleRepository(SupplyManagementDbContext context) : base(context) { }

    public Guid GetDefaultRoleGuid()
    {
        return _context.Set<Role>().FirstOrDefault(r => r.Name == "VendorCompany").Guid;
    }

}
