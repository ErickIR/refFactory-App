using CitizenApp.Models;
using CitizenApp.Views;
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
        private ObservableCollection<Incidencia> _incidenciasList = new ObservableCollection<Incidencia>();
        public ObservableCollection<Incidencia> IncidenciasList
        {
            get { return _incidenciasList; }
            set { SetProperty(ref _incidenciasList, value); }
        }
        public Incidencia SelectedIncidencia { get; set; }

        public Command LoadIncidenciasCommand { get; set; }
        public Command SelectIncidenciaCommand { get; set; }
        public Command AddNewIncidenciaCommand { get; set; }
        public Command SearchIncidenciaCommand { get; set; }

        public INavigation Navigation { get; set; }
        public string Search { get; set; }

        public IncidenciasListViewModel(INavigation navigation)
        {
            Title = "Incidencias";
            Search = "";
            _incidenciasList = new ObservableCollection<Incidencia>();
            Navigation = navigation;

            LoadIncidenciasCommand = new Command(async () => await ExecuteLoadIncidenciasCommand());
            SearchIncidenciaCommand = new Command(async () => await ExecuteSearchIncidenciasCommand());
            AddNewIncidenciaCommand = new Command(async () => await Navigation.PushAsync(new NuevaIncidenciaPage()));
        }


        async Task ExecuteSearchIncidenciasCommand()
        {
            IsBusy = true;

            try
            {
                _incidenciasList.Clear();
                var incidencias = await IncidenciaService.ObtenerIncidenciasPorPalabraAsync(this.Search);
                foreach (var item in incidencias)
                {
                    _incidenciasList.Add(item);
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
                _incidenciasList.Clear();
                var incidencias = await IncidenciaService.ObtenerTodosRegistrosIncidenciaAsync();
                foreach (var item in incidencias)
                {
                    _incidenciasList.Add(item);
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
