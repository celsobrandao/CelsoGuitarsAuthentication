using CelsoGuitarsAuthentication.Domain.Usuario.Repository;
using CelsoGuitarsAuthentication.Repository.Context;
using CelsoGuitarsAuthentication.Repository.Database;
using CelsoGuitarsAuthentication.Repository.Repository.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CelsoGuitarsAuthentication.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CelsoGuitarsAuthenticationContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));

            #region Usuário
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            return services;
        }
    }
}
