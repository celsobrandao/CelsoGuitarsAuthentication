using CelsoGuitarsAuthentication.Domain.Usuario.Repository;
using CelsoGuitarsAuthentication.Repository.Context;
using CelsoGuitarsAuthentication.Repository.Database;
using Microsoft.EntityFrameworkCore;
using UsuarioModel = CelsoGuitarsAuthentication.Domain.Usuario.Usuario;

namespace CelsoGuitarsAuthentication.Repository.Repository.Usuario
{
    public class UsuarioRepository : Repository<UsuarioModel>, IUsuarioRepository
    {
        public UsuarioRepository(CelsoGuitarsAuthenticationContext context) : base(context)
        {
        }

        public Task<Guid> ValidarLogin(string email, string senha)
        {
            return DbSet.Where(x => x.Email.Valor.ToUpper() == email.ToUpper() && x.Senha.Valor == senha)
                        .Select(x => x.ID)
                        .FirstOrDefaultAsync();
        }
    }
}
