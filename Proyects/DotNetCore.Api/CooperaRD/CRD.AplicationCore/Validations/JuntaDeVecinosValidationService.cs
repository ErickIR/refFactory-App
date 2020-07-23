using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class JuntaDeVecinosValidationService: IJuntaDeVecinosValidationService
    {
        readonly IMasterRepository masterRepository;

        public JuntaDeVecinosValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingJuntaDeVecinosId(int juntaDeVecinosId)
        {
            var isExisting = masterRepository.JuntaDeVecinos.GetAll().Any(j =>
                j.JuntaDeVecinosId == juntaDeVecinosId);

            return isExisting;
        }
    }
}
