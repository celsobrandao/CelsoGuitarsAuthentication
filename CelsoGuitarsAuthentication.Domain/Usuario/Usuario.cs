using CelsoGuitarsAuthentication.Domain.Usuario.Rules;
using CelsoGuitarsAuthentication.Domain.Usuario.ValueObject;
using CelsoGuitarsAuthentication.Infra.Entidade;
using CelsoGuitarsAuthentication.Infra.Utils;
using FluentValidation;

namespace CelsoGuitarsAuthentication.Domain.Usuario
{
    public class Usuario : Entidade<Guid>
    {
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public void Validar() => new ValidadorUsuario().ValidateAndThrow(this);

        public void AtualizarSenha()
        {
            Senha.Valor = SegurancaUtils.HashSHA1(Senha.Valor);
        }
    }
}
