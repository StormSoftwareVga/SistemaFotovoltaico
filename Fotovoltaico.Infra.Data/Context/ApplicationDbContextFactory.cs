using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Fotovoltaico.Infra.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Port=3307;Database=fotovoltaico;User=root;Password=303304;",
                new MySqlServerVersion(new Version()));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
