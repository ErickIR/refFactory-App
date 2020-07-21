using CitizenApp.Models;
using CitizenApp.Services.DataStores;
using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class RegisterSecondViewModel : BaseViewModel
    {
        private Persona persona;


        #region Pickers
        private ObservableCollection<Models.Region> _regionList = new ObservableCollection<Models.Region>();
        public ObservableCollection<Models.Region> RegionList
        {
            get { return _regionList; }
            set { SetProperty(ref _regionList, value); }
        }

        private ObservableCollection<Provincia> _provinciaList = new ObservableCollection<Provincia>();
        public ObservableCollection<Provincia> ProvinciaList
        {
            get { return _provinciaList; }
            set { SetProperty(ref _provinciaList, value); }
        }

        private ObservableCollection<Municipio> _municipioList = new ObservableCollection<Municipio>();
        public ObservableCollection<Municipio> MunicipioList
        {
            get { return _municipioList; }
            set { SetProperty(ref _municipioList, value); }
        }

        private ObservableCollection<DistritoMunicipal> _distritoMunicipalList = new ObservableCollection<DistritoMunicipal>();
        public ObservableCollection<DistritoMunicipal> DistritoMunicipalList
        {
            get { return _distritoMunicipalList; }
            set { SetProperty(ref _distritoMunicipalList, value); }
        }


        private ObservableCollection<Seccion> _seccionList = new ObservableCollection<Seccion>();
        public ObservableCollection<Seccion> SeccionList
        {
            get { return _seccionList; }
            set { SetProperty(ref _seccionList, value); }
        }

        private ObservableCollection<Sector> _sectorList = new ObservableCollection<Sector>();
        public ObservableCollection<Sector> SectorList
        {
            get { return _sectorList; }
            set { SetProperty(ref _sectorList, value); }
        }

        private ObservableCollection<Barrio> _barrioList = new ObservableCollection<Barrio>();
        public ObservableCollection<Barrio> BarrioList
        {
            get { return _barrioList; }
            set { SetProperty(ref _barrioList, value); }
        }

        #endregion

        #region SelectedItemPicker

        private Models.Region _regionSelected = new Models.Region();
        public Models.Region RegionSelected 
        {
            get { return _regionSelected; }
            set { SetProperty(ref _regionSelected, value); }
        }

        private Provincia _provinciaSelected = new Provincia();
        public Provincia ProvinciaSelected
        {
            get { return _provinciaSelected; }
            set { SetProperty(ref _provinciaSelected, value); }
        }

        private Municipio _municipioSelected = new Municipio();
        public Municipio MunicipioSelected
        {
            get { return _municipioSelected; }
            set { SetProperty(ref _municipioSelected, value); }
        }


        private DistritoMunicipal _distritoMunicipalSelected = new DistritoMunicipal();
        public DistritoMunicipal DistritoMunicipalSelected
        {
            get { return _distritoMunicipalSelected; }
            set { SetProperty(ref _distritoMunicipalSelected, value); }
        }

        private Seccion _seccionSelected = new Seccion();
        public Seccion SeccionSelected
        {
            get { return _seccionSelected; }
            set { SetProperty(ref _seccionSelected, value); }
        }


        private Sector _sectorSelected = new Sector();
        public Sector SectorSelected
        {
            get { return _sectorSelected; }
            set { SetProperty(ref _sectorSelected, value); }
        }



        #endregion

        #region Buttons
        public Command ContinuarCommand { get; set; }
        
        async void ExecuteContinuarCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterThirdPage());
        }
        #endregion


        #region Constructor
        public RegisterSecondViewModel(Persona persona)
        {
            CargarLocalidades();
            SeleccionarLocalidades();
            this.persona = persona;
            ContinuarCommand = new Command(() => ExecuteContinuarCommand());

        }

        private async  void SeleccionarLocalidades()
        {
            
        }
        #endregion

        private async void CargarLocalidades()
        {
            try
            {
                _regionList.Clear();
                var regiones = await LocalidadService.ObtenerRegiones();
                foreach (var region in regiones)
                {
                    _regionList.Add(region);
                }
                

                _provinciaList.Clear();
                var provincias = await LocalidadService.ObtenerProvincias();
                foreach (var provincia in provincias)
                {
                    _provinciaList.Add(provincia);
                }

                _municipioList.Clear();
                var municipios = await LocalidadService.ObtenerMunicipios();
                foreach (var municipio in municipios)
                {
                    _municipioList.Add(municipio);
                }

                _distritoMunicipalList.Clear();
                var distritoMunicipals = await LocalidadService.ObtenerDistritoMunicipales();
                foreach (var distritoMunicipal in distritoMunicipals)
                {
                    _distritoMunicipalList.Add(distritoMunicipal);
                }

                _seccionList.Clear();
                var secciones = await LocalidadService.ObtenerSecciones();
                foreach (var seccion in secciones)
                {
                    _seccionList.Add(seccion);
                }

                _sectorList.Clear();
                var sectores = await LocalidadService.ObtenerSectores();
                foreach (var sector in sectores)
                {
                    _sectorList.Add(sector);
                }

                _barrioList.Clear();
                var barrios = await LocalidadService.ObtenerBarrios();
                foreach (var barrio in barrios)
                {
                    _barrioList.Add(barrio);
                }



            }
            catch(Exception ex)
            {

            }
        }
    }
}
