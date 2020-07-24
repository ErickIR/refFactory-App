using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.Models
{
    public class JuntaDeVecinos
    {
        public int JuntaDeVecinosId { get; set; }
        public Barrio Barrio { get; set; }
        public int BarrioId { get; set; }
        public string Nombre { get; set; }
    }
}
