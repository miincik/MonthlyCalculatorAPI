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
                entity.Property(e=>e.IsBlocked);
            });
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.HasOne(e => e.Account).WithOne(e=>e.User).HasForeignKey<User>(e=>e.AccountId);
                entity.HasOne(e => e.Gender).WithOne(e=>e.User).HasForeignKey<User>(e=>e.GenderId);
            });
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.SalaryAmount).IsRequired();
                entity.HasOne(e => e.User).WithMany(e => e.Salaries).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.SalaryType).WithMany(e=>e.Salaries).HasForeignKey(e=>e.SalaryTypeId);
                entity.HasOne(e => e.SalaryHistory).WithMany(e=>e.Salaries).HasForeignKey(e=>e.SalaryHistoryId);
            });
            modelBuilder.Entity<SalaryType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<SalaryHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date);
            });
            modelBuilder.Entity<Expence>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.ExpenceAmount).IsRequired();
                entity.HasOne(e => e.User).WithMany(e => e.Expences).HasForeignKey(e => e.UserId);
                entity.HasOne(e => e.ExpenceType).WithMany(e => e.Expences).HasForeignKey(e => e.ExpenceTypeId);
                entity.HasOne(e => e.ExpenceHistory).WithMany(e => e.Expences).HasForeignKey(e => e.ExpenceHistoryId);
            });
            modelBuilder.Entity<ExpenceType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<ExpenceHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date);
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
