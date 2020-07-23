using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class IncidenciaUsuarioValidationService: IIncidenciaUsuarioValidationService
    {
        readonly IMasterRepository masterRepository;

        public IncidenciaUsuarioValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }
        public bool IsExistingIncidenciaUsuarioId(int incidenciaUsuarioId)
        {
            var isExisting = masterRepository.IncidenciaUsuario.GetAll().Any(i =>
                i.IncidenciaUsuarioId == incidenciaUsuarioId);

            return isExisting;
        }
    }
}
