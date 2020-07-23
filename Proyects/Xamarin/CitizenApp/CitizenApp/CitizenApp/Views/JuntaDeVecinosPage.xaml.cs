
using CitizenApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JuntaDeVecinosPage : ContentPage
    {
        JuntadeVecinosViewModel viewModel;
        public JuntaDeVecinosPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new JuntadeVecinosViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.JuntadeVecinosList.Count == 0)
                viewModel.IsBusy = true;
            viewModel.LoadJuntasCommand.Execute(true);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (e.SelectedItem != null &&
            //    viewModel.SelectIncidenciaCommand != null &&
            //    viewModel.SelectIncidenciaCommand.CanExecute(e))
            //{
            //    viewModel.SelectIncidenciaCommand.Execute(true);
            //}

        }

    }
}
