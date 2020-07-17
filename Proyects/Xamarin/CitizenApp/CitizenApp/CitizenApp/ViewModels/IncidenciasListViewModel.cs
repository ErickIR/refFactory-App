using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class IncidenciasListViewModel : BaseViewModel
    {
        public ObservableCollection<Incidencia> Incidencias { get; set; }
        public Incidencia SelectedIncidencia { get; set; }

        public Command LoadIncidenciasCommand { get; set; }
        public Command SelectIncidenciaCommand { get; set; }
        public Command AddNewIncidenciaCommand { get; set; }

        public IncidenciasListViewModel()
        {
            Title = "Incidencias";

            Incidencias = new ObservableCollection<Incidencia>();

            LoadIncidenciasCommand = new Command(async () => await ExecuteLoadIncidenciasCommand());
        }

        async Task ExecuteLoadIncidenciasCommand()
        {
            IsBusy = true;

            try
            {
                Incidencias.Clear();
                var weapons = await IncidenciaService.ObtenerTodosRegistrosIncidenciaAsync();
                foreach (var item in weapons)
                {
                    Incidencias.Add(item);
                }
            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("Error Message", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
