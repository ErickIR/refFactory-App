using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CitizenApp.Models;
using System.Linq;

namespace CitizenApp.Services.Services
{
    public class IncidenciaService : BaseHttpClient
    {
        readonly List<Incidencia> Incidencias;
        readonly List<IncidenciaUsuario> Apoyos;
        readonly List<TipoIncidencia> TiposIncidencia;
        readonly List<StatusIncidencia> StatusIncidencias;
        int nextIncidenciaIdx = 6;
        int nextApoyoIdx = 4;
        public IncidenciaService()
        {
            Apoyos = new List<IncidenciaUsuario>()
            {
                new IncidenciaUsuario { IncidenciaUsuarioId = 1, IncidenciaId = 1, UsuarioId = 1},
                new IncidenciaUsuario { IncidenciaUsuarioId = 2, IncidenciaId = 3, UsuarioId = 1},
                new IncidenciaUsuario { IncidenciaUsuarioId = 3, IncidenciaId = 1, UsuarioId = 1}
            };

            TiposIncidencia = new List<TipoIncidencia>()
            {
                new TipoIncidencia { TipoIncidenciaId = 1, Descripcion = "Salubridad" },
                new TipoIncidencia { TipoIncidenciaId = 2, Descripcion = "Mantenimiento" },
                new TipoIncidencia { TipoIncidenciaId = 3, Descripcion = "Comunicacion"}
            };

            StatusIncidencias = new List<StatusIncidencia>()
            {
                new StatusIncidencia { StatusIncidenciaId = 1, Descripcion = "En Proceso"},
                new StatusIncidencia { StatusIncidenciaId = 2, Descripcion = "Completada"}
            };

            Incidencias = new List<Incidencia>()
            {
                new Incidencia()
                {
                    Titulo = "Incidencia #1",
                    Descripcion = "Incidencia Importante.",
                    Empleado = new Usuario() {UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com"},
                    Usuario = new Usuario() {UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com"},
                    Status = new StatusIncidencia { StatusIncidenciaId = 1, Descripcion = "En Proceso"},
                    TipoIncidencia = new TipoIncidencia { TipoIncidenciaId = 2, Descripcion = "Mantenimiento" },
                    Barrio = new Barrio() { BarrioId = 1, Nombre = "El Regina" }
                },
                new Incidencia()
                {
                    Titulo = "Incidencia #2",
                    Descripcion = "Incidencia Importante.",
                    Empleado = new Usuario() {UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com"},
                    Usuario = new Usuario() {UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com"},
                    Status = new StatusIncidencia { StatusIncidenciaId = 1, Descripcion = "En Proceso"},
                    TipoIncidencia = new TipoIncidencia { TipoIncidenciaId = 2, Descripcion = "Mantenimiento" },
                    Barrio = new Barrio() { BarrioId = 1, Nombre = "El Regina" }
                },
                new Incidencia()
                {
                    Titulo = "Incidencia #3",
                    Descripcion = "Incidencia Importante.",
                    Empleado = new Usuario() {UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com"},
                    Usuario = new Usuario() {UsuarioId = 1, Nombres = "Erick", Apellidos = "Restituyo", Email = "erickrc9827@gmail.com"},
                    Status = new StatusIncidencia { StatusIncidenciaId = 1, Descripcion = "En Proceso"},
                    TipoIncidencia = new TipoIncidencia { TipoIncidenciaId = 2, Descripcion = "Mantenimiento" },
                    Barrio = new Barrio() { BarrioId = 1, Nombre = "El Regina" }
                }
            };
        }

        public async Task<Incidencia> RegistrarNuevaIncidenciaAsync(Incidencia item)
        {
            item.IncidenciaId = nextIncidenciaIdx;

            Incidencias.Add(item);
            nextIncidenciaIdx++;

            return await Task.FromResult(item);
        }

        public async Task<bool> EliminarIncidenciaUsuarioAsync(int incidenciaUsuarioId)
        {
            Apoyos.RemoveAll(Incidencia => Incidencia.IncidenciaId == incidenciaUsuarioId);

            return await Task.FromResult(true);
        }

        public async Task<IncidenciaUsuario> RegistrarNuevoApoyoIncidenciaAsync(Incidencia incidencia, Usuario user)
        {
            var newApoyo = new IncidenciaUsuario()
            {
                IncidenciaUsuarioId = nextApoyoIdx++,
                IncidenciaId = incidencia.IncidenciaId,
                UsuarioId = user.UsuarioId
            };

            Apoyos.Add(newApoyo);

            return await Task.FromResult(newApoyo);
        }

        public async Task<IEnumerable<IncidenciaUsuario>> ObtenerRegistrosApoyoIncidencia(int incidenciaId)
        {
            var apoyosAIncidencia = Apoyos.FindAll(apoyo => apoyo.IncidenciaId == incidenciaId);

            return await Task.FromResult(apoyosAIncidencia);
        }

        public async Task<bool> EditarRegistroIncidenciaAsync(Incidencia item)
        {
            var oldItem = Incidencias.Where((Incidencia arg) => arg.IncidenciaId == item.IncidenciaId).FirstOrDefault();
            Incidencias.Remove(oldItem);
            Incidencias.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerTodosRegistrosIncidenciaAsync()
        {
            return await Task.FromResult(Incidencias);
        }

        public async Task<Incidencia> ObtenerRegistroIncidenciaPorIdAsync(int itemId)
        {
            var incidencia = Incidencias.Find(cur => cur.IncidenciaId == itemId);

            return await Task.FromResult(incidencia);
        }

        public async Task<IEnumerable<TipoIncidencia>> ObtenerTiposDeIncidencia()
        {
            return await Task.FromResult(TiposIncidencia);
        }

        public async Task<IEnumerable<StatusIncidencia>> ObtenerEstadosDeIncidencia()
        {
            return await Task.FromResult(StatusIncidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorEstadoAsync(int statusId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.Status.StatusIncidenciaId == statusId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorTipoAsync(int tipoId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.TipoIncidencia.TipoIncidenciaId == tipoId);

            return await Task.FromResult(incidencias);
        }

        public async Task<IEnumerable<Incidencia>> ObtenerIncidenciasPorPalabraAsync(string search)
        {
            var incidencias = Incidencias.FindAll(inc => inc.Titulo.Contains(search) || inc.Descripcion.Contains(search));

            return await Task.FromResult(incidencias);
        }
        
        public async Task<IEnumerable<Incidencia>> ObtenerMisIncidenciasAsync(int userId)
        {
            var incidencias = Incidencias.FindAll(inc => inc.Usuario.UsuarioId == userId);

            return await Task.FromResult(incidencias);
        }


    }
}
