
using CitizenApp.Models;
using CitizenApp.Services.DataStores;
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
        private ObservableCollection<JuntaDeVecinos> _juntadeVecinosList = new ObservableCollection<JuntaDeVecinos>();
        public ObservableCollection<JuntaDeVecinos> JuntadeVecinosList
        {
            get { return _juntadeVecinosList; }
            set { SetProperty(ref _juntadeVecinosList, value); }
        }
        public Command LoadJuntasCommand { get; }
        public JuntadeVecinosViewModel()
        {
            LoadJuntasCommand = new Command(async () => await ExecuteLoadJuntasCommand());
        }

        async Task ExecuteLoadJuntasCommand()
        {
            //if (_clickRegulator.SetClicked(nameof(ExecuteLoadIncidenciasCommand), true))
            //    return;
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
                //_clickRegulator.ClickDone(nameof(ExecuteLoadIncidenciasCommand));
                //IsBusy = false;
                //IsRefreshing = false;
            }
        }
    }
}
