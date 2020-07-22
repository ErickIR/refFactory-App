using CRD.AplicationCore.Interfaces.Validations;
using CRD.Domain.Interfaces;
using System.Linq;

namespace CRD.AplicationCore.Validations
{
    public class DistritoMunicipalValidationService: IDistritoMunicipalValidationService
    {
        readonly IMasterRepository masterRepository;

        public DistritoMunicipalValidationService(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public bool IsExistingDistritoMunicipalName(string nombre)
        {
            var isExisting = masterRepository.DistritoMunicipal.GetAll().Any(d =>
                d.Nombre.ToLower() == nombre.ToLower());

            return isExisting;
        }
        public bool IsExistingDistritoMunicipalId(int distritoMunicipalId)
        {
            var isExisting = masterRepository.DistritoMunicipal.GetAll().Any(d =>
                d.DistritoMunicipalId == distritoMunicipalId);

            return isExisting;
        }
        public bool IsExistingInSeccion(int distritoMunicipalId)
        {
            var isExisting = masterRepository.Seccion.GetAll().Any(s =>
                s.DistritoMunicipalId == distritoMunicipalId);

            return isExisting;
        }
    }
}
