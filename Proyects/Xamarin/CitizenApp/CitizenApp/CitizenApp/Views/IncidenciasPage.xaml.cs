using CitizenApp.Models;
using CitizenApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidenciasPage : ContentPage
    {
        IncidenciasListViewModel viewModel;
        

        public IncidenciasPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new IncidenciasListViewModel(Navigation);
            
        }

        

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!viewModel.IsFiltered)
            {
                viewModel.IsBusy = true;
                viewModel.LoadIncidenciasCommand.Execute(true);
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null &&
                viewModel.SelectIncidenciaCommand != null &&
                viewModel.SelectIncidenciaCommand.CanExecute(e))
            {
                viewModel.SelectIncidenciaCommand.Execute(true);
            }
              
        }
    }
}