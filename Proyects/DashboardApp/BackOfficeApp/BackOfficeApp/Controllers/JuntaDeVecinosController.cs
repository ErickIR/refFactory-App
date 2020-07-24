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
    public class JuntaDeVecinosController : Controller
    {
        private readonly CooperaDBContext _context;

        public JuntaDeVecinosController(CooperaDBContext context)
        {
            _context = context;
        }

        // GET: JuntaDeVecinos
        public async Task<IActionResult> Index()
        {
            var cooperaDBContext = _context.JuntaDeVecinos.Include(j => j.Barrio);
            return View(await cooperaDBContext.ToListAsync());
        }

        // GET: JuntaDeVecinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juntaDeVecinos = await _context.JuntaDeVecinos
                .Include(j => j.Barrio)
                .FirstOrDefaultAsync(m => m.JuntaDeVecinosId == id);
            if (juntaDeVecinos == null)
            {
                return NotFound();
            }

            return View(juntaDeVecinos);
        }

        // GET: JuntaDeVecinos/Create
        public IActionResult Create()
        {
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre");
            return View();
        }

        // POST: JuntaDeVecinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JuntaDeVecinosId,BarrioId,Nombre,Latitud,Longitud")] JuntaDeVecinos juntaDeVecinos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juntaDeVecinos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre", juntaDeVecinos.BarrioId);
            return View(juntaDeVecinos);
        }

        // GET: JuntaDeVecinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juntaDeVecinos = await _context.JuntaDeVecinos.FindAsync(id);
            if (juntaDeVecinos == null)
            {
                return NotFound();
            }
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre", juntaDeVecinos.BarrioId);
            return View(juntaDeVecinos);
        }

        // POST: JuntaDeVecinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JuntaDeVecinosId,BarrioId,Nombre,Latitud,Longitud")] JuntaDeVecinos juntaDeVecinos)
        {
            if (id != juntaDeVecinos.JuntaDeVecinosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juntaDeVecinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuntaDeVecinosExists(juntaDeVecinos.JuntaDeVecinosId))
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
            ViewData["BarrioId"] = new SelectList(_context.Barrio, "BarrioId", "Nombre", juntaDeVecinos.BarrioId);
            return View(juntaDeVecinos);
        }

        // GET: JuntaDeVecinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juntaDeVecinos = await _context.JuntaDeVecinos
                .Include(j => j.Barrio)
                .FirstOrDefaultAsync(m => m.JuntaDeVecinosId == id);
            if (juntaDeVecinos == null)
            {
                return NotFound();
            }

            return View(juntaDeVecinos);
        }

        // POST: JuntaDeVecinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juntaDeVecinos = await _context.JuntaDeVecinos.FindAsync(id);
            _context.JuntaDeVecinos.Remove(juntaDeVecinos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuntaDeVecinosExists(int id)
        {
            return _context.JuntaDeVecinos.Any(e => e.JuntaDeVecinosId == id);
        }
    }
}
