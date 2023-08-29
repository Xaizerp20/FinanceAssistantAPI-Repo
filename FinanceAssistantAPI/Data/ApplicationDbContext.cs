using FinanceAssistantAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceAssistantAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        DbSet<ApplicationFinancialRecordDto> FinancialRecords { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<ApplicationCategory> ApplicationCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationFinancialRecordDto>().ToTable("FinancialRecord");
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<ApplicationCategory>().ToTable("ApplicationCategorie");

        }

    }

    
}
