using API.Contracts;
using API.Data;
using API.DTOs.Employees;
using API.Models;

namespace API.Repositories;
public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository{

    public EmployeeRepository(SupplyManagementDbContext context) : base(context) { }

    public Employee GetByAccountGuid(Guid guid)
    {
        var entity = _context.Set<Employee>().FirstOrDefault(e => e.AccountGuid == guid);
        _context.ChangeTracker.Clear();
        return entity;
    }
}
