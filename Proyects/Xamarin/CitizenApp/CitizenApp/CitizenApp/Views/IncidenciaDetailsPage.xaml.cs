﻿using CitizenApp.Models;
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
    public partial class IncidenciaDetailsPage : ContentPage
    {
        public IncidenciaDetailsPage(Incidencia incidencia)
        {
            InitializeComponent();
        }
    }
}