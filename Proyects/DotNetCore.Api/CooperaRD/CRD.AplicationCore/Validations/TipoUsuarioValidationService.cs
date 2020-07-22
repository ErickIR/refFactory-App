using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class TipoUsuarioValidationService: ITipoUsuarioValidationService
    {
        readonly IMasterRepository masterRepository;

        public TipoUsuarioValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingTipoUsuarioId(int tipoUsuarioId)
        {
            var isExisting = masterRepository.TipoUsuario.GetAll().Any(t =>
                t.TipoUsuarioId == tipoUsuarioId);

            return isExisting;
        }
    }
}
