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
            InitializeComponent();

            BindingContext = viewModel = new NuevaIncidenciaViewModel();
        }
    }
}