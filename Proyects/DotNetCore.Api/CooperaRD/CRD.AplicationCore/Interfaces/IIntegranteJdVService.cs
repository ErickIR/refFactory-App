using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IIntegranteJdVService
    {
        ServiceResult<IEnumerable<IntegranteJdVDtoOut>> GetAllIntegrantesJdV();
        ServiceResult<IntegranteJdVDtoOut> GetIntegranteJdVByIntegranteId(int integranteId);
        ServiceResult<IEnumerable<IntegranteJdVDtoOut>> GetAllIntegrantesJdVByJuntaDeVecinosId(int juntaDeVecinosId);
    }
}
