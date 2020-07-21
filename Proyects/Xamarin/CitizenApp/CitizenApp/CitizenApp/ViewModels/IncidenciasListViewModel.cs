using CitizenApp.Helper;
using CitizenApp.Models;
using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class IncidenciasListViewModel : BaseViewModel
    {
        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();
        private ObservableCollection<Incidencia> _incidenciasList = new ObservableCollection<Incidencia>();
        public ObservableCollection<Incidencia> IncidenciasList
        {
            get { return _incidenciasList; }
            set { SetProperty(ref _incidenciasList, value); }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }


        Incidencia _selectedIncidencia;
        public Incidencia SelectedIncidencia
        {
            get { return _selectedIncidencia; }
            set { SetProperty(ref _selectedIncidencia, value); }
        }

        public ICommand LoadIncidenciasCommand { get; }
        public ICommand SelectIncidenciaCommand { get; }
        public ICommand AddNewIncidenciaCommand { get; }
        public ICommand SearchIncidenciaCommand { get; }

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
            AddNewIncidenciaCommand = new Command(async () => await ExecuteAddNewIncidenciaCommand());
            SelectIncidenciaCommand = new Command(async () => await ExecuteSelectIncidenciaCommand());
        }

        async Task ExecuteSelectIncidenciaCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteSelectIncidenciaCommand), true))
                return;

            try
            {
                await PageService.PushAsync(new IncidenciaDetailsPage(SelectedIncidencia));
            }
            catch(Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteSelectIncidenciaCommand));
                SelectedIncidencia = null;
            }
        }
        
        async Task ExecuteAddNewIncidenciaCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteAddNewIncidenciaCommand), true))
                return;

            try
            {
                await PageService.PushAsync(new NuevaIncidenciaPage());
            } 
            catch (Exception e)
            {
                await PageService.DisplayAlert("ERROR", e.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteAddNewIncidenciaCommand));
            }
        }

        async Task ExecuteSearchIncidenciasCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteSearchIncidenciasCommand), true))
                return;
            IsBusy = true;
            IsRefreshing = true;
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
                _clickRegulator.ClickDone(nameof(ExecuteSearchIncidenciasCommand));
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        async Task ExecuteLoadIncidenciasCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteLoadIncidenciasCommand), true))
                return;
            IsBusy = true;
            IsRefreshing = true;
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
                _clickRegulator.ClickDone(nameof(ExecuteLoadIncidenciasCommand));
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
