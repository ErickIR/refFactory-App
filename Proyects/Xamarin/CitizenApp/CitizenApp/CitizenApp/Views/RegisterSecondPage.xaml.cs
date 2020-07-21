using CitizenApp.Models;
using CitizenApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizenApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterSecondPage : ContentPage
    {
        RegisterSecondViewModel viewModel;
        

        

        public RegisterSecondPage(Persona persona)
        {
            
            InitializeComponent();
            BindingContext = viewModel = new RegisterSecondViewModel(persona);
            
        }

        
    }
}