using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    public class BarrioProfile: Profile
    {
        public BarrioProfile()
        {
            CreateMap<Barrio, BarrioDtoOut>();
        }
    }
}
