using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class TipoIncidenciaProfile : Profile
    {
        public TipoIncidenciaProfile()
        {
            CreateMap<TipoIncidencia, TipoIncidenciaDtoOut>();
        }
    }
}
