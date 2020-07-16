using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    class JuntaDeVecinos
    {
        public int JuntaDeVecinosId { get; set; }
        public int BarrioId { get; set; }
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
