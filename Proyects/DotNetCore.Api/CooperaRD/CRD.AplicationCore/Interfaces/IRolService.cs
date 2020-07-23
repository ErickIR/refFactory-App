using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;
using System.Collections.Generic;

namespace CRD.AplicationCore.Interfaces
{
    public interface IRolService
    {
        ServiceResult<IEnumerable<RolDtoOut>> GetAllRoles();
        ServiceResult<RolDtoOut> GetRolByRolId(int rolId);
    }
}
