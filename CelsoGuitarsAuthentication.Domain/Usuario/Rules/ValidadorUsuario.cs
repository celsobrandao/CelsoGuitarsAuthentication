using FluentValidation;
using UsuarioModel = CelsoGuitarsAuthentication.Domain.Usuario.Usuario;

namespace CelsoGuitarsAuthentication.Domain.Usuario.Rules
{
    public class ValidadorUsuario : AbstractValidator<UsuarioModel>
    {
        public ValidadorUsuario()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Email).SetValidator(new ValidadorEmail());
            RuleFor(x => x.Senha).SetValidator(new ValidadorSenha());
        }
    }
}
