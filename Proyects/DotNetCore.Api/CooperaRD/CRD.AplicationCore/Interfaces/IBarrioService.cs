
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IBarrioService
    {
        ServiceResult<IEnumerable<BarrioDtoOut>> GetAllBarrios();
        ServiceResult<BarrioDtoOut> GetBarrioByBarrioId(int barrioId);
        ServiceResult<IEnumerable<BarrioDtoOut>> GetAllBarriosBySectorId(int sectorId);
    }
}
