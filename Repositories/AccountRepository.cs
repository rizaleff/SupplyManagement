using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories;
public class AccountRepository : GeneralRepository<Account>, IAccountRepository{

    public AccountRepository(SupplyManagementDbContext context) : base(context) { }

    public Account GetByEmail(string email)
    {
        var entity = _context.Set<Account>().FirstOrDefault(a => a.Email == email);
        _context.ChangeTracker.Clear();
        return entity;
    }
}
