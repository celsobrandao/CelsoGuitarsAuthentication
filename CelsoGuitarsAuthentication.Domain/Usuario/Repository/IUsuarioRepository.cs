using CelsoGuitarsAuthentication.Infra.Repository;

namespace CelsoGuitarsAuthentication.Domain.Usuario.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Guid> ValidarLogin(string email, string senha);
    }
}
