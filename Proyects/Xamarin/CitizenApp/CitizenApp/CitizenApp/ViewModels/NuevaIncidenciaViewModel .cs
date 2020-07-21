using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CitizenApp.Helper;
using CitizenApp.Models;
using CitizenApp.Services.Interfaces;
using CitizenApp.Views;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class NuevaIncidenciaViewModel : BaseViewModel
    {
        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();
        private string _titulo = string.Empty;
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private TipoIncidencia _tipoIncidenciaSelected = new TipoIncidencia();
        public TipoIncidencia TipoIncidenciaSelected
        {
            get => _tipoIncidenciaSelected;
            set => SetProperty(ref _tipoIncidenciaSelected, value);
        }

        private byte[] _imagenArray;

        private string _descripcion = string.Empty;
        public string Descripcion
        {
            get => _descripcion;
            set => SetProperty(ref _descripcion, value);
        }

        private string _tituloImagen = string.Empty;
        public string TituloImagen
        {
            get => _tituloImagen;
            set => SetProperty(ref _tituloImagen, value);
        }

        private ImageSource _imageSrc;
        public ImageSource ImageSrc
        {
            get => _imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }

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

            TiposDeIncidencia = new ObservableCollection<TipoIncidencia>();
            LoadTiposDeIncidenciaCommand = new Command(async () => await ExecuteLoadTiposDeIncidenciCommand());
            TakePictureCommand = new Command(async () => await ExecuteTakePictureCommand());
            SaveIncidenciaCommand = new Command(async () => await ExecuteSaveIncidenciasComman(), CanSave);

            Task.Run(async () => await ExecuteLoadTiposDeIncidenciCommand());
        }

        bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Titulo) || !TipoIncidenciaSelected.Equals(null) || !string.IsNullOrWhiteSpace(Descripcion);
        }

        private async Task ExecuteSaveIncidenciasComman()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteSaveIncidenciasComman), true))
                return;

            IsBusy = true;
            try
            {
                var Incidencia = new Incidencia()
                {
                    Empleado = new Usuario() { UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com" },
                    Usuario = new Usuario() { UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com" },
                    TipoIncidencia = TipoIncidenciaSelected,
                    Barrio = new Barrio() { BarrioId = 1, Nombre = "El Regina" },
                    Imagen = _imagenArray,
                    TituloImagen = TituloImagen,
                    Titulo = Titulo,
                    Descripcion = Descripcion
                };
                await IncidenciaService.RegistrarNuevaIncidenciaAsync(Incidencia);
                await PageService.PopAsync();
            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteSaveIncidenciasComman));
                IsBusy = false;
            }
            
        }

        private async Task ExecuteTakePictureCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteTakePictureCommand), true))
                return ;

            IsBusy = true;
            try
            {
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
                    var  imageName = $"{TipoIncidenciaSelected.Descripcion}_{Guid.NewGuid().ToString()}.jpg";
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Name = imageName,
                        PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                    });

                    if (file == null)
                        return;

                    ImageSrc = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });

                    using (var memoryStream = new MemoryStream())
                    {
                        file.GetStream().CopyTo(memoryStream);
                        file.Dispose();
                        _imagenArray = memoryStream.ToArray();
                    }
                    TituloImagen = imageName;
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
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteTakePictureCommand));
                IsBusy = false;
            }
        }

        private async Task ExecuteLoadTiposDeIncidenciCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteLoadTiposDeIncidenciCommand), true))
                return;

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
                _clickRegulator.ClickDone(nameof(ExecuteLoadTiposDeIncidenciCommand));
                IsBusy = false;
            }
        }
    }
}
