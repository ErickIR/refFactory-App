﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CitizenApp.Models;
using CitizenApp.ViewModels;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using CitizenApp.Services.Interfaces;

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
            
        }


    }
}