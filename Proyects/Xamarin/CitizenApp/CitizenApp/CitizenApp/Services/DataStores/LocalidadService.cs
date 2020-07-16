﻿using CitizenApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Services.DataStores
{
    class LocalidadService
    {
        List<Region> regiones;
        List<Provincia> provincias;
        List<Municipio> municipios;
        List<DistritoMunicipal> distritoMunicipales;
        List<Seccion> secciones;
        List<Sector> sectores;
        List<Barrio> barrios;
        public LocalidadService()
        {
            regiones = new List<Region>()
            {
                new Region{RegionId=1, Nombre="Distrito Nacional"}
            };

            provincias = new List<Provincia>()
            {
                new Provincia{ProvinciaId=1, RegionId=1, Nombre="Santo Domingo"}
            };

            municipios = new List<Municipio>()
            {
                new Municipio{MunicipioId=1, ProvinciaId=1, Nombre="Santo Domingo de Guzmán"}
            };

            distritoMunicipales = new List<DistritoMunicipal>()
            {
                new DistritoMunicipal{ DistritoMunicipalId=1,MunicipioId=1, Nombre="Santo Domingo de Guzmán"}

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
    }
}
