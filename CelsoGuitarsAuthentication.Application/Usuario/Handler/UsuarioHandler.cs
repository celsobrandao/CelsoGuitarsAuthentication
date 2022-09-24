using CelsoGuitarsAuthentication.Application.Usuario.Handler.Command;
using CelsoGuitarsAuthentication.Application.Usuario.Handler.Query;
using CelsoGuitarsAuthentication.Application.Usuario.Service.Interfaces;
using MediatR;

namespace CelsoGuitarsAuthentication.Application.Usuario.Handler
{
    public class UsuarioHandler : IRequestHandler<ValidarLoginUsuarioCommand, ValidarLoginUsuarioCommandResponse>,
                                  IRequestHandler<CriarUsuarioCommand, CriarUsuarioCommandResponse>,
                                  IRequestHandler<AtualizarUsuarioCommand, AtualizarUsuarioCommandResponse>,
                                  IRequestHandler<RemoverUsuarioCommand, RemoverUsuarioCommandResponse>,
                                  IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<ValidarLoginUsuarioCommandResponse> Handle(ValidarLoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.ValidarLogin(request.Usuario);

            return new ValidarLoginUsuarioCommandResponse(result);
        }

        public async Task<CriarUsuarioCommandResponse> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.Criar(request.Usuario);

            return new CriarUsuarioCommandResponse(result);
        }

        public async Task<AtualizarUsuarioCommandResponse> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.Atualizar(request.Usuario);

            return new AtualizarUsuarioCommandResponse(result);
        }

        public async Task<RemoverUsuarioCommandResponse> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
        {
            await _usuarioService.Remover(request.ID);

            return new RemoverUsuarioCommandResponse();
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.ObterTodos();

            return new GetAllUsuarioQueryResponse(result);
        }
    }
}
