using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class TipoIncidenciaValidationService: ITipoIncidenciaValidationService
    {
        readonly IMasterRepository masterRepository;

        public TipoIncidenciaValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingTipoIncidenciaId(int tipoIncidenciaId)
        {
            var isExisting = masterRepository.TipoIncidencia.GetAll().Any(t => 
                t.TipoIncidenciaId == tipoIncidenciaId);

            return isExisting;
        }
    }
}
