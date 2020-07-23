using AutoMapper;
using CRD.Common.DTOs.DtoOut;
using CRD.Domain.Models;

namespace CRD.AplicationCore.Profiles
{
    class JuntaDeVecinosProfile: Profile
    {
        public JuntaDeVecinosProfile()
        {
            CreateMap<JuntaDeVecinos, JuntaDeVecinosDtoOut>();
        }
    }
}
