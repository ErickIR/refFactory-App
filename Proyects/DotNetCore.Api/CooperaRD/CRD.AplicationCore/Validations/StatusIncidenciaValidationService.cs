using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class StatusIncidenciaValidationService: IStatusIncidenciaValidationService
    {
        readonly IMasterRepository masterRepository;

        public StatusIncidenciaValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingStatusIncidenciaId(int statusIncidenciaId)
        {
            var isExisting = masterRepository.StatusIncidencia.GetAll().Any(s =>
                s.StatusIncidenciaId == statusIncidenciaId);

            return isExisting;
        }
    }
}
