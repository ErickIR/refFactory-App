using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class RolService: Profile
    {
        public RolService()
        {
            CreateMap<Rol, RolDtoOut>();
        }
    }
}
