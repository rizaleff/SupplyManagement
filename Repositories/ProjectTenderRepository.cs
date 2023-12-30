using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class ProjectTenderRepository : GeneralRepository<ProjectTender>, IProjectTenderRepository{

    public ProjectTenderRepository(SupplyManagementDbContext context) : base(context) { }
}
