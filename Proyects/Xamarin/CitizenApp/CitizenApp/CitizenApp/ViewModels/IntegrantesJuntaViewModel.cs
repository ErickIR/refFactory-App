using CitizenApp.Helper;
using CitizenApp.Models;
using CitizenApp.Services.DataStores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class IntegrantesJuntaViewModel : BaseViewModel
    {
        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();
        private ObservableCollection<IntegranteJdV> _integrantesList;
        private JuntaDeVecinos selectedJunta;

       
        

        public ObservableCollection<IntegranteJdV> IntegrantesList
        {
            get { return _integrantesList; }
            set { SetProperty(ref _integrantesList, value); }

        }

        public Command LoadIntegrantesCommand { get; }

        public IntegrantesJuntaViewModel(JuntaDeVecinos selectedJunta)
        {
            _integrantesList = new ObservableCollection<IntegranteJdV>();
            this.selectedJunta = selectedJunta;
            LoadIntegrantesCommand = new Command(async () => await ExecuteLoadIntegrantesCommand());
        }

        private async Task ExecuteLoadIntegrantesCommand()
        {
            if (_clickRegulator.SetClicked(nameof(LoadIntegrantesCommand), true))
                return;
            //IsBusy = true;
            //IsRefreshing = true;
            try
            {
                JuntaDeVecinoService juntaDeVecinoService = new JuntaDeVecinoService();
                IntegrantesList.Clear();
                var integrantes = await juntaDeVecinoService.ObtenerIntegrantesporJuntaDeVecinoID(selectedJunta.JuntaDeVecinosId);

                foreach (var item in integrantes)
                {
                    IntegrantesList.Add(item);
                }

            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("Error Message", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(LoadIntegrantesCommand));
                //IsBusy = false;
                //IsRefreshing = false;
            }
        }
    }
}
