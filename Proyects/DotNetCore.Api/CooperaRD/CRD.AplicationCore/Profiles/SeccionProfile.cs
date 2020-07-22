using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class SeccionProfile: Profile
    {
        public SeccionProfile()
        {
            CreateMap<Seccion, SeccionDtoOut>();
        }
    }
}
