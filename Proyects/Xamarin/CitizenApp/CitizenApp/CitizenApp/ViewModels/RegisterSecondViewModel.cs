using CitizenApp.Models;
using CitizenApp.Services.DataStores;
using CitizenApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CitizenApp.ViewModels
{
    public class RegisterSecondViewModel : BaseViewModel
    {
        private Persona persona;
        public List<Provincia> provincias = new List<Provincia>();
        public List<Municipio> municipios = new List<Municipio>();
        public List<DistritoMunicipal> distritoMunicipales = new List<DistritoMunicipal>();
        public List<Seccion> secciones = new List<Seccion>();
        public List<Sector> sectores = new List<Sector>();
        public List<Barrio> barrios = new List<Barrio>();


        #region Pickers


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

      
        private Provincia _provinciaSelected = new Provincia();
        public Provincia ProvinciaSelected
        {
            get { return _provinciaSelected; }
            set 
            {
                SetProperty(ref _provinciaSelected, value);

                if (!_isVisibleEditButton )
                {
                    _municipioList.Clear();
                    var municipiosTemp = municipios.FindAll(x => x.ProvinciaId == _provinciaSelected.ProvinciaId);
                    foreach (var municipio in municipiosTemp)
                    {
                        _municipioList.Add(municipio);
                    }

                   
                    MunicipioSelected = null;
                    DistritoMunicipalSelected = null;
                    SeccionSelected = null;
                    SectorSelected = null;
                    BarrioSelected = null;
                    isEnableMunicipio = true;
                    isEnableDistritoMunicipal = false;
                    isEnableSeccion = false;
                    isEnableSector = false;
                    isEnableBarrio = false;
                }
                
            }
        }

        private Municipio _municipioSelected = new Municipio();
        public Municipio MunicipioSelected
        {
            get { return _municipioSelected; }
            set 
            { 
                SetProperty(ref _municipioSelected, value);

                if (!_isVisibleEditButton && _municipioSelected != null)
                {
                    _distritoMunicipalList.Clear();
                    var distritoMunicipalesTemp = distritoMunicipales.FindAll(x => x.MunicipioId == _municipioSelected.MunicipioId);
                    foreach (var distritoMunicipal in distritoMunicipalesTemp)
                    {
                        _distritoMunicipalList.Add(distritoMunicipal);
                    }

                  
                    DistritoMunicipalSelected = null;
                    SeccionSelected = null;
                    SectorSelected = null;
                    BarrioSelected = null;
                    isEnableDistritoMunicipal = true;
                    isEnableSeccion = false;
                    isEnableSector = false;
                    isEnableBarrio = false;

                }
                
            }
        }


        private DistritoMunicipal _distritoMunicipalSelected = new DistritoMunicipal();
        public DistritoMunicipal DistritoMunicipalSelected
        {
            get { return _distritoMunicipalSelected; }
            set 
            { 
                SetProperty(ref _distritoMunicipalSelected, value);

                if (!_isVisibleEditButton && _distritoMunicipalSelected != null)
                {
                    _seccionList.Clear();
                    var seccionesTemp = secciones.FindAll(x => x.DistritoMunicipalId == _distritoMunicipalSelected.DistritoMunicipalId);
                    foreach (var seccion in seccionesTemp)
                    {
                        _seccionList.Add(seccion);
                    }

                    
                   
                    SeccionSelected = null;
                    SectorSelected = null;
                    BarrioSelected = null;
                    isEnableSeccion = true;
                    isEnableSector = false;
                    isEnableBarrio = false;
                }
               
            }
        }

        private Seccion _seccionSelected = new Seccion();
        public Seccion SeccionSelected
        {
            get { return _seccionSelected; }
            set 
            { 
                SetProperty(ref _seccionSelected, value);

                if (!_isVisibleEditButton && _seccionSelected != null)
                {
                    _sectorList.Clear();
                    var sectoresTemp = sectores.FindAll(x => x.SeccionId == _seccionSelected.SeccionId);
                    foreach (var sector in sectoresTemp)
                    {
                        _sectorList.Add(sector);
                    }

                    
                    
                    SectorSelected = null;
                    BarrioSelected = null;
                    isEnableSector = true;
                    isEnableBarrio = false;

                }
                
            }
        }


        private Sector _sectorSelected = new Sector();
        public Sector SectorSelected
        {
            get { return _sectorSelected; }
            set 
            { 
                SetProperty(ref _sectorSelected, value);

                if (!_isVisibleEditButton && _sectorSelected != null)
                {
                    _barrioList.Clear();
                    var barriosTemp = barrios.FindAll(x => x.SectorId == _sectorSelected.SectorId);
                    foreach (var barrio in barriosTemp)
                    {
                        _barrioList.Add(barrio);
                    }

                    
                    
                    BarrioSelected = null;
                    isEnableBarrio = true;
                }
                
            }
        }

        private Barrio _barrioSelected = new Barrio();
        public Barrio BarrioSelected
        {
            get { return _barrioSelected; }
            set { SetProperty(ref _barrioSelected, value); }
        }

        #endregion

        #region Buttons
        public Command ContinuarCommand { get; set; }
        
        async void ExecuteContinuarCommand()
        {
            if (_barrioSelected != null)
            {
                Usuario usuario = new Usuario()
                {
                    Nombres = persona.Nombres,
                    Apellidos = persona.Apellidos,
                    Documento = persona.Cedula,
                    BarrioId = _barrioSelected.BarrioId,
                    TipoDocumentoId = 1,
                    TipoUsuarioId = 1
                    
                    
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterThirdPage(usuario));
            }
            else
            {
                MakeAlter("Error", "Debe completar todos los datos de su ubicacion.", "OK");
            }
            
        }

        public Command EditCommand { get; set; }

        void ExecuteEditarCommand()
        {
            ProvinciaSelected = null;
            MunicipioSelected = null;
            DistritoMunicipalSelected = null;
            SeccionSelected = null;
            SectorSelected = null;
            BarrioSelected = null;
            isEnableProvincia = true;            
            isVisibleEditButton = false;
            MakeAlter("Informacion", "Ingrese sus datos nuevos.", "OK");
        }
        #endregion
        public void MakeAlter(string Titulo, string Description, string buttonText)
        {
            Application.Current.MainPage.DisplayAlert(Titulo, Description, buttonText);
        }
        #region IsEnablePickers


        private bool _isVisibleEditButton = true;
        public bool isVisibleEditButton
        {
            get { return _isVisibleEditButton; }
            set { SetProperty(ref _isVisibleEditButton, value); }
        }

        private bool _isEnableProvincia = false;
        public bool isEnableProvincia
        {
            get { return _isEnableProvincia; }
            set { SetProperty(ref _isEnableProvincia, value); }
        }

        private bool _isEnableMunicipio = false;
        public bool isEnableMunicipio
        {
            get { return _isEnableMunicipio; }
            set { SetProperty(ref _isEnableMunicipio, value); }
        }

        private bool _isEnableDistritoMunicipal = false;
        public bool isEnableDistritoMunicipal
        {
            get { return _isEnableDistritoMunicipal; }
            set { SetProperty(ref _isEnableDistritoMunicipal, value); }
        }

        private bool _isEnableSeccion = false;
        public bool isEnableSeccion
        {
            get { return _isEnableSeccion; }
            set { SetProperty(ref _isEnableSeccion, value); }
        }

        private bool _isEnableSector = false;
        public bool isEnableSector
        {
            get { return _isEnableSector; }
            set { SetProperty(ref _isEnableSector, value); }
        }

        private bool _isEnableBarrio = false;
        public bool isEnableBarrio
        {
            get { return _isEnableBarrio; }
            set { SetProperty(ref _isEnableBarrio, value); }
        }




        #endregion

        #region Constructor
        public RegisterSecondViewModel(Persona persona)
        {
            Task.Run(async() => await CargarLocalidades());
            
            this.persona = persona;

            ContinuarCommand = new Command(() => ExecuteContinuarCommand());
            EditCommand = new Command(() => ExecuteEditarCommand());

        }

     
        #endregion

        private async Task CargarLocalidades()
        {
            try
            {
             

                _provinciaList.Clear();
                provincias = (List<Provincia>)(await LocalidadService.ObtenerProvincias());
                foreach (var provincia in provincias)
                {
                    _provinciaList.Add(provincia);
                }
                ProvinciaSelected = provincias.Find(x=> x.Nombre == persona.Provincia);

                _municipioList.Clear();
                municipios = (List<Municipio>)(await LocalidadService.ObtenerMunicipios());
                foreach (var municipio in municipios)
                {
                    _municipioList.Add(municipio);
                }
                MunicipioSelected = municipios.Find(x => x.Nombre == persona.Municipio);

                _distritoMunicipalList.Clear();
                distritoMunicipales = (List<DistritoMunicipal>)(await LocalidadService.ObtenerDistritoMunicipales());
                foreach (var distritoMunicipal in distritoMunicipales)
                {
                    _distritoMunicipalList.Add(distritoMunicipal);
                }
                DistritoMunicipalSelected = distritoMunicipales.Find(x => x.Nombre == persona.DistritoMunicipal);

                _seccionList.Clear();
                secciones = (List<Seccion>)(await LocalidadService.ObtenerSecciones());
                foreach (var seccion in secciones)
                {
                    _seccionList.Add(seccion);
                }
                SeccionSelected = secciones.Find(x => x.Nombre == persona.Seccion);

                _sectorList.Clear();
                sectores = (List<Sector>)(await LocalidadService.ObtenerSectores());
                foreach (var sector in sectores)
                {
                    _sectorList.Add(sector);
                }
                SectorSelected = sectores.Find(x => x.Nombre == persona.Sector);

                _barrioList.Clear();
                barrios = (List<Barrio>)(await LocalidadService.ObtenerBarrios());
                foreach (var barrio in barrios)
                {
                    _barrioList.Add(barrio);
                }
                BarrioSelected = barrios.Find(x => x.Nombre == persona.Barrio);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
