using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class IntegranteJdVValidationService: IIntegranteJdVValidationService
    {
        readonly IMasterRepository masterRepository;

        public IntegranteJdVValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingIntegranteId(int integranteId)
        {
            var isExisting = masterRepository.IntegranteJdV.GetAll().Any(i => 
            i.IntegranteId == integranteId);

            return isExisting;
        }
    }
}
