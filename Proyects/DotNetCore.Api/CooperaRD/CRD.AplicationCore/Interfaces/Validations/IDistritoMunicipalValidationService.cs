
namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IDistritoMunicipalValidationService
    {
        bool IsExistingDistritoMunicipalName(string nombre);
        bool IsExistingDistritoMunicipalId(int distritoMunicipalId);
        bool IsExistingInSeccion(int distritoMunicipalId);
    }
}
