using CitizenApp.Helper;
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
        public class EntidadesMunicipales
        {
            public int EntidadesMunicipalesID { get; set; }
            public string Nombre { get; set; }
            public string Cargo { get; set; }
            public string Imagen { get; set; }
        }




        internal readonly ClickRegulator _clickRegulator = new ClickRegulator();
        private ObservableCollection<EntidadesMunicipales> _entidadesList;
        
        public ObservableCollection<EntidadesMunicipales> EntidadesList
        {
            get { return _entidadesList; }
            set { SetProperty(ref _entidadesList, value); }

        }

        public Command LoadEntidadesMunicipalesCommand { get; }

        public EntidadesMunicipalesViewModel()
        {
            _entidadesList = new ObservableCollection<EntidadesMunicipales>();
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
                var integrantes = new List<EntidadesMunicipales>() { 
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 1, Cargo = "Alcalde", Nombre = "Marcos Antonio Arjona", Imagen = "PersonaInt"},
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 2, Cargo = "Senador", Nombre = "Dina Parra", Imagen = "PersonaInt"},
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 3, Cargo = "Diputado", Nombre = "Jose Tomas Castilla", Imagen = "PersonaInt"},
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 4, Cargo = "Diputado", Nombre = "Pedro Miguel Chico", Imagen = "PersonaInt"},
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 5, Cargo = "Diputado", Nombre = "Noel Peinado", Imagen = "PersonaInt"},
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 6, Cargo = "Regidor", Nombre = "Francesca Pino", Imagen = "PersonaInt"},
                    new EntidadesMunicipales{  EntidadesMunicipalesID = 7, Cargo = "Regidor", Nombre = "Gertrudis de Los Santos", Imagen = "PersonaInt"}
                };

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
