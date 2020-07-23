using CitizenApp.Common;
using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        ILoginManager iml = null;

        private string _emailEntry = "";
        public string emailEntry
        {
            get { return _emailEntry; }
            set { SetProperty(ref _emailEntry, value); }
        }

        private string _passEntry = "";
        public string passEntry
        {
            get { return _passEntry; }
            set { SetProperty(ref _passEntry, value); }
        }

        private string _errorMessage = "";
        public string errorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }


        private bool _errorisVisible = false;
        public bool errorisVisible
        {
            get { return _errorisVisible; }
            set { SetProperty(ref _errorisVisible, value); }
        }

        public Command SignInCommand { get; set; }
        public LoginViewModel(ILoginManager ilm)
        {
            SignInCommand = new Command(() => ExecuteSignInCommand());
            iml = ilm;
        }

        private void ExecuteSignInCommand()
        {

            App.Current.Properties["name"] = _emailEntry;
            App.Current.Properties["IsLoggedIn"] = true;
            iml.ShowMainPage();
            //Application.Current.MainPage = new MainPage();
        }
    }
}
