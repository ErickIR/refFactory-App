using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class JuntaDeVecinos
    {
        public JuntaDeVecinos()
        {
            IntegranteJdV = new HashSet<IntegranteJdV>();
        }

        public int JuntaDeVecinosId { get; set; }
        public int BarrioId { get; set; }
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public virtual Barrio Barrio { get; set; }
        public virtual ICollection<IntegranteJdV> IntegranteJdV { get; set; }
    }
}
