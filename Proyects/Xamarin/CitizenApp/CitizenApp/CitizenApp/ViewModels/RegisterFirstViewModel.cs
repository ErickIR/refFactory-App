using CitizenApp.Models;
using CitizenApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class RegisterFirstViewModel : BaseViewModel
    {

        private string _cedula = string.Empty;
        public string Cedula
        {
            get => _cedula;
            set => SetProperty(ref _cedula, value);
        }

        private string _nombres = string.Empty;
        public string Nombres
        {
            get => _nombres;
            set => SetProperty(ref _nombres, value);
        }

        private string _apellidos = string.Empty;
        public string Apellidos
        {
            get => _apellidos;
            set => SetProperty(ref _apellidos, value);
        }

        private string _nacimiento = string.Empty;
        public string Nacimiento
        {
            get => _nacimiento;
            set => SetProperty(ref _nacimiento, value);
        }
        Persona persona;
        public Command searchCedulaCommand { get; set; }
        public Command ContinuarCommand { get; set; }

        public RegisterFirstViewModel()
        {
            
            searchCedulaCommand = new Command(async() => await SearchCedulaCommand());
            ContinuarCommand = new Command(() => ExecuteContinuarCommand());
        }

        public void MakeAlter(string Titulo, string Description, string buttonText)
        {
            Application.Current.MainPage.DisplayAlert(Titulo, Description, buttonText);
        }
        async Task SearchCedulaCommand()
        {
            try
            {
                persona = new Persona()
                {
                    Cedula = "40236737728",
                    Nombres = "Fernando Enmanuel",
                    Apellidos = "Hernandez Perez",
                    FechaNacimiento = new DateTime(1998, 12, 26),
                    Nacionalidad = "Dominicana",
                    Sexo = "M",
                    Ocupacion = "Soltero",
                    Region = "Distrito Nacional",
                    Provincia = "Santo Domingo",
                    Municipio = "Santo Domingo de Guzmán",
                    DistritoMunicipal = "Santo Domingo de Guzmán",
                    Seccion = "Santo Domingo de Guzmán (Zona urbana)",
                    Sector = "Los Restauradores",
                    Barrio = "Manganagua"

                };
                var ced = Cedula.Replace("-", "");
                if (ced == persona.Cedula)
                {
                    Nombres = persona.Nombres;
                    Apellidos = persona.Apellidos;
                    Nacimiento = persona.FechaNacimiento.ToString("MM/dd/yyyy");
                }
                else
                {
                    MakeAlter("Informacion", "Cedula no encontrada.", "OK");
                    //await DisplayAlert("Alert", "You have been alerted", "OK");
                }
                
                //List<Persona> personas = await GetPersona();
            }
            catch (Exception ex)
            {

                var detail = ex.Message;
            }
            
        }

        async void ExecuteContinuarCommand()
        {
            if (Nombres != "")
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterSecondPage(persona));
            }
            else
            {
                MakeAlter("Informacion", "Necesita buscar su informacion antes de continuar.", "OK");
            }
            
        }


        private const string ApiBaseAddress = "https://localhost:44343/api/";
        
        private HttpClient CreateClient()
        {
            var ced = Cedula.Replace("-", "");
            string maskLink = "Personas/" + ced;
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress+maskLink)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<List<Persona>> GetPersona()
        {
           
            IEnumerable<Persona> persona = Enumerable.Empty<Persona>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("conferences").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {


                        persona = await Task.Run(() =>
                           JsonConvert.DeserializeObject<IEnumerable<Persona>>(json)
                        ).ConfigureAwait(false);
                    }
                }
            }

            return persona.ToList();
        }
    }
}
