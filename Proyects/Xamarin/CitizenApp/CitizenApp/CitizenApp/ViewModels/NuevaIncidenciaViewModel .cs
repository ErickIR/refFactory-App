using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CitizenApp.Models;
namespace CitizenApp.ViewModels
{
    public class NuevaIncidenciaViewModel : BaseViewModel
    {
        public Incidencia Incidencia { get; set; }

        public ICommand SaveIncidenciaCommand { get; set; }

        public NuevaIncidenciaViewModel()
        {
            Incidencia = new Incidencia();

            
        }
    }
}
