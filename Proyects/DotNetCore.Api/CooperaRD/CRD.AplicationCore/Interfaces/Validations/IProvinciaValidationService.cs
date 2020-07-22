using System;
using System.Collections.Generic;
using System.Text;

namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IProvinciaValidationService
    {
        bool IsExistingProvinciaName(string nombre);
        bool IsExistingProvinciaId(int provinciaId);
        bool IsExistingInMunicipio(int provinciaId);
    }
}
