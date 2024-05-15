using _8BallShot.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _8BallShot.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Torneio> Torneio { get; set; }
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Fases> Fases { get; set; }

    }
}
