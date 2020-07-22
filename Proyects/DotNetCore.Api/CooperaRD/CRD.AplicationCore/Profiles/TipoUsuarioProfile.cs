using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class TipoUsuarioProfile : Profile
    {
        public TipoUsuarioProfile()
        {
            CreateMap<TipoUsuario,TipoUsuarioDtoOut>();
        }
    }
}
