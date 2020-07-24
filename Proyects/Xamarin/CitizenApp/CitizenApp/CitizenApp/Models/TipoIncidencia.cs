using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class TipoIncidencia
    {
        [JsonProperty("tipoIncidenciaId")]
        public int TipoIncidenciaId { get; set; }
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
    }
}
