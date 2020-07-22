using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class ProvinciaValidationService : IProvinciaValidationService
    {
        readonly IMasterRepository masterRepository;

        public ProvinciaValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingProvinciaName(string nombre)
        {
            var isExisting = masterRepository.Provincia.GetAll().Any(p =>
                p.Nombre.ToLower() == nombre.ToLower());

            return isExisting;
        }
        public bool IsExistingProvinciaId(int provinciaId)
        {
            var isExisting = masterRepository.Provincia.GetAll().Any(p =>
                p.ProvinciaId == provinciaId);

            return isExisting;
        }
        public bool IsExistingInMunicipio(int provinciaId)
        {
            var isExisting = masterRepository.Municipio.GetAll().Any(m =>
                m.ProvinciaId == provinciaId);

            return isExisting;
        }
    }
}
