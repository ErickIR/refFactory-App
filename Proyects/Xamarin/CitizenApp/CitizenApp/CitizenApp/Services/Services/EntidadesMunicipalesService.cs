using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Common;
using CitizenApp.Models;
using Newtonsoft.Json;

namespace CitizenApp.Services.Services
{
    public class EntidadesMunicipalesService : BaseHttpClient
    {
        List<EntidadMunicipal> EntidadesMunicipales;

        public EntidadesMunicipalesService()
        {
            EntidadesMunicipales = new List<EntidadMunicipal>();
        }

        public async Task<IEnumerable<EntidadMunicipal>> ObtenerEntidadesMunicipales()
        {
            EntidadesMunicipales.Clear();
            try
            {
                var response = await Instance.GetAsync($"entidad-municipal");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var httpResult = JsonConvert.DeserializeObject<HttpResult<IEnumerable<EntidadMunicipal>>>(content);
                    if (httpResult.ErrorCode == ResponseCode.Ok)
                    {
                        foreach (var item in httpResult.Result)
                            EntidadesMunicipales.Add(item);
                    }
                    else
                    {
                        throw new Exception(httpResult.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return EntidadesMunicipales;
        }
    }
}
