using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class BarrioValidationService: IBarrioValidationService
    {
        readonly IMasterRepository masterRepository;

        public BarrioValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingBarrioId(int barrioId)
        {
            var isExisting = masterRepository.Barrio.GetAll().Any(b =>
                b.BarrioId == barrioId);

            return isExisting;
        }
    }
}
