
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface ICargoService
    {
        ServiceResult<IEnumerable<CargoDtoOut>> GetAllCargos();
        ServiceResult<CargoDtoOut> GetCargoByCargoId(int cargoId);
    }
}
