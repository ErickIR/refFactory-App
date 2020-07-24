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
    public partial class IntegrantesJuntaPage : ContentPage
    {
       
        IntegrantesJuntaViewModel viewModel;

        public IntegrantesJuntaPage(JuntaDeVecinos selectedJunta)
        {
            InitializeComponent();
            BindingContext = viewModel = new IntegrantesJuntaViewModel(selectedJunta);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.IntegrantesList.Count == 0)
                viewModel.IsBusy = true;
            viewModel.LoadIntegrantesCommand.Execute(true);
        }
    }
}