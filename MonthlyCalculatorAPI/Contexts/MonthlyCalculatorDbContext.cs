using Microsoft.EntityFrameworkCore;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Models.Entities.Incomes;

namespace MonthlyCalculatorAPI.Contexts
{
    public class MonthlyCalculatorDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Account>? Account { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Salary>? Salaries { get; set; }
        public DbSet<SalaryType>? SalaryTypes { get; set; }
        public DbSet<SalaryHistory>? SalaryHistories { get; set; }
        public DbSet<Expence>? Expences { get; set; }
        public DbSet<ExpenceType>? ExpenceTypes { get; set; }
        public DbSet<ExpenceHistory>? ExpenceHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            optionsBuilder.UseMySql("server=localhost;database=monthlydb;user=root;port=3306;password=toortoor", serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });
            modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Id = 1,
                Email = "mustafa.incik@sahabt.com",
                Password = "123123",
            });
         }
    }
}
