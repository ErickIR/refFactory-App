using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CitizenApp.Droid.NativeServices;
using CitizenApp.Services.Interfaces;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MediaService))]
namespace CitizenApp.Droid.NativeServices
{
    public class MediaService : Java.Lang.Object, IMediaService
    {
        public static readonly int OPENGALLERYCODE = 100;
        void IMediaService.ClearFileDirectory()
        {
            var directory = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), ImageHelper.collectionName).Path.ToString();

            if (Directory.Exists(directory))
            {
                var list = Directory.GetFiles(directory, "*");
                if (list.Length > 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        File.Delete(list[i]);
                    }
                }
            }
            
        }

        public void OpenGallery()
        {
            try
            {
                var imageIntent = new Intent(Intent.ActionPick);
                imageIntent.SetType("image/*");
                imageIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                imageIntent.SetAction(Intent.ActionGetContent);
                ((Activity)Forms.Context).StartActivityForResult(Intent.CreateChooser(imageIntent, "Seleccionar Imagenes."), OPENGALLERYCODE);
                Toast.MakeText(Xamarin.Forms.Forms.Context, "Presione y mantenga para seleccionar multiples imagenes.", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.MakeText(Xamarin.Forms.Forms.Context, "Error. Intente de nuevo.", ToastLength.Long).Show();
            }
        }
    }
}