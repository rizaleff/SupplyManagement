namespace API.Data;

using API.Models;
using API.Utilities.Enums;
using API.Utilities.Handlers;
using Microsoft.EntityFrameworkCore;
using System.Data;

public class SupplyManagementDbContext : DbContext
{
    public SupplyManagementDbContext(DbContextOptions<SupplyManagementDbContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<ProjectTender> ProjectTenders { get; set; }
    public DbSet<VendorOffer> VendorOffers {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Company>().HasIndex(e => e.Email).IsUnique();

        modelBuilder.Entity<Company>()
            .HasOne(c => c.Vendor)
            .WithOne(v => v.Company)
            .HasForeignKey<Vendor>(v => v.Guid);

        modelBuilder.Entity<Account>()
           .HasOne(a => a.Company)
           .WithOne(c => c.Account)
           .HasForeignKey<Company>(c => c.AccountGuid);

        modelBuilder.Entity<Account>()
           .HasOne(a => a.Employee)
           .WithOne(e => e.Account)
           .HasForeignKey<Employee>(e => e.AccountGuid);

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Accounts)
            .WithOne(a => a.Role)
            .HasForeignKey(a => a.RoleGuid);

        modelBuilder.Entity<ProjectTender>()
           .HasMany(pt => pt.VendorOffers)
           .WithOne(vo => vo.ProjectTender)
           .HasForeignKey(vo => vo.ProjectTenderGuid);

        modelBuilder.Entity<Vendor>()
           .HasMany(v => v.VendorOffers)
           .WithOne(vo => vo.Vendor)
           .HasForeignKey(vo => vo.VendorGuid);

        InsertDefaultData(modelBuilder);
    }

    private void InsertDefaultData(ModelBuilder modelBuilder)
    {

        //RoleData
        var companyRoleGuid = Guid.NewGuid();
        var adminRoleGuid = Guid.NewGuid();
        var managerRoleGuid = Guid.NewGuid();

        var companyRole = new Role
        {
            Guid = companyRoleGuid,
            Name = "VendorCompany"
        };

        var adminRole = new Role
        {
            Guid = adminRoleGuid,
            Name = "Admin"
        };

        var managerRole = new Role
        {
            Guid = managerRoleGuid,
            Name = "Manager"
        };


        //Add Account

        var adminAccountGuid = Guid.NewGuid();
        var managerAccountGuid = Guid.NewGuid();


        var adminAccount = new Account
        {
            Guid = adminAccountGuid,
            Password = HashingHandler.HashPassword("Admin1234"),
            RoleGuid = adminRoleGuid,
        };


        var managerAccount = new Account
        {
            Guid = managerAccountGuid,
            Password = HashingHandler.HashPassword("Manager1234"),
            RoleGuid = managerRoleGuid
        };


        var adminEmployee = new Employee
        {
            Guid = Guid.NewGuid(),
            FirstName = "Jennie",
            LastName = "Jane",
            Email = "jennie@gmail.com",
            Gender = GenderLevel.female,
            nik = "119119",
            AccountGuid = adminAccountGuid
        };

        var managerEmployee = new Employee
        {
            Guid = Guid.NewGuid(),
            FirstName = "Chris",
            LastName = "Martin",
            Email = "chris@gmail.com",
            Gender = GenderLevel.male,
            nik = "119120",
            AccountGuid = managerAccountGuid
        };


        //Role
        modelBuilder.Entity<Role>().HasData(adminRole);
        modelBuilder.Entity<Role>().HasData(managerRole);
        modelBuilder.Entity<Role>().HasData(companyRole);

        //Account
        modelBuilder.Entity<Account>().HasData(adminAccount);
        modelBuilder.Entity<Account>().HasData(managerAccount);

        //Employee
        modelBuilder.Entity<Employee>().HasData(adminEmployee);
        modelBuilder.Entity<Employee>().HasData(managerEmployee);

    }
}
