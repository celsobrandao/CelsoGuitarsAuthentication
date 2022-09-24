using CelsoGuitarsAuthentication.Application.Usuario.DTO;
using MediatR;

namespace CelsoGuitarsAuthentication.Application.Usuario.Handler.Command
{
    public class ValidarLoginUsuarioCommand : IRequest<ValidarLoginUsuarioCommandResponse>
    {
        public UsuarioLoginInputDTO Usuario { get; set; }

        public ValidarLoginUsuarioCommand(UsuarioLoginInputDTO usuario)
        {
            Usuario = usuario;
        }
    }

    public class ValidarLoginUsuarioCommandResponse
    {
        public UsuarioLoginOutputDTO Usuario { get; set; }

        public ValidarLoginUsuarioCommandResponse(UsuarioLoginOutputDTO usuario)
        {
            Usuario = usuario;
        }
    }

    public class CriarUsuarioCommand : IRequest<CriarUsuarioCommandResponse>
    {
        public UsuarioInputDTO Usuario { get; set; }

        public CriarUsuarioCommand(UsuarioInputDTO usuario)
        {
            Usuario = usuario;
        }
    }

    public class CriarUsuarioCommandResponse
    {
        public UsuarioOutputDTO Usuario { get; set; }

        public CriarUsuarioCommandResponse(UsuarioOutputDTO usuario)
        {
            Usuario = usuario;
        }
    }

    public class AtualizarUsuarioCommand : IRequest<AtualizarUsuarioCommandResponse>
    {
        public UsuarioUpdateDTO Usuario { get; set; }

        public AtualizarUsuarioCommand(UsuarioUpdateDTO usuario)
        {
            Usuario = usuario;
        }
    }

    public class AtualizarUsuarioCommandResponse
    {
        public UsuarioOutputDTO Usuario { get; set; }

        public AtualizarUsuarioCommandResponse(UsuarioOutputDTO usuario)
        {
            Usuario = usuario;
        }
    }

    public class RemoverUsuarioCommand : IRequest<RemoverUsuarioCommandResponse>
    {
        public RemoverUsuarioCommand(Guid iD)
        {
            ID = iD;
        }

        public Guid ID { get; set; }
    }

    public class RemoverUsuarioCommandResponse
    {
        public RemoverUsuarioCommandResponse()
        {
        }
    }
}
