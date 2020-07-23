using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CitizenApp.Services;
using CitizenApp.Views;
using CitizenApp.Common;

namespace CitizenApp
{
    public partial class App : Application, ILoginManager
    {
        static ILoginManager loginManager;
        public static App Current;
        public static int val;

        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] { "SwipeView_Experimental" });
            Current = this;
            var isLoggedIn = Properties.ContainsKey("IsLoggedIn") && (bool)Properties["IsLoggedIn"];
            if (isLoggedIn)
                MainPage = new MainPage();
            else
                MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void ShowMainPage()
        {
            MainPage = new MainPage();
        }

        public void Logout()
        {
            Properties["IsLoggedIn"] = false;
            MainPage = new LoginModalPage(this);
        }
    }
}
