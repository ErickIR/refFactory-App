using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class SeccionValidationService: ISeccionValidationService
    {
        readonly IMasterRepository masterRepository;

        public SeccionValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingSeccionId(int seccionId)
        {
            var isExisting = masterRepository.Seccion.GetAll().Any(s =>
                s.SeccionId == seccionId);

            return isExisting;
        }
    }
}
