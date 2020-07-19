using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CitizenApp.Models;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class NuevaIncidenciaViewModel : BaseViewModel
    {
        public Incidencia Incidencia { get; set; }
        public TipoIncidencia TipoIncidenciaSelected { get; set; }

        public ObservableCollection<TipoIncidencia> TiposDeIncidencia { get; set; }

        public ICommand SaveIncidenciaCommand { get; set; }
        public ICommand LoadTiposDeIncidenciaCommand { get; set; }
        public double PageWidth
        {
            get
            {
                return Application.Current.MainPage.Width - 10;
            }
        }

        public double PageHeight
        {
            get
            {
                return Application.Current.MainPage.Height - 10;
            }
        }

        public NuevaIncidenciaViewModel()
        {
            Title = "Registrar Incidencia";

            Incidencia = new Incidencia();
            TiposDeIncidencia = new ObservableCollection<TipoIncidencia>();
            LoadTiposDeIncidenciaCommand = new Command(async () => await ExecuteLoadTiposDeIncidenciCommand());
        }

        private async Task ExecuteLoadTiposDeIncidenciCommand()
        {
            IsBusy = true;

            try
            {
                TiposDeIncidencia.Clear();
                var tipos = await IncidenciaService.ObtenerTiposDeIncidencia();
                foreach (var item in tipos)
                {
                    TiposDeIncidencia.Add(item);
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
