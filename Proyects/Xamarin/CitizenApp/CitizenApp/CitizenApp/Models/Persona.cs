using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class Persona
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string Ocupacion { get; set; }
        public string Region { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string DistritoMunicipal { get; set; }
        public string Seccion { get; set; }
        public string Sector { get; set; }
        public string Barrio { get; set; }
    }
}
