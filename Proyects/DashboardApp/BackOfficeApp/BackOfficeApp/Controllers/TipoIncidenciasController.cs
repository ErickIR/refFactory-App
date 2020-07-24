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
    public class TipoIncidenciasController : Controller
    {
        private readonly CooperaDBContext _context;

        public TipoIncidenciasController(CooperaDBContext context)
        {
            _context = context;
        }

        // GET: TipoIncidencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoIncidencia.ToListAsync());
        }

        // GET: TipoIncidencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIncidencia = await _context.TipoIncidencia
                .FirstOrDefaultAsync(m => m.TipoIncidenciaId == id);
            if (tipoIncidencia == null)
            {
                return NotFound();
            }

            return View(tipoIncidencia);
        }

        // GET: TipoIncidencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIncidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoIncidenciaId,Descripccion")] TipoIncidencia tipoIncidencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIncidencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIncidencia);
        }

        // GET: TipoIncidencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIncidencia = await _context.TipoIncidencia.FindAsync(id);
            if (tipoIncidencia == null)
            {
                return NotFound();
            }
            return View(tipoIncidencia);
        }

        // POST: TipoIncidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoIncidenciaId,Descripccion")] TipoIncidencia tipoIncidencia)
        {
            if (id != tipoIncidencia.TipoIncidenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIncidencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIncidenciaExists(tipoIncidencia.TipoIncidenciaId))
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
            return View(tipoIncidencia);
        }

        // GET: TipoIncidencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIncidencia = await _context.TipoIncidencia
                .FirstOrDefaultAsync(m => m.TipoIncidenciaId == id);
            if (tipoIncidencia == null)
            {
                return NotFound();
            }

            return View(tipoIncidencia);
        }

        // POST: TipoIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoIncidencia = await _context.TipoIncidencia.FindAsync(id);
            _context.TipoIncidencia.Remove(tipoIncidencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIncidenciaExists(int id)
        {
            return _context.TipoIncidencia.Any(e => e.TipoIncidenciaId == id);
        }
    }
}
