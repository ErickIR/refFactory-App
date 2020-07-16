using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public class JuntaDeVecinos
    {
        public int JuntaDeVecinosId { get; set; }
        public int BarrioId { get; set; }
        public string Nombre { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
    }
}
