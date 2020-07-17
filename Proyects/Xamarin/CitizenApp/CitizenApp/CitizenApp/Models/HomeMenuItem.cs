using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Models
{
    public enum MenuItemType
    {
        Inicio,
        Incidencias,
        EntidadesMunicipales,
        JuntasDeVecinos,
        NormativasMunicipales,
        Informacion,
        CerrarSesion
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }
    }
}
