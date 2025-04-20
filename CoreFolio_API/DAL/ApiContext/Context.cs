using CoreFolio_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreFolio_API.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MEMIR;database=CoreFolioApiDb;integrated security=true;");
        }
        public DbSet<Category> Categories { get; set; }
    }

}
