

namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IGeneralValidationService
    {
        bool IsEmptyText(string text);
        string GetRewrittenTextFirstCapitalLetter(string text);
    }
}
