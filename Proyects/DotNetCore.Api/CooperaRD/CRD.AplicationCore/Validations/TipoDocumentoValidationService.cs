using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class TipoDocumentoValidationService: ITipoDocumentoValidationService
    {
        readonly IMasterRepository masterRepository;

        public TipoDocumentoValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingTipoDocumentoId(int tipoDocumentoId)
        {
            var isExisting = masterRepository.TipoDocumento.GetAll().Any(t =>
                t.TipoDocumentoId == tipoDocumentoId);

            return isExisting;
        }
    }
}
