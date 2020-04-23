using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA_Verwaltung.Models.Db_Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Employee_Roll> Employee_Rolls { get; set; }

        public DbSet<Roll> Rolls { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            modelBuilder.Entity<Employee_Roll>().HasKey(Employee_Roll => new { Employee_Roll.Employee_Role_Id });


            modelBuilder.Entity<Employee_Roll>()
                        .HasOne(Employee_Roll => Employee_Roll.Employee)
                        .WithMany(Employee => Employee.Employee_Rolls)
                        .HasForeignKey(Employee_Roll => Employee_Roll.Employee_Id);


            modelBuilder.Entity<Employee_Roll>()
                        .HasOne(Employee_Roll => Employee_Roll.Roll)
                        .WithMany(Roll => Roll.Employee_Rolls)
                        .HasForeignKey(Employee_Roll => Employee_Roll.Roll_Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}

