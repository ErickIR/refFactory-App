using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class IncidenciaDetailsViewModel : BaseViewModel
    {
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

        public IncidenciaDetailsViewModel(Incidencia incidencia)
        {
            Title = incidencia.Titulo;
            Incidencia = incidencia;

            //using(var stream = new MemoryStream(incidencia.Imagen))
            //    ImageSrc = ImageSource.FromStream(() => stream);

            ImageSrc = ImageSource.FromUri(new Uri("https://picsum.photos/300"));    
        }

    }
}
