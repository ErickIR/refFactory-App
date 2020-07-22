using System;
using System.Collections.Generic;
using System.Text;

namespace CRD.AplicationCore.Interfaces.Validations
{
    public interface IMunicipioValidationService
    {
        bool IsExistingMunicipioName(string nombre);
        bool IsExistingMunicipioId(int municipioId);
        bool IsExistingInDistritoNacional(int municipioId);
        bool IsExistingInEntidadMunicipal(int municipioId);
    }
}
