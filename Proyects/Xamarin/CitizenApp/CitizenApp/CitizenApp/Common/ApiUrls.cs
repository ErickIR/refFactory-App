using System;
using System.Collections.Generic;
using System.Text;

namespace CitizenApp.Common
{
    public enum ResponseCode
    {
        Ok = 20,
        Warning = 40,
        Error = 50
    }

    public static class ApiUrls
    {
        public const string Barrio = "barrio/";
        public const string BarrioPorSector = "barrio/sector/";
        public const string Cargos = "cargo/";
        public const string DistritoMunicipal = "distrito-municipal/";
        public const string DistritoMunicipalPorMunicipio = "distrito-municipal/municipio/";
        public const string EntidadMunicipal = "entidad-municipal/";
        public const string EntidadMunicipalPorMunicipio = "entidad-municipal/municipio";
        public const string Municipio = "municipio/";
        public const string MunicipioPorBarrio = "municipio/barrio/";
        public const string Provincia = "provincia/";
        public const string Seccion = "seccion/";
        public const string SeccionPorDistritoMunicipal = "seccion/";
        public const string Sector = "sector/";
        public const string SectorPorSeccion = "sector/seccion/";
        public const string StatusIncidencia = "status-incidencia/";
        public const string TipoDocumento = "tipo-documento/";
        public const string TipoIncidencia = "tipo-incidencia/";
        public const string TipoUsuario = "tipo-usuario/";
        public const string Usuario = "usuario/";
    }
}
