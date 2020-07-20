using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CitizenApp.Models;
using CitizenApp.Services.Interfaces;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class NuevaIncidenciaViewModel : BaseViewModel
    {
        public Incidencia Incidencia { get; set; }
        public TipoIncidencia TipoIncidenciaSelected { get; set; }

        public Archivo ImageFile { get; set; }

        public ObservableCollection<TipoIncidencia> TiposDeIncidencia { get; set; }
       
        public ICommand SaveIncidenciaCommand { get; set; }
        public ICommand LoadTiposDeIncidenciaCommand { get; set; }
        public ICommand TakePictureCommand { get; set; }

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
            ImageFile = new Archivo();
            LoadTiposDeIncidenciaCommand = new Command(async () => await ExecuteLoadTiposDeIncidenciCommand());
            TakePictureCommand = new Command(async () => await ExecuteTakePictureCommand());
        }
        
        private async Task ExecuteTakePictureCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Incidencia.Titulo))
                    throw new Exception("Debe asignar un titulo a la incidencia.");

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await PageService.DisplayAlert("No Camera", "No hay camaras disponibles.", "OK");
                    return;
                }

                var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

                if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                    cameraStatus = results[Permission.Camera];
                    storageStatus = results[Permission.Storage];
                }

                if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
                {
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Name = Incidencia.Titulo == null ? "Imagen Incidencia.jpg" : $"{Incidencia.Titulo}.jpg"
                    });

                    if (file == null)
                        return;

                    
                    
                    await PageService.DisplayAlert("File Location: ", file.AlbumPath, "OK");

                    var ImageSrc = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });


                    using (var memoryStream = new MemoryStream())
                    {
                        file.GetStream().CopyTo(memoryStream);
                        file.Dispose();
                        ImageFile.Fichero = memoryStream.ToArray();
                    }
                    ImageFile.Nombre = Incidencia.Titulo == null ? "Imagen Incidencia.jpg" : $"{Incidencia.Titulo}.jpg";
                }
                else
                {
                    await PageService.DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                }

            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }




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
