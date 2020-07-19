using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CitizenApp.Models;
using CitizenApp.Services.Interfaces;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class NuevaIncidenciaViewModel : BaseViewModel
    {
        public Incidencia Incidencia { get; set; }
        public TipoIncidencia TipoIncidenciaSelected { get; set; }

        public ObservableCollection<TipoIncidencia> TiposDeIncidencia { get; set; }
        public ObservableCollection<string> Images { get; set; }

        //public ICommand SelectImagesCommand { get; set; }
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
            Images = new ObservableCollection<string>();
            LoadTiposDeIncidenciaCommand = new Command(async () => await ExecuteLoadTiposDeIncidenciCommand());
            //SelectImagesCommand = new Command(async () => await ExecuteSelectImagesCommand());
        }

        //private async Task ExecuteSelectImagesCommand()
        //{
        //    //Check users permissions.
        //    var storagePermissions = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //    var photoPermissions = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);
        //    if (storagePermissions == PermissionStatus.Granted && photoPermissions == PermissionStatus.Granted)
        //    {

        //        if (Device.RuntimePlatform == Device.Android)
        //        {
        //            DependencyService.Get<IMediaService>().OpenGallery();

        //            MessagingCenter.Unsubscribe<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelectedAndroid");
        //            MessagingCenter.Subscribe<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelectedAndroid", (s, images) =>
        //            {
        //                //If we have selected images, put them into the carousel view.
        //                if (images.Count > 0)
        //                {
        //                    foreach(var img in images)
        //                        Images.Add(img);
        //                }
        //            });
        //        }
        //    }
        //    else
        //    {
        //        await PageService.DisplayAlert("Permisos denegados.", "\nPlease go to your app settings and enable permissions.", "Ok");
        //    }
        //}

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
