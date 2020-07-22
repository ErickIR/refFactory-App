using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class SectorValidationService: ISectorValidationService
    {
        readonly IMasterRepository masterRepository;

        public SectorValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository; 
        }

        public bool IsExistingSectorId(int sectorId)
        {
            var isExisting = masterRepository.Sector.GetAll().Any(s =>
                s.SectorId == sectorId);

            return isExisting;
        }
    }
}
