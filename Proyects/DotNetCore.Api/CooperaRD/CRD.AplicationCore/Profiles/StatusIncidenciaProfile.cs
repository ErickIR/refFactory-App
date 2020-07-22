using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class StatusIncidenciaProfile: Profile
    {
        public StatusIncidenciaProfile()
        {
            CreateMap<StatusIncidencia, StatusIncidenciaDtoOut>();
        }
    }
}
