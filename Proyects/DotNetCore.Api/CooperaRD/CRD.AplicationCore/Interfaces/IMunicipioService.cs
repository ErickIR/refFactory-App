using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IMunicipioService
    {
        ServiceResult<int> CreateMunicipio(MunicipioDtoIn municipioDto);
        ServiceResult<MunicipioDtoOut> GetMunicipioByMunicipioId(int municipioId);
        ServiceResult<IEnumerable<MunicipioDtoOut>> GetAllMunicipios();
        ServiceResult<MunicipioDtoOut> GetMunicipioByBarrioId(int barrioId);
        ServiceResult<int> UpdateMunicipio(int municipioId, MunicipioDtoIn municipioDto);
        ServiceResult<int> DeleteMunicipio(int municipioId);
    }
}
