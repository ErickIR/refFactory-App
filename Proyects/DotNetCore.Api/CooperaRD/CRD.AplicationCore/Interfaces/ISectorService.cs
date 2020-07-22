
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface ISectorService
    {
        ServiceResult<IEnumerable<SectorDtoOut>> GetAllSectores();
        ServiceResult<SectorDtoOut> GetSectorBySectorId(int sectorId);
        ServiceResult<IEnumerable<SectorDtoOut>> GetAllSectoresBySeccionId(int seccionId);
    }
}
