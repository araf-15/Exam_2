using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_4
{
    public class DatabaseContext : DbContext
    {
        private string connectionString { get; set; }
        private string migrationAssemblyName { get; set; }


        public DatabaseContext()
        {
            connectionString = "Server=DESKTOP-V3GHE7O\\MSSQLSERVER2019;Database=Exam_2;User Id=Araf;Password=araf.hasan;";
            migrationAssemblyName = typeof(Program).Assembly.FullName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    connectionString,
                    m => m.MigrationsAssembly(migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
