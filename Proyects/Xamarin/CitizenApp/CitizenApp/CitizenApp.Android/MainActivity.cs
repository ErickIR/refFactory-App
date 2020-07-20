using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;
using Android.Net;
using Xamarin.Forms;
using Android.Database;
using Android.Provider;
using System.IO;
using Plugin.CurrentActivity;
using Plugin.Media;
using Plugin.Permissions;

namespace CitizenApp.Droid
{
    [Activity(Label = "CooperaRD", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            await CrossMedia.Current.Initialize();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
           
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(
            int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation
                .Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
    }
}