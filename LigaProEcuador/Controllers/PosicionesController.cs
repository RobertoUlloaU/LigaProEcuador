using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LigaProEcuador.Models;

namespace LigaProEcuador.Controllers
{
    public class PosicionesController : Controller
    {
        private readonly DBSqlServerLigaPro _context;

        public PosicionesController(DBSqlServerLigaPro context)
        {
            _context = context;
        }

        // GET: Posiciones
        public async Task<IActionResult> Index()
        {
            var dBSqlServerLigaPro = _context.Posicion.Include(p => p.Equipo);
            return View(await dBSqlServerLigaPro.ToListAsync());
        }

        // GET: Posiciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicion = await _context.Posicion
                .Include(p => p.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicion == null)
            {
                return NotFound();
            }

            return View(posicion);
        }

        // GET: Posiciones/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "Id", "Id");
            return View();
        }

        // POST: Posiciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipoId,PosicionActual,Puntos")] Posicion posicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "Id", "Id", posicion.EquipoId);
            return View(posicion);
        }

        // GET: Posiciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicion = await _context.Posicion.FindAsync(id);
            if (posicion == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "Id", "Id", posicion.EquipoId);
            return View(posicion);
        }

        // POST: Posiciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipoId,PosicionActual,Puntos")] Posicion posicion)
        {
            if (id != posicion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosicionExists(posicion.Id))
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
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "Id", "Id", posicion.EquipoId);
            return View(posicion);
        }

        // GET: Posiciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posicion = await _context.Posicion
                .Include(p => p.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posicion == null)
            {
                return NotFound();
            }

            return View(posicion);
        }

        // POST: Posiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posicion = await _context.Posicion.FindAsync(id);
            if (posicion != null)
            {
                _context.Posicion.Remove(posicion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PosicionExists(int id)
        {
            return _context.Posicion.Any(e => e.Id == id);
        }
    }
}
