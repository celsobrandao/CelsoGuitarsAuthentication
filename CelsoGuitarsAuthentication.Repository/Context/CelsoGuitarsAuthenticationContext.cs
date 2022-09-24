using Microsoft.EntityFrameworkCore;

namespace CelsoGuitarsAuthentication.Repository.Context
{
    public class CelsoGuitarsAuthenticationContext : DbContext
    {
        public CelsoGuitarsAuthenticationContext(DbContextOptions<CelsoGuitarsAuthenticationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CelsoGuitarsAuthenticationContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
