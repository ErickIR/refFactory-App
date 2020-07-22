using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IRegionService
    {
        ServiceResult<int> CreateRegion(string nombre);
        ServiceResult<RegionDtoOut> GetRegionByRegionId(int regionId);
        ServiceResult<IEnumerable<RegionDtoOut>> GetAllRegiones();
        ServiceResult<int> UpdateRegion(int regionId, string nombre);
        ServiceResult<int> DeleteRegion(int regionId);
    }
}
