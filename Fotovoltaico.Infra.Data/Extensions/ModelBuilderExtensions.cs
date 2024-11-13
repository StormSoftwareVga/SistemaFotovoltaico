using Fotovoltaico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fotovoltaico.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.ChangeDate):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.InclusionDate):
                            property.IsNullable = false;
                            break;
                        default:
                            break;
                    }
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            return modelBuilder;
        }
    }
}
