using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }
        [JsonProperty("Descripccion")]
        public string Descripcion { get; set; }
    }
}
