using MassageGirls.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MassageGirls.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        } 

        public DbSet<GirlProfile> GirlProfile { get; set; }
        public DbSet<MassageType> MassageType { get; set; }
        public DbSet<Town> Town { get; set; }

        public DbSet<AppUser> AppUser {  get; set; }
    }
}
