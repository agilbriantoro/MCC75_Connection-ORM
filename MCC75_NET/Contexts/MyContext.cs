﻿using MCC75_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace MCC75_NET.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profilling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           /* modelBuilder.Entity<Employee>().HasAlternateKey(e => new
            {
                e.Email,
                e.PhoneNumber
            });*/

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(a => a.employee)
                .HasForeignKey<Account>(fk => fk.EmployeesNik);
        }
    }
}