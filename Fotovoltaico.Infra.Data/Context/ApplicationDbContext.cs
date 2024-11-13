using Fotovoltaico.Domain.Entities.Domain;
using Fotovoltaico.Infra.Data.EntityConfig;
using Fotovoltaico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Fotovoltaico.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        #region DB SETs

        public DbSet<User> Users => Set<User>();

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyGlobalConfigurations();
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }

    }
}
