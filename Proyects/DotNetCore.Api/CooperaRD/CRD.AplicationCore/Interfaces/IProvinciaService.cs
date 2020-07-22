using CRD.Common.DTOs.DtoIn;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IProvinciaService
    {

        ServiceResult<int> CreateProvincia(ProvinciaDtoIn provinciaDto);
        ServiceResult<ProvinciaDtoOut> GetProvinciaByProvinciaId(int provinciaId);
        ServiceResult<IEnumerable<ProvinciaDtoOut>> GetAllProvincias();
        ServiceResult<int> UpdateProvincia(int provinciaId, ProvinciaDtoIn provinciaDto);
        ServiceResult<int> DeleteProvincia(int provinciaId);

    }
}
