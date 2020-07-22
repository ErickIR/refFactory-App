using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class CargoValidationService: ICargoValidationService
    {
        readonly IMasterRepository masterRepository;

        public CargoValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingCargoId(int cargoId)
        {
            var isExisting = masterRepository.Cargo.GetAll().Any(c =>
                c.CargoId == cargoId);

            return isExisting;
        }
    }
}