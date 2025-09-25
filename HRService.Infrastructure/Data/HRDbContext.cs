using HRService.Core.Entities;
using HRService.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Employee_leave> Employee_Leaves { get; set; }


        // enum status is stored as 0 or 1 so instead Active or InActive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(a => a.Status).HasConversion<string>();

            //disable cascade delete
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Department)
                .WithMany(b => b.Jobs)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
