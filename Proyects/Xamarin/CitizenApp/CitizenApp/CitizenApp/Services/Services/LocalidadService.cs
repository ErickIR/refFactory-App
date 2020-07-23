using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenApp.Services.DataStores
{
    public class LocalidadService : BaseHttpClient
    {
       
        List<Provincia> provincias;
        List<Municipio> municipios;
        List<DistritoMunicipal> distritoMunicipales;
        List<Seccion> secciones;
        List<Sector> sectores;
        List<Barrio> barrios;
        public LocalidadService()
        {
            
            provincias = new List<Provincia>()
            {
                new Provincia{ProvinciaId=1, RegionId=1, Nombre="Santo Domingo"},
                new Provincia{ProvinciaId=2, RegionId=2, Nombre="Santiago"}
            };

            municipios = new List<Municipio>()
            {
                new Municipio{MunicipioId=1, ProvinciaId=1, Nombre="Santo Domingo de Guzmán"},
                new Municipio{MunicipioId=2, ProvinciaId=2, Nombre="Santiago de los Caballeros"}
                
            };

            distritoMunicipales = new List<DistritoMunicipal>()
            {
                new DistritoMunicipal{ DistritoMunicipalId=1,MunicipioId=1, Nombre="Santo Domingo de Guzmán"},
                new DistritoMunicipal{ DistritoMunicipalId=2,MunicipioId=2, Nombre="Santiago de los Caballeros"}
            };

            secciones = new List<Seccion>()
            {
                new Seccion{SeccionId=1, DistritoMunicipalId=1,Nombre="Santo Domingo de Guzmán (Zona urbana)"}
            };

            sectores = new List<Sector>()
            {
                new Sector{SectorId=1,SeccionId = 1,Nombre ="Los Restauradores" },
                new Sector{SectorId=2,SeccionId = 1,Nombre ="San Jerónimo" },
                new Sector{SectorId=3,SeccionId = 1,Nombre ="Los Jardines" },
                new Sector{SectorId=4,SeccionId = 1,Nombre ="Julieta Morales" }

            };

            barrios = new List<Barrio>()
            {
                new Barrio{BarrioId=1, SectorId=1,Nombre = "Los Restauradores" },
                new Barrio{BarrioId=2, SectorId=1,Nombre = "Residencial Rosmil" },
                new Barrio{BarrioId=3, SectorId=1,Nombre = "Manganagua" },
                new Barrio{BarrioId=4, SectorId=1,Nombre = "Milloncito" },

                new Barrio{BarrioId=5, SectorId=2,Nombre = "San Jerónimo" },
                new Barrio{BarrioId=6, SectorId=2,Nombre = "Estancia Nueva" },
                new Barrio{BarrioId=7, SectorId=2,Nombre = "Ciudad Moderna" },
                new Barrio{BarrioId=8, SectorId=2,Nombre = "Los Pinos" },
                new Barrio{BarrioId=9, SectorId=2,Nombre = "Las Praderas" },
                new Barrio{BarrioId=10, SectorId=2,Nombre = "Los Laureles" },

                new Barrio{BarrioId=11, SectorId=3,Nombre = "Los Jardines" },
                new Barrio{BarrioId=12, SectorId=3,Nombre = "Los Próceres" },
                new Barrio{BarrioId=13, SectorId=3,Nombre = "Galá" },
                new Barrio{BarrioId=14, SectorId=3,Nombre = "Constelación" },
                new Barrio{BarrioId=15, SectorId=3,Nombre = "Country Club" },

                new Barrio{BarrioId=16, SectorId=4,Nombre = "Julieta Morales" },
                new Barrio{BarrioId=17, SectorId=4,Nombre = "Los Praditos" },
                new Barrio{BarrioId=18, SectorId=4,Nombre = "La Jabilla" },
                new Barrio{BarrioId=19, SectorId=4,Nombre = "La Carmelita" },
            };
        }

        public async Task<List<Barrio>> ObtenerBarriosPorSectorIDAsync(int sectorId)
        {
            var barriosResult = barrios.FindAll(x => x.SectorId == sectorId);
            return await Task.FromResult(barriosResult);
        }

        public async Task<List<Sector>> ObtenerSectoresPorSeccionIDAsync(int seccionId)
        {
            var sectoresResult = sectores.FindAll(x => x.SeccionId == seccionId);
            return await Task.FromResult(sectoresResult);
        }

        public async Task<List<Seccion>> ObtenerSeccionesPorDistritoMunicipalesIDAsync(int distritoMunicipalesId)
        {
            var seccionesResult = secciones.FindAll(x => x.DistritoMunicipalId == distritoMunicipalesId);
            return await Task.FromResult(seccionesResult);
        }

        public async Task<List<DistritoMunicipal>> ObtenerDistritoMunicipalesPorMunicipioIDAsync(int municipioId)
        {
            var distritoMunicipalesResult = distritoMunicipales.FindAll(x => x.MunicipioId == municipioId);
            return await Task.FromResult(distritoMunicipalesResult);
        }

        public async Task<List<Municipio>> ObtenerMunicipiosPorProvinciaIDAsync(int provinciaId)
        {
            var municipiosResult = municipios.FindAll(x => x.ProvinciaId == provinciaId);
            return await Task.FromResult(municipiosResult);
        }

        public async Task<List<Provincia>> ObtenerProvinciasPorRegionIDAsync(int regionId)
        {
            var provinciasResult = provincias.FindAll(x => x.RegionId == regionId);
            return await Task.FromResult(provinciasResult);
        }

        public async Task<List<Barrio>> ObtenerBarriosPorDistritosMunicipalesIDAsync(int distritosMunicipalesId)
        {
            var listaSecciones = await ObtenerSeccionesPorDistritoMunicipalesIDAsync(distritosMunicipalesId);
            List<Sector> listSectores = new List<Sector>();
            List<Barrio> listBarrios = new List<Barrio>();
            foreach (var seccion in listaSecciones)
            {

                listSectores = listSectores.Concat(await ObtenerSectoresPorSeccionIDAsync(seccion.SeccionId)).ToList();

            }

            foreach (var sector in listSectores)
            {
                listBarrios = listBarrios.Concat(await ObtenerBarriosPorSectorIDAsync(sector.SectorId)).ToList();
            }


            return await Task.FromResult(listBarrios);
        }

       
        public async Task<IEnumerable<Provincia>> ObtenerProvincias()
        {
            return await Task.FromResult(provincias);
        }
        public async Task<IEnumerable<Municipio>> ObtenerMunicipios()
        {
            return await Task.FromResult(municipios);
        }
        public async Task<IEnumerable<DistritoMunicipal>> ObtenerDistritoMunicipales()
        {
            return await Task.FromResult(distritoMunicipales);
        }
        public async Task<IEnumerable<Seccion>> ObtenerSecciones()
        {
            return await Task.FromResult(secciones);
        }
        public async Task<IEnumerable<Sector>> ObtenerSectores()
        {
            return await Task.FromResult(sectores);
        }
        public async Task<IEnumerable<Barrio>> ObtenerBarrios()
        {
            return await Task.FromResult(barrios);
        }
       

    }
}