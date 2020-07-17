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

            BindingContext = viewModel = new IncidenciasListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.IncidenciasList.Count == 0)
                viewModel.IsBusy = true;
            viewModel.LoadIncidenciasCommand.Execute(true);
        }


    }
}