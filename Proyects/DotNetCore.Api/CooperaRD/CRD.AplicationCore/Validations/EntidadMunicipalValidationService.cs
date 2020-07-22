using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class EntidadMunicipalValidationService: IEntidadMunicipalValidationService
    {
        readonly IMasterRepository masterRepository;

        public EntidadMunicipalValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingEntidadMunicipalId( int entidadMunicipalId)
        {
            var isExisting = masterRepository.EntidadMunicipal.GetAll().Any(e =>
                e.EntidadMunicipalId == entidadMunicipalId);

            return isExisting;
        }
    }
}
