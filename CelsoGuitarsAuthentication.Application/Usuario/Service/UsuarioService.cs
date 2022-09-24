using AutoMapper;
using CelsoGuitarsAuthentication.Application.Usuario.DTO;
using CelsoGuitarsAuthentication.Application.Usuario.Service.Interfaces;
using CelsoGuitarsAuthentication.Domain.Usuario.Repository;
using CelsoGuitarsAuthentication.Infra.Utils;
using UsuarioModel = CelsoGuitarsAuthentication.Domain.Usuario.Usuario;

namespace CelsoGuitarsAuthentication.Application.Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioOutputDTO> Criar(UsuarioInputDTO dto)
        {
            var usuario = _mapper.Map<UsuarioModel>(dto);

            usuario.Validar();

            usuario.AtualizarSenha();

            await _usuarioRepository.Save(usuario);

            return _mapper.Map<UsuarioOutputDTO>(usuario);
        }

        public async Task<UsuarioOutputDTO> Atualizar(UsuarioUpdateDTO dto)
        {
            var usuario = _mapper.Map<UsuarioModel>(dto);

            usuario.Validar();

            usuario.AtualizarSenha();

            await _usuarioRepository.Update(usuario);

            return _mapper.Map<UsuarioOutputDTO>(usuario);
        }

        public async Task Remover(Guid usuarioID)
        {
            var usuario = await _usuarioRepository.Get(usuarioID);

            await _usuarioRepository.Delete(usuario);
        }

        public async Task<UsuarioLoginOutputDTO> ValidarLogin(UsuarioLoginInputDTO dto)
        {
            var senha = SegurancaUtils.HashSHA1(dto.Senha);
            var id = await _usuarioRepository.ValidarLogin(dto.Email, senha);
            var valido = id != Guid.Empty;
            var mensagem = id == Guid.Empty ? "Usuário ou senha inválidos." : "";

            return new UsuarioLoginOutputDTO(valido, mensagem, id);
        }

        public Task<UsuarioModel> Obter(Guid usuarioID)
        {
            return _usuarioRepository.Get(usuarioID);
        }

        public async Task<List<UsuarioOutputDTO>> ObterTodos()
        {
            var result = await _usuarioRepository.GetAll();

            return _mapper.Map<List<UsuarioOutputDTO>>(result);
        }
    }
}
