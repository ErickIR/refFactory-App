using CitizenApp.Helper;
using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class IncidenciaDetailsViewModel : BaseViewModel
    {
        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();

        private Incidencia _incidencia;
        public Incidencia Incidencia
        {
            get { return _incidencia; }
            set { SetProperty(ref _incidencia, value); }
        }

        private ImageSource _imageSrc;
        public ImageSource ImageSrc
        {
            get { return _imageSrc; }
            set { SetProperty(ref _imageSrc, value); }
        }
        
        public ICommand ApoyarIncidenciaCommand { get; }

        public IncidenciaDetailsViewModel(Incidencia incidencia)
        {
            Title = incidencia.Titulo;
            Incidencia = incidencia;

            //using(var stream = new MemoryStream(incidencia.Imagen))
            //    ImageSrc = ImageSource.FromStream(() => stream);

            ImageSrc = ImageSource.FromUri(new Uri("https://picsum.photos/300"));
            ApoyarIncidenciaCommand = new Command(async () => await ExecuteApoyarIncidenciaCommand());
        }

        async Task ExecuteApoyarIncidenciaCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteApoyarIncidenciaCommand), true))
                return;

            IsBusy = true;

            try
            {
                await IncidenciaService.RegistrarNuevoApoyoIncidenciaAsync(
                    Incidencia,
                    new Usuario() { UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com" }
                    );
                Incidencia = await IncidenciaService.ObtenerRegistroIncidenciaPorIdAsync(Incidencia.IncidenciaId);
            }
            catch(Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteApoyarIncidenciaCommand));
                IsBusy = false;
            }

        }

    }
}
