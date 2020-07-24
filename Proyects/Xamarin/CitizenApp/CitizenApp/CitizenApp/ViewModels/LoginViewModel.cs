using CitizenApp.Common;
using CitizenApp.Models;
using CitizenApp.Services;
using CitizenApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public void MakeAlter(string Titulo, string Description, string buttonText)
        {
            Application.Current.MainPage.DisplayAlert(Titulo, Description, buttonText);
        }
        private void ExecuteSignInCommand()
        {
            if (emailEntry == "fernando@reffactory.com.do" && passEntry == "123456")
            {
                MakeAlter("Informacion", "Se inicio sesion correctamente.", "OK");
                App.Current.Properties["name"] = _emailEntry;
                App.Current.Properties["IsLoggedIn"] = true;
                iml.ShowMainPage();
            }
            else 
            {
                MakeAlter("Informacion", "El usuario o contraseña es invalido.", "OK");
            }
            
            
            //Application.Current.MainPage = new MainPage();
        }

     
    }
}
