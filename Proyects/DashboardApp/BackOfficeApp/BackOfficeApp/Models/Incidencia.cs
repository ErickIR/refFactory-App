﻿using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Incidencia
    {
        public Incidencia()
        {
            Archivo = new HashSet<Archivo>();
            IncidenciaUsuario = new HashSet<IncidenciaUsuario>();
        }

        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public int UsuarioId { get; set; }
        public int StatusId { get; set; }
        public int TipoId { get; set; }
        public int BarrioId { get; set; }
        public string Titulo { get; set; }
        public string Descripccion { get; set; }

        public virtual Barrio Barrio { get; set; }
        public virtual Usuario Empleado { get; set; }
        public virtual StatusIncidencia Status { get; set; }
        public virtual TipoIncidencia Tipo { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Archivo> Archivo { get; set; }
        public virtual ICollection<IncidenciaUsuario> IncidenciaUsuario { get; set; }
    }
}
