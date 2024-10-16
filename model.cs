using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace models
{
    public class Employee
    {
        [Key]
        public int Employeeid { get; set; }
        
        public string EmployeeName { get; set; } = string.Empty; 
        
        public int Departid { get; set; }
    }

    public class EmployeeLeave
    {
        [Key]
        public int Leaveid { get; set; }
        
        public int Employeeid { get; set; }
        
        public int NumOfDays { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
        public string Dbpath { get; }

        public EmployeeContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Dbpath = System.IO.Path.Join(path, "LeaveManagement.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Dbpath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasKey(k => k.Employeeid);
            modelBuilder.Entity<EmployeeLeave>().HasKey(k => k.Leaveid);
        }
    }
}
