using CelsoGuitarsAuthentication.Application.Usuario.Service;
using CelsoGuitarsAuthentication.Application.Usuario.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CelsoGuitars.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);
            services.AddMediatR(typeof(ConfigurationModule).Assembly);

            #region Usuário
            services.AddScoped<IUsuarioService, UsuarioService>();
            #endregion

            return services;
        }
    }
}
