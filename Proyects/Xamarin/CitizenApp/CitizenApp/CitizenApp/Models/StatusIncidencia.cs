using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class StatusIncidencia
    {
        [JsonProperty("statusIncidenciaId")]
        public int StatusIncidenciaId { get; set; }
        [JsonProperty("descripccion")]
        public string Descripcion { get; set; }
    }
}
