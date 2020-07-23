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
    public partial class RegisterThirdPage : ContentPage
    {
        
        RegisterThirdViewModel viewModel;

       
        public RegisterThirdPage(Usuario usuario)
        {
            InitializeComponent();
            
            BindingContext = viewModel = new RegisterThirdViewModel(usuario);
        }
    }
}