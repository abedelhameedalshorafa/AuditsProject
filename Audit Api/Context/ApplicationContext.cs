using Audit_Api.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Audit_Api.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e=>e.Department)
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<User>()
                .HasMany(u=>u.Audits)
                .WithOne(a=>a.User)
                .HasForeignKey(a => a.UserID);

            modelBuilder.Entity<Employee>()
                .HasMany(e=>e.Audits)
                .WithOne(a=>a.Employee)
                .HasForeignKey(a => a.EmployeeID);


            // Initializing Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "HR" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "Finance" }
            );

            // Initializing Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin" },
                new User { Id = 2, Name = "User1" },
                new User { Id = 3, Name = "User2" }
            );

            // Initializing Employees with Foreign Key to Department
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice", Position = "Manager", DepartmentID = 1 },
                new Employee { Id = 2, Name = "Bob", Position = "Developer", DepartmentID = 2 },
                new Employee { Id = 3, Name = "Charlie", Position = "Analyst", DepartmentID = 3 }
            );

            // Initializing Audits with Foreign Keys to Employee and User
            modelBuilder.Entity<Audit>().HasData(
                new Audit { Id = 1, Action = "Create", EmployeeID = 1, UserID = 1, Timestamp = DateTime.Now },
                new Audit { Id = 2, Action = "Update", EmployeeID = 2, UserID = 2, Timestamp = DateTime.Now },
                new Audit { Id = 3, Action = "Delete", EmployeeID = 3, UserID = 3, Timestamp = DateTime.Now }
            );
        }   
    }
}
