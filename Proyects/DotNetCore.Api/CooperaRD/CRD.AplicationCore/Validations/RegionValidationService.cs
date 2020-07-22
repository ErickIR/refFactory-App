using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class RegionValidationService : IRegionValidationService
    {
        readonly IMasterRepository masterRepository;

        public RegionValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingRegionName(string nombre)
        {
            var isExisting = masterRepository.Region.GetAll().Any(r =>
                r.Nombre.ToLower() == nombre.ToLower());

            return isExisting;
        }
        public bool IsExistingRegionId(int regionId)
        {
            var isExisting = masterRepository.Region.GetAll().Any(r =>
                r.RegionId == regionId);

            return isExisting;
        }
        public bool IsExistingInProvincia(int regionId)
        {
            var isExisting = masterRepository.Provincia.GetAll().Any(p => 
                p.RegionId == regionId);

            return isExisting;
        }
    }
}
