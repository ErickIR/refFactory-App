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
        public ObservableCollection<Incidencia> IncidenciasList { get; set; }
        public Incidencia SelectedIncidencia { get; set; }

        public Command LoadIncidenciasCommand { get; set; }
        public Command SelectIncidenciaCommand { get; set; }
        public Command AddNewIncidenciaCommand { get; set; }
        public Command SearchIncidenciaCommand { get; set; }

        public string Search { get; set; }

        public IncidenciasListViewModel()
        {
            Title = "Incidencias";
            Search = "";
            IncidenciasList = new ObservableCollection<Incidencia>();

            LoadIncidenciasCommand = new Command(async () => await ExecuteLoadIncidenciasCommand());
            SearchIncidenciaCommand = new Command(async () => await ExecuteSearchIncidenciasCommand());
        }

        async Task ExecuteSearchIncidenciasCommand()
        {
            IsBusy = true;

            try
            {
                IncidenciasList.Clear();
                var incidencias = await IncidenciaService.ObtenerIncidenciasPorPalabraAsync(this.Search);
                foreach (var item in incidencias)
                {
                    IncidenciasList.Add(item);
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

        async Task ExecuteLoadIncidenciasCommand()
        {
            IsBusy = true;

            try
            {
                IncidenciasList.Clear();
                var incidencias = await IncidenciaService.ObtenerTodosRegistrosIncidenciaAsync();
                foreach (var item in incidencias)
                {
                    IncidenciasList.Add(item);
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
