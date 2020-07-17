using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizenApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> mainMenuItems;
        public MenuPage()
        {
            InitializeComponent();

            mainMenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Inicio, Title="Inicio" },
                new HomeMenuItem {Id = MenuItemType.Incidencias, Title="Incidencias" },
                new HomeMenuItem {Id = MenuItemType.JuntasDeVecinos, Title="Juntas de Vecinos" },
                new HomeMenuItem {Id = MenuItemType.EntidadesMunicipales, Title="Entidades Municipales" },
                new HomeMenuItem {Id = MenuItemType.NormativasMunicipales, Title="Normativas Municipales" },
                new HomeMenuItem {Id = MenuItemType.Informacion, Title="Informacion" },
                new HomeMenuItem {Id = MenuItemType.CerrarSesion, Title="Cerrar Sesion" }
            };

            ListViewMenu.ItemsSource = mainMenuItems;

            ListViewMenu.SelectedItem = mainMenuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

        }
    }
}