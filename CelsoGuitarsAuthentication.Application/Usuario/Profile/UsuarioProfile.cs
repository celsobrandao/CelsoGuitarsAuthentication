using CelsoGuitarsAuthentication.Application.Usuario.DTO;
using UsuarioModel = CelsoGuitarsAuthentication.Domain.Usuario.Usuario;

namespace CelsoGuitarsAuthentication.Application.Usuario.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioModel, UsuarioOutputDTO>()
                .ForMember(x => x.Email, f => f.MapFrom(m => m.Email.Valor));
            CreateMap<UsuarioInputDTO, UsuarioModel>()
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));
            CreateMap<UsuarioUpdateDTO, UsuarioModel>()
                .ForPath(x => x.Email.Valor, f => f.MapFrom(m => m.Email));
        }
    }
}
