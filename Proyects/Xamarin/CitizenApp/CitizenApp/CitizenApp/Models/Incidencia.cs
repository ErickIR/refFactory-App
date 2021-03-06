﻿using Android.Media;
using FFImageLoading.Work;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CitizenApp.Models
{
    public class Incidencia
    {
        public int IncidenciaId { get; set; }
        public int EmpleadoId { get; set; }
        public int UsuarioId { get; set; }
        public int StatusId { get; set; }
        public int TipoIncidenciaId { get; set; }
        public int BarrioId { get; set; }
        public byte[] Imagen { get; set; }
        public string TituloImagen { get; set; }
        public string Titulo { get; set; }
        [JsonProperty("Descripccion")]
        public string Descripcion { get; set; }
        public int CantidadApoyos { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Usuario { get; set; }
        public StatusIncidencia Status { get; set; }
        [JsonProperty("Tipo")]
        public TipoIncidencia TipoIncidencia { get; set; }
        public Barrio Barrio { get; set; }
        public DateTime? FechaCreado { get; set; }


        public Xamarin.Forms.ImageSource ImageSrc
        {
            get
            {
                if(Imagen == null || Imagen.Length == 0)
                {
                    return Xamarin.Forms.ImageSource.FromFile("incidenciaEj");
                }
                else
                {
                    return Xamarin.Forms.ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(Imagen);
                    });
                }
            }
        }
        public int Apoyos { get; set; }
        public string statusColor
        {
            get
            {
                if (Status.StatusIncidenciaId == 1)
                {
                    return "Red";
                }
                else if (Status.StatusIncidenciaId == 2)
                {
                    return "Blue";
                }
                else
                {
                    return "Green";
                }
            } 
        }
        public string ApoyosPhrase { get => $"{Apoyos} Han apoyado esto."; }
    }
}
