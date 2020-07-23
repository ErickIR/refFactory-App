using CitizenApp.Models;
using CitizenApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncidenciasFilterPage : ContentPage
    {
        IncidenciaFilterViewModel viewModel;

        public IncidenciasFilterPage(IncidenciasListViewModel parentViewModel)
        {
            BindingContext = viewModel = new IncidenciaFilterViewModel(parentViewModel);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            IsBusy = true;
            viewModel.LoadTiposIndenciaCommand.Execute(true);
            viewModel.LoadStatusDeIncidenciasCommand.Execute(true);

        }
    }
}