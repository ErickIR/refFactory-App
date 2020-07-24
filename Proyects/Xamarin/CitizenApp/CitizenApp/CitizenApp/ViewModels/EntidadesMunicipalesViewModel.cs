using CitizenApp.Helper;
using CitizenApp.Models;
using CitizenApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class EntidadesMunicipalesViewModel : BaseViewModel
    {
        




        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();
        private ObservableCollection<EntidadMunicipal> _entidadesList;
        
        public ObservableCollection<EntidadMunicipal> EntidadesList
        {
            get { return _entidadesList; }
            set { SetProperty(ref _entidadesList, value); }

        }

        public Command LoadEntidadesMunicipalesCommand { get; }

        public EntidadesMunicipalesViewModel()
        {
            _entidadesList = new ObservableCollection<EntidadMunicipal>();
            LoadEntidadesMunicipalesCommand = new Command(async () => await ExecuteLoadEntidadesMunicipalesCommand());
        }

        private async Task ExecuteLoadEntidadesMunicipalesCommand()
        {
            if (_clickRegulator.SetClicked(nameof(LoadEntidadesMunicipalesCommand), true))
                return;
            //IsBusy = true;
            //IsRefreshing = true;
            try
            {

                _entidadesList.Clear();
                var integrantes = await EntidadesMunicipalesService.ObtenerEntidadesMunicipales();

                foreach (var item in integrantes)
                {
                    _entidadesList.Add(item);
                }

            }
            catch (Exception ex)
            {
                await PageService.DisplayAlert("Error Message", ex.Message, "OK");
            }
            finally
            {
                _clickRegulator.ClickDone(nameof(LoadEntidadesMunicipalesCommand));
                //IsBusy = false;
                //IsRefreshing = false;
            }
        }
    }
}
