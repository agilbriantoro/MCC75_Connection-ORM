﻿// <auto-generated />
using System;
using MCC75_NET.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCC75_NET.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MCC75_NET.Models.Account", b =>
                {
                    b.Property<string>("EmployeesNik")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("EmployeesNik");

                    b.ToTable("tb_m_account");
                });

            modelBuilder.Entity("MCC75_NET.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNik")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .HasColumnName("account_nik");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleid");

                    b.HasKey("Id");

                    b.HasIndex("AccountNik");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_tr_Account_Roles");
                });

            modelBuilder.Entity("MCC75_NET.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Gpa")
                        .HasColumnType("real")
                        .HasColumnName("gpa");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("major");

                    b.Property<int>("UniversityId")
                        .HasMaxLength(11)
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.Property<string>("degree")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("degree");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("tb_m_educations");
                });

            modelBuilder.Entity("MCC75_NET.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birtdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("NIK");

                    b.HasAlternateKey("Email", "PhoneNumber");

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("MCC75_NET.Models.Profilling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EducationsId")
                        .HasColumnType("int")
                        .HasColumnName("education_id");

                    b.Property<string>("EmployeeNik")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .HasColumnName("employee_nik");

                    b.HasKey("Id");

                    b.HasIndex("EducationsId");

                    b.HasIndex("EmployeeNik");

                    b.ToTable("tb_tr_profilings");
                });

            modelBuilder.Entity("MCC75_NET.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("MCC75_NET.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_universities");
                });

            modelBuilder.Entity("MCC75_NET.Models.Account", b =>
                {
                    b.HasOne("MCC75_NET.Models.Employee", "employee")
                        .WithOne("Account")
                        .HasForeignKey("MCC75_NET.Models.Account", "EmployeesNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("MCC75_NET.Models.AccountRole", b =>
                {
                    b.HasOne("MCC75_NET.Models.Account", "Account")
                        .WithMany("accountRoles")
                        .HasForeignKey("AccountNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC75_NET.Models.Role", "Role")
                        .WithMany("accountRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MCC75_NET.Models.Education", b =>
                {
                    b.HasOne("MCC75_NET.Models.University", "university")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("university");
                });

            modelBuilder.Entity("MCC75_NET.Models.Profilling", b =>
                {
                    b.HasOne("MCC75_NET.Models.Education", "Education")
                        .WithMany("profillings")
                        .HasForeignKey("EducationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC75_NET.Models.Employee", "Employee")
                        .WithMany("profillings")
                        .HasForeignKey("EmployeeNik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MCC75_NET.Models.Account", b =>
                {
                    b.Navigation("accountRoles");
                });

            modelBuilder.Entity("MCC75_NET.Models.Education", b =>
                {
                    b.Navigation("profillings");
                });

            modelBuilder.Entity("MCC75_NET.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("profillings");
                });

            modelBuilder.Entity("MCC75_NET.Models.Role", b =>
                {
                    b.Navigation("accountRoles");
                });

            modelBuilder.Entity("MCC75_NET.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
