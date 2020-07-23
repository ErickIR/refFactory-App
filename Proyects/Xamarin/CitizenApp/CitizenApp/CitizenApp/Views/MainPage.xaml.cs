using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CitizenApp.Common;
using Xamarin.Essentials;
using Android.Content;

namespace CitizenApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        bool session;
        public MainPage()
        {
            InitializeComponent();
            session = true;
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Inicio, (NavigationPage)Detail);
        }

        private async Task OpenNormativasMunicipalesWebPage()
        {
            Uri uri = new Uri("http://www.adn.gob.do/index.php?option=com_docman&view=list&layout=table&slug=resoluciones-municipales&Itemid=660");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Inicio:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Incidencias:
                        MenuPages.Add(id, new NavigationPage(new IncidenciasPage()));
                        break;
                    case (int)MenuItemType.JuntasDeVecinos:
                        MenuPages.Add(id, new NavigationPage(new JuntaDeVecinosPage()));
                        break;
                    case (int)MenuItemType.EntidadesMunicipales:
                        MenuPages.Add(id, new NavigationPage(new EntidadesMunicipalesPage()));
                        break;
                    case (int)MenuItemType.NormativasMunicipales:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Informacion:
                        await OpenNormativasMunicipalesWebPage();
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.CerrarSesion:
                        MasterBehavior = MasterBehavior.Popover;
                        App.Current.Logout();
                        session = false;
                        //MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            if (session)
            {
                var newPage = MenuPages[id];

                if (newPage != null && Detail != newPage)
                {
                    Detail = newPage;

                    if (Device.RuntimePlatform == Device.Android)
                        await Task.Delay(100);

                    IsPresented = false;
                }

                if (id == (int)MenuItemType.NormativasMunicipales)
                    await OpenNormativasMunicipalesWebPage();
            }
        }
    }
}