
namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IRegionValidationService
    {
        bool IsExistingRegionName(string nombre);
        bool IsExistingRegionId(int regionId);
        bool IsExistingInProvincia(int regionId);

    }
}
