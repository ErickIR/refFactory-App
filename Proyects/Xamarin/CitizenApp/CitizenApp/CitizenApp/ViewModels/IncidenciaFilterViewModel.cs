using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using CitizenApp.Helper;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;

namespace CitizenApp.ViewModels
{
    public class IncidenciaFilterViewModel : BaseViewModel
    {
        internal IncidenciasListViewModel ParentViewModel;
        private ClickRegulator _clickRegulator = new ClickRegulator();

        private string _search = string.Empty;
        public string Search
        {
            get { return _search; }
            set { SetProperty(ref _search, value); }
        }

        private ObservableCollection<TipoIncidencia> _tiposIncidencia;
        public ObservableCollection<TipoIncidencia> TiposIncidencia
        {
            get { return _tiposIncidencia; }
            set { SetProperty(ref _tiposIncidencia, value); }
        }

        private TipoIncidencia _tipoIncidenciaSelected;
        public TipoIncidencia TipoIncidenciaSelected
        {
            get { return _tipoIncidenciaSelected; }
            set { SetProperty(ref _tipoIncidenciaSelected, value); }
        }

        private ObservableCollection<StatusIncidencia> _statusIncidencias;
        public ObservableCollection<StatusIncidencia> StatusIncidencias
        {
            get { return _statusIncidencias; }
            set { SetProperty(ref _statusIncidencias, value); }
        }

        private StatusIncidencia _statusIncidenciaSelected;
        public StatusIncidencia StatusIncidenciaSelected
        {
            get { return _statusIncidenciaSelected; }
            set { SetProperty(ref _statusIncidenciaSelected, value); }
        }

        public ICommand LoadTiposIndenciaCommand { get; }
        public ICommand LoadStatusDeIncidenciasCommand { get; }
        public ICommand AplicarFiltrosCommand { get; }
        public ICommand ObtenerMisIncidenciasCommand { get; }
        public ICommand OrdenarMasVotadasCommand { get; }


        public IncidenciaFilterViewModel(IncidenciasListViewModel parentVm)
        {
            ParentViewModel = parentVm;
            TiposIncidencia = new ObservableCollection<TipoIncidencia>();
            StatusIncidencias = new ObservableCollection<StatusIncidencia>();
            LoadTiposIndenciaCommand = new Command(async () => await ExecuteLoadTiposIncidenciasCommand());
            LoadStatusDeIncidenciasCommand = new Command(async () => await ExecuteLoadStatusDeIncidenciasCommand());
            AplicarFiltrosCommand = new Command(async () => await ExecuteAplicarFiltrosCommand(), CanExecuteAplicarFiltrosCommand);
            ObtenerMisIncidenciasCommand = new Command(async () => await ExecuteObtenerMisIncidenciasCommand());
            OrdenarMasVotadasCommand = new Command(async () => await ExecuteOrdenarMasVotadasCommand());
        }

        async Task ExecuteOrdenarMasVotadasCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteOrdenarMasVotadasCommand), true))
                return;

            IsBusy = true;
            try
            {
                ParentViewModel.IncidenciasList.Clear();
                var incidencias = await IncidenciaService.OrdenarMasVotadas();

                foreach (var item in incidencias)
                    ParentViewModel.IncidenciasList.Add(item);

                ParentViewModel.IsFiltered = true;
                await PageService.PopAsync();
            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteOrdenarMasVotadasCommand));
                IsBusy = false;
            }
        }

        bool CanExecuteAplicarFiltrosCommand()
        {
            return true;
            //return !string.IsNullOrWhiteSpace(Search) || TipoIncidenciaSelected != null || StatusIncidenciaSelected != null;
        }

        async Task ExecuteObtenerMisIncidenciasCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteObtenerMisIncidenciasCommand), true))
                return;

            IsBusy = true;
            try
            {
                ParentViewModel.IncidenciasList.Clear();
                var incidencias = await IncidenciaService.ObtenerMisIncidenciasAsync(2);

                foreach (var item in incidencias)
                    ParentViewModel.IncidenciasList.Add(item);

                ParentViewModel.IsFiltered = true;
                await PageService.PopAsync();
            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteObtenerMisIncidenciasCommand));
                IsBusy = false;
            }

        }

        async Task ExecuteAplicarFiltrosCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteAplicarFiltrosCommand), true))
                return;

            IsBusy = true;
            try
            {
                ParentViewModel.IncidenciasList.Clear();

                var incidenciasFiltradasPorTipo = TipoIncidenciaSelected == null ?
                    (await IncidenciaService.ObtenerTodosRegistrosIncidenciaAsync()).ToList() :
                    (await IncidenciaService.ObtenerIncidenciasPorTipoAsync(TipoIncidenciaSelected.TipoIncidenciaId)).ToList();
                var incidenciasFiltradasPorEstado = StatusIncidenciaSelected == null ?
                    incidenciasFiltradasPorTipo :
                    incidenciasFiltradasPorTipo.Where(inc => inc.Status.StatusIncidenciaId == StatusIncidenciaSelected.StatusIncidenciaId).ToList();
                var incidenciasFiltradas = string.IsNullOrWhiteSpace(Search) ?
                    incidenciasFiltradasPorEstado :
                    incidenciasFiltradasPorEstado.Where(inc => inc.Titulo.Contains(Search) || inc.Descripcion.Contains(Search));
                    
                foreach (var item in incidenciasFiltradas)
                    ParentViewModel.IncidenciasList.Add(item);

                ParentViewModel.IsFiltered = true;
                await PageService.PopAsync();
            }
            catch(Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteAplicarFiltrosCommand));
                IsBusy = false;
            }
        }

        async Task ExecuteLoadTiposIncidenciasCommand()
        {
            IsBusy = true;
            try
            {
                TiposIncidencia.Clear();
                var tipos = await IncidenciaService.ObtenerTiposDeIncidencia();
                foreach (var item in tipos)
                {
                    TiposIncidencia.Add(item);
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

        async Task ExecuteLoadStatusDeIncidenciasCommand()
        {
            IsBusy = true;
            try
            {
                StatusIncidencias.Clear();
                var statuses = await IncidenciaService.ObtenerEstadosDeIncidencia();
                foreach (var item in statuses)
                {
                    StatusIncidencias.Add(item);
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
