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
    public class EntidadMunicipalsController : Controller
    {
        private readonly CooperaDBContext _context;

        public EntidadMunicipalsController(CooperaDBContext context)
        {
            _context = context;
        }

        // GET: EntidadMunicipals
        public async Task<IActionResult> Index()
        {
            var cooperaDBContext = _context.EntidadMunicipal.Include(e => e.Cargo).Include(e => e.Municipio).Include(e => e.TipoDocumento);
            return View(await cooperaDBContext.ToListAsync());
        }

        // GET: EntidadMunicipals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadMunicipal = await _context.EntidadMunicipal
                .Include(e => e.Cargo)
                .Include(e => e.Municipio)
                .Include(e => e.TipoDocumento)
                .FirstOrDefaultAsync(m => m.EntidadMunicipalId == id);
            if (entidadMunicipal == null)
            {
                return NotFound();
            }

            return View(entidadMunicipal);
        }

        // GET: EntidadMunicipals/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descripccion");
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "MunicipioId", "Nombre");
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "Descripccion");
            return View();
        }

        // POST: EntidadMunicipals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadMunicipalId,CargoId,TipoDocumentoId,MunicipioId,Nombres,Apellidos,Documento,Telefono")] EntidadMunicipal entidadMunicipal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidadMunicipal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descripccion", entidadMunicipal.CargoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "MunicipioId", "Nombre", entidadMunicipal.MunicipioId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "Descripccion", entidadMunicipal.TipoDocumentoId);
            return View(entidadMunicipal);
        }

        // GET: EntidadMunicipals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadMunicipal = await _context.EntidadMunicipal.FindAsync(id);
            if (entidadMunicipal == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descripccion", entidadMunicipal.CargoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "MunicipioId", "Nombre", entidadMunicipal.MunicipioId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "Descripccion", entidadMunicipal.TipoDocumentoId);
            return View(entidadMunicipal);
        }

        // POST: EntidadMunicipals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntidadMunicipalId,CargoId,TipoDocumentoId,MunicipioId,Nombres,Apellidos,Documento,Telefono")] EntidadMunicipal entidadMunicipal)
        {
            if (id != entidadMunicipal.EntidadMunicipalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidadMunicipal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadMunicipalExists(entidadMunicipal.EntidadMunicipalId))
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
            ViewData["CargoId"] = new SelectList(_context.Cargo, "CargoId", "Descripccion", entidadMunicipal.CargoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "MunicipioId", "Nombre", entidadMunicipal.MunicipioId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "Descripccion", entidadMunicipal.TipoDocumentoId);
            return View(entidadMunicipal);
        }

        // GET: EntidadMunicipals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidadMunicipal = await _context.EntidadMunicipal
                .Include(e => e.Cargo)
                .Include(e => e.Municipio)
                .Include(e => e.TipoDocumento)
                .FirstOrDefaultAsync(m => m.EntidadMunicipalId == id);
            if (entidadMunicipal == null)
            {
                return NotFound();
            }

            return View(entidadMunicipal);
        }

        // POST: EntidadMunicipals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entidadMunicipal = await _context.EntidadMunicipal.FindAsync(id);
            _context.EntidadMunicipal.Remove(entidadMunicipal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadMunicipalExists(int id)
        {
            return _context.EntidadMunicipal.Any(e => e.EntidadMunicipalId == id);
        }
    }
}
