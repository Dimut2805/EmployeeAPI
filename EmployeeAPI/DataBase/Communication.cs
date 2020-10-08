using Microsoft.EntityFrameworkCore;
using System;


namespace EmployeeAPI.DataBase
{
    public class Communication : DbContext
    {
        private String connectionString;
        public DbSet<Employee> employees { get; set; }
        public DbSet<Passport> passports { get; set; }

        public Communication(String connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey("id");
            modelBuilder
            .Entity<Employee>()
            .HasOne(u => u.passport)
            .WithOne(p => p.employee);
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
