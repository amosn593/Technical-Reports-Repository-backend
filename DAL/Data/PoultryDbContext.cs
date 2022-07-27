using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class PoultryDbContext : DbContext
    {
        public PoultryDbContext(DbContextOptions<PoultryDbContext> options)
            : base(options)
        {
        }

        public DbSet<DOMAIN.Models.Report> Reports { get; set; }
        public DbSet<DOMAIN.Models.Directorate> Directorates { get; set; }
        public DbSet<DOMAIN.Models.Department> Departments { get; set; }
    }
}
