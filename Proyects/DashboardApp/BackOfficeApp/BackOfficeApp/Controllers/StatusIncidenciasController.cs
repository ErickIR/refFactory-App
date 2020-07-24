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
    public class StatusIncidenciasController : Controller
    {
        private readonly CooperaDBContext _context;

        public StatusIncidenciasController(CooperaDBContext context)
        {
            _context = context;
        }

        // GET: StatusIncidencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusIncidencia.ToListAsync());
        }

        // GET: StatusIncidencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusIncidencia = await _context.StatusIncidencia
                .FirstOrDefaultAsync(m => m.StatusIncidenciaId == id);
            if (statusIncidencia == null)
            {
                return NotFound();
            }

            return View(statusIncidencia);
        }

        // GET: StatusIncidencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusIncidencias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusIncidenciaId,Descripccion")] StatusIncidencia statusIncidencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusIncidencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusIncidencia);
        }

        // GET: StatusIncidencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusIncidencia = await _context.StatusIncidencia.FindAsync(id);
            if (statusIncidencia == null)
            {
                return NotFound();
            }
            return View(statusIncidencia);
        }

        // POST: StatusIncidencias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusIncidenciaId,Descripccion")] StatusIncidencia statusIncidencia)
        {
            if (id != statusIncidencia.StatusIncidenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusIncidencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusIncidenciaExists(statusIncidencia.StatusIncidenciaId))
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
            return View(statusIncidencia);
        }

        // GET: StatusIncidencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusIncidencia = await _context.StatusIncidencia
                .FirstOrDefaultAsync(m => m.StatusIncidenciaId == id);
            if (statusIncidencia == null)
            {
                return NotFound();
            }

            return View(statusIncidencia);
        }

        // POST: StatusIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusIncidencia = await _context.StatusIncidencia.FindAsync(id);
            _context.StatusIncidencia.Remove(statusIncidencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusIncidenciaExists(int id)
        {
            return _context.StatusIncidencia.Any(e => e.StatusIncidenciaId == id);
        }
    }
}
