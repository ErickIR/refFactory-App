using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackOfficeApp.DatabaseContext;
using BackOfficeApp.Models;

namespace BackOfficeApp.Controllers
{
    public class IncidenciasController : Controller
    {
        private readonly CooperaDBContext _context;

        public IncidenciasController(CooperaDBContext context)
        {
            _context = context;
        }

        // GET: Incidencias
        public async Task<IActionResult> Index()
        {
            var cooperaDBContext = _context.Incidencia.Include(i => i.Barrio).Include(i => i.Empleado).Include(i => i.Status).Include(i => i.Tipo).Include(i => i.Usuario);
            return View(await cooperaDBContext.ToListAsync());
        }

        // GET: Incidencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencia
                .Include(i => i.Barrio)
                .Include(i => i.Empleado)
                .Include(i => i.Status)
                .Include(i => i.Tipo)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.IncidenciaId == id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return View(incidencia);
        }

        // GET: Incidencias/Create
        public IActionResult Create()
        {
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre");
            ViewData["EmpleadoId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto");
            ViewData["StatusId"] = new SelectList(_context.StatusIncidencia, "StatusIncidenciaId", "Descripccion");
            ViewData["TipoId"] = new SelectList(_context.TipoIncidencia, "TipoIncidenciaId", "Descripccion");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto");
            return View();
        }

        // POST: Incidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncidenciaId,EmpleadoId,UsuarioId,StatusId,TipoId,BarrioId,Titulo,Descripccion")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre", incidencia.BarrioId);
            ViewData["EmpleadoId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto", incidencia.EmpleadoId);
            ViewData["StatusId"] = new SelectList(_context.StatusIncidencia, "StatusIncidenciaId", "Descripccion", incidencia.StatusId);
            ViewData["TipoId"] = new SelectList(_context.TipoIncidencia, "TipoIncidenciaId", "Descripccion", incidencia.TipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto", incidencia.UsuarioId);
            return View(incidencia);
        }

        // GET: Incidencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencia.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre", incidencia.BarrioId);
            ViewData["EmpleadoId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto", incidencia.EmpleadoId);
            ViewData["StatusId"] = new SelectList(_context.StatusIncidencia, "StatusIncidenciaId", "Descripccion", incidencia.StatusId);
            ViewData["TipoId"] = new SelectList(_context.TipoIncidencia, "TipoIncidenciaId", "Descripccion", incidencia.TipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto", incidencia.UsuarioId);
            return View(incidencia);
        }

        // POST: Incidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncidenciaId,EmpleadoId,UsuarioId,StatusId,TipoId,BarrioId,Titulo,Descripccion")] Incidencia incidencia)
        {
            if (id != incidencia.IncidenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidenciaExists(incidencia.IncidenciaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre", incidencia.BarrioId);
            ViewData["EmpleadoId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto", incidencia.EmpleadoId);
            ViewData["StatusId"] = new SelectList(_context.StatusIncidencia, "StatusIncidenciaId", "Descripccion", incidencia.StatusId);
            ViewData["TipoId"] = new SelectList(_context.TipoIncidencia, "TipoIncidenciaId", "Descripccion", incidencia.TipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "NombreCompleto", incidencia.UsuarioId);
            return View(incidencia);
        }

        // GET: Incidencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencia
                .Include(i => i.Barrio)
                .Include(i => i.Empleado)
                .Include(i => i.Status)
                .Include(i => i.Tipo)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.IncidenciaId == id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return View(incidencia);
        }

        // POST: Incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidencia = await _context.Incidencia.FindAsync(id);
            _context.Incidencia.Remove(incidencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidenciaExists(int id)
        {
            return _context.Incidencia.Any(e => e.IncidenciaId == id);
        }
    }
}
