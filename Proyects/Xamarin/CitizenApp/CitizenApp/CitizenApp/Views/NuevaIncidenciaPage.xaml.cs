using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CitizenApp.Models;
using CitizenApp.ViewModels;

namespace CitizenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaIncidenciaPage : ContentPage
    {
        NuevaIncidenciaViewModel viewModel;
        public NuevaIncidenciaPage()
        {
            BindingContext = viewModel = new NuevaIncidenciaViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.TiposDeIncidencia.Count == 0)
                viewModel.IsBusy = true;
            viewModel.LoadTiposDeIncidenciaCommand.Execute(true);
        }
    }
}