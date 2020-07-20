using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class RegisterFirstViewModel : BaseViewModel
    {
        public Command ContinuarCommand { get; set; }

        public RegisterFirstViewModel()
        {
            ContinuarCommand = new Command(() => ExecuteContinuarCommand());
        }

        async void ExecuteContinuarCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterSecondPage());
        }
    }
}
