using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class MunicipioValidationService : IMunicipioValidationService
    {
        readonly IMasterRepository masterRepository;

        public MunicipioValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingMunicipioName(string nombre)
        {
            var isExisting = masterRepository.Municipio.GetAll().Any(m =>
                m.Nombre.ToLower() == nombre.ToLower());

            return isExisting;
        }
        public bool IsExistingMunicipioId(int municipioId)
        {
            var isExisting = masterRepository.Municipio.GetAll().Any(m =>
                m.MunicipioId == municipioId);

            return isExisting;
        }
        public bool IsExistingInDistritoNacional(int municipioId)
        {
            var isExisting = masterRepository.DistritoMunicipal.GetAll().Any(d =>
                d.MunicipioId == municipioId);

            return isExisting;
        }
        public bool IsExistingInEntidadMunicipal(int municipioId)
        {
            var isExisting = masterRepository.EntidadMunicipal.GetAll().Any(e =>
                e.MunicipioId == municipioId);

            return isExisting;
        }
    }
}
