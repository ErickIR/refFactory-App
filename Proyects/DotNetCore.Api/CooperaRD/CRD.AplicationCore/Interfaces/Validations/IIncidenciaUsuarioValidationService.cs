
namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IIncidenciaUsuarioValidationService
    {
        bool IsExistingIncidenciaUsuarioId(int incidenciaUsuarioId);
        bool IsExisingApoyo(int incidenciaId, int usuarioId);
    }
}
