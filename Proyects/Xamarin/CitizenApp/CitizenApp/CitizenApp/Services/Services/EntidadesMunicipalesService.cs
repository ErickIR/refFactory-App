using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Models;

namespace CitizenApp.Services.Services
{
    public class EntidadesMunicipalesService : BaseHttpClient
    {
        List<EntidadMunicipal> EntidadesMunicipales;

        public EntidadesMunicipalesService()
        {
            EntidadesMunicipales = new List<EntidadMunicipal>();
        }

        public async Task<IEnumerable<EntidadMunicipal>> ObtenerEntidadesMunicipales(int municipioId)
        {
            throw await Task.FromResult(new NotImplementedException());
        }
    }
}
