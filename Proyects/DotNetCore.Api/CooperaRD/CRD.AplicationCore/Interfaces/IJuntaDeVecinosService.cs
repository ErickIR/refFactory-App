using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IJuntaDeVecinosService
    {
        ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>> GetAllJuntasDeVecinos();
        ServiceResult<JuntaDeVecinosDtoOut> GetJuntaDeVecinosByJuntaDeVecinosId(int juntaDeVecinosId);
        ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>> GetAllJuntasDeVecinosByBarrioId(int barrioId);
        ServiceResult<IEnumerable<JuntaDeVecinosDtoOut>> GetAllJuntasDeVecinosByDistritoMunicipalId(int distritoMunicipalId);
    }
}
