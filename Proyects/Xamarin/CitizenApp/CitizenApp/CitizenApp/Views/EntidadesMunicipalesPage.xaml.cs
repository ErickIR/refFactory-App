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
    public partial class EntidadesMunicipalesPage : ContentPage
    {
        EntidadesMunicipalesViewModel viewModel;
        public EntidadesMunicipalesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new EntidadesMunicipalesViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.EntidadesList.Count == 0)
                viewModel.IsBusy = true;
            viewModel.LoadEntidadesMunicipalesCommand.Execute(true);
        }
    }
}