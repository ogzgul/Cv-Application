using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cv.Models;

namespace Cv.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cv.Models.Member>? Member { get; set; }
        public DbSet<Cv.Models.Education>? Education { get; set; }
        public DbSet<Cv.Models.Experience>? Experience { get; set; }
        public DbSet<Cv.Models.Language>? Language { get; set; }
        public DbSet<Cv.Models.Course>? Course { get; set; }
        public DbSet<Cv.Models.Reference>? Reference { get; set; }
    }
}