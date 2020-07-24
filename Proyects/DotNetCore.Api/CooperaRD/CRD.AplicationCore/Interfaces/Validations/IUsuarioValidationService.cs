
namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IUsuarioValidationService
    {
        bool IsExistingUsuarioId(int usuarioId);
        bool IsExistingDocumento(int tipoDocumentoId, string documento);
        bool IsValidEmail(string email);
        bool IsExistingEmail(string email);

    }
}
