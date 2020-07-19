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

    public class HomeMenuGroup : List<HomeMenuItem>
    {
        public string GroupName { get; private set; }

        private HomeMenuGroup(string name)
        {
            GroupName = name;
        }

        static HomeMenuGroup()
        {
            
            List<HomeMenuGroup> Groups = new List<HomeMenuGroup>
            {
                new HomeMenuGroup("Principal")
                {
                    new HomeMenuItem {Id = MenuItemType.Inicio, Title="Inicio", Icon = "Inicio" },
                    new HomeMenuItem {Id = MenuItemType.Incidencias, Title="Incidencias", Icon = "Incidencias" },
                    new HomeMenuItem {Id = MenuItemType.JuntasDeVecinos, Title="Juntas de Vecinos", Icon = "Juntas_de_Vecinos" },
                    new HomeMenuItem {Id = MenuItemType.EntidadesMunicipales, Title="Entidades Municipales", Icon = "Entidades_Municipales"  },
                    new HomeMenuItem {Id = MenuItemType.NormativasMunicipales, Title="Normativas Municipales", Icon = "Normativas_Municipales"  }
                },
                new HomeMenuGroup("Usuario")
                {
                    new HomeMenuItem {Id = MenuItemType.Informacion, Title="Informacion", Icon = "Informacion" },
                    new HomeMenuItem {Id = MenuItemType.CerrarSesion, Title="Cerrar Sesion", Icon = "Cerrar_Sesion" }
                }
            };

            All = Groups;
        }

        public static IList<HomeMenuGroup> All { get; private set; }
    }
}
