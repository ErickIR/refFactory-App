using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class IncidenciaValidationService: IIncidenciaValidationService
    {
        readonly IMasterRepository masterRepository;

        public IncidenciaValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingIncidenciaId(int incidenciaId)
        {
            var isExisting = masterRepository.Incidencia.GetAll().Any(i =>
                i.IncidenciaId == incidenciaId);

            return isExisting;
        }
    }
}
