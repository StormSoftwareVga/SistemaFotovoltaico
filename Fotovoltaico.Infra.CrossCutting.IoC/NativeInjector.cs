using Fotovoltaico.Domain.Interfaces.Repositories;
using Fotovoltaico.Infra.Data.Repositories;
using Fotovoltaico.Domain.Interfaces.Services;
using Fotovoltaico.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fotovoltaico.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
