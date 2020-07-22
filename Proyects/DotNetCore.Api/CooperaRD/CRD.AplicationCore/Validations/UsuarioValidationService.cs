using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
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
    }
}
