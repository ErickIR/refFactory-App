using CRD.Common.DTOs;
using CRD.Common.DTOs.DtoOut;
using CRD.Common.Models;

namespace CRD.AplicationCore.Interfaces
{
    public interface ILoginService
    {
        ServiceResult<UsuarioDtoOut> ValidateLogin(LoginDto loginDto);
    }
}
