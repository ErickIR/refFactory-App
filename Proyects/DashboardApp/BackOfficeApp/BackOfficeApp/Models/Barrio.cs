using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Barrio
    {
        public Barrio()
        {
            Incidencia = new HashSet<Incidencia>();
            JuntaDeVecinos = new HashSet<JuntaDeVecinos>();
            Usuario = new HashSet<Usuario>();
        }

        public int BarrioId { get; set; }
        public int SectorId { get; set; }
        public string Nombre { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual ICollection<Incidencia> Incidencia { get; set; }
        public virtual ICollection<JuntaDeVecinos> JuntaDeVecinos { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
