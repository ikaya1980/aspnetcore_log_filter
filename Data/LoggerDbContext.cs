using aspnetcore_log_filter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace aspnetcore_log_filter.Data
{
    public class LoggerDbContext : DbContext
    {

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-aspnetcore_log_filter-8B569336-2F93-4C32-80BC-C83F434C0A88;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<AppUser> AppUsers { get; set; }
    }

}
