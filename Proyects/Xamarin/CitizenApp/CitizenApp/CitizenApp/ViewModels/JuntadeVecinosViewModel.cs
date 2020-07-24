
using CitizenApp.Helper;
using CitizenApp.Models;
using CitizenApp.Services.DataStores;
using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class JuntadeVecinosViewModel : BaseViewModel
    {
        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();


        private ObservableCollection<JuntaDeVecinos> _juntadeVecinosList;
        public ObservableCollection<JuntaDeVecinos> JuntadeVecinosList
        {
            get { return _juntadeVecinosList; }
            set { SetProperty(ref _juntadeVecinosList, value); }
        }
        public Command LoadJuntasCommand { get; }
        public ICommand SelectJuntasCommand { get; }




        public JuntadeVecinosViewModel()
        {
            _juntadeVecinosList = new ObservableCollection<JuntaDeVecinos>();
            LoadJuntasCommand = new Command(async () => await ExecuteLoadJuntasCommand());
            SelectJuntasCommand = new Command(async () => await ExecuteSelectJuntasCommand());
        }

        private async Task ExecuteSelectJuntasCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteSelectJuntasCommand), true))
                return;

            try
            {
                await PageService.PushAsync(new IntegrantesJuntaPage(SelectedJunta));
            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("ERROR", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteSelectJuntasCommand));
                SelectedJunta = null;
            }
        }

        JuntaDeVecinos _selectedJunta;
        public JuntaDeVecinos SelectedJunta
        {
            get { return _selectedJunta; }
            set { SetProperty(ref _selectedJunta, value); }
        }

        async Task ExecuteLoadJuntasCommand()
        {
            if (_clickRegulator.SetClicked(nameof(ExecuteLoadJuntasCommand), true))
               return;
            //IsBusy = true;
            //IsRefreshing = true;
            try
            {
                JuntaDeVecinoService juntaDeVecinoService = new JuntaDeVecinoService();
                JuntadeVecinosList.Clear();
                var juntas = await juntaDeVecinoService.ObtenerJuntaDeVecinos();
                
                foreach (var item in juntas)
                {
                    JuntadeVecinosList.Add(item);
                   
                }

            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("Error Message", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(ExecuteLoadJuntasCommand));
                IsBusy = false;
                //IsRefreshing = false;
            }
        }
    }
}
