using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class UsuarioValidationService: IUsuarioValidationService
    {
        readonly IMasterRepository masterRepository;

        public UsuarioValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingUsuarioId(int usuarioId) 
        {
            var IsExisting = masterRepository.Usuario.GetAll().Any(u => 
                u.UsuarioId == usuarioId);

            return IsExisting;
        }

        public bool IsExistingDocumento(int tipoDocumentoId, string documento)
        {
            var IsExisting = masterRepository.Usuario.GetAll().Any(u => 
                u.TipoDocumentoId == tipoDocumentoId && u.Documento.ToLower() == documento.ToLower());

            return IsExisting;
        }

        public bool IsValidEmail(string email)
        {
            var emailValidator = new EmailAddressAttribute();

            return emailValidator.IsValid(email);
        }
        public bool IsExistingEmail(string email)
        {
            var IsExisting = masterRepository.Usuario.GetAll().Any(
                u => u.Email.ToLower() == email.ToLower());

            return IsExisting;
        }
    }
}
