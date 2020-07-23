using CitizenApp.Common;
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
    public partial class MainLoginPage : ContentPage
    {
        MainLoginViewModel viewModel;
       

        public MainLoginPage(ILoginManager ilm)
        {
           
            InitializeComponent();
            BindingContext = viewModel = new MainLoginViewModel(ilm);
        }

       
    }
}