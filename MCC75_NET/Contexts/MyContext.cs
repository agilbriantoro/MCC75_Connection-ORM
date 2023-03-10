using MCC75_NET.Models;
using Microsoft.EntityFrameworkCore;
using MCC75_NET.ViewModels;
using MCC75_NET.Models;

namespace MCC75_NET.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> option) : base(option)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profilling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<University> Universities { get; set; }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().HasAlternateKey(e => new
            //{
            //    e.Email,
            //    e.PhoneNumber
            //});
            modelBuilder.Entity<Employee>().HasIndex(e => new
            {
                e.Email,
                e.PhoneNumber
            }).IsUnique();

            // Relasi one Employee ke one Account sekaligus menjadi Primary Key
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(a => a.employee)
                .HasForeignKey<Account>(fk => fk.EmployeeNIK);
        }

        // Fluent API
        public DbSet<MCC75_NET.ViewModels.RegisterVM> RegisterVM { get; set; }
    }
}