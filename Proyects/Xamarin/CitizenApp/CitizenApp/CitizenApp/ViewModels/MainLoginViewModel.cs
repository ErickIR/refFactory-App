using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class MainLoginViewModel : BaseViewModel
    {
        public Command InvitadoCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public Command LoginCommand { get; set; }



        public MainLoginViewModel()
        {
            LoginCommand = new Command(() => ExecuteLoginCommand());
            InvitadoCommand = new Command(() => ExecuteInvitadoCommand());
            RegisterCommand = new Command(() => ExecuteRegisterCommand());
        }

        async void ExecuteLoginCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }

        async void ExecuteRegisterCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterFirstPage());
        }

        private void ExecuteInvitadoCommand()
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
