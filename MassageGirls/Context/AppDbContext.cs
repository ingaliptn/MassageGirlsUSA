using MassageGirls.Models;
using Microsoft.EntityFrameworkCore;

namespace MassageGirls.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<GirlProfile> GirlProfile { get; set; }
        public DbSet<MassageType> MassageType { get; set; }
    }
}
