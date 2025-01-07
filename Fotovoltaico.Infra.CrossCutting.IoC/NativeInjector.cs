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
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonAddressService, PersonAddressService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonAddressRepository, PersonAddressRepository>();

            #endregion
        }
    }
}
