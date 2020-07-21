using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command SignInCommand { get; set; }
        public LoginViewModel()
        {
            SignInCommand = new Command(() => ExecuteSignInCommand());
        }

        private void ExecuteSignInCommand()
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
