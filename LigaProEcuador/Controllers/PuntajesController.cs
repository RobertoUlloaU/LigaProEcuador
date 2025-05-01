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
    public class PuntajesController : Controller
    {
        private readonly DBSqlServerLigaPro _context;

        public PuntajesController(DBSqlServerLigaPro context)
        {
            _context = context;
        }

        // GET: Puntajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Puntaje.ToListAsync());
        }

        // GET: Puntajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntaje = await _context.Puntaje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puntaje == null)
            {
                return NotFound();
            }

            return View(puntaje);
        }

        // GET: Puntajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puntajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartidosGanados,PartidosEmpatados")] Puntaje puntaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puntaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puntaje);
        }

        // GET: Puntajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntaje = await _context.Puntaje.FindAsync(id);
            if (puntaje == null)
            {
                return NotFound();
            }
            return View(puntaje);
        }

        // POST: Puntajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartidosGanados,PartidosEmpatados")] Puntaje puntaje)
        {
            if (id != puntaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puntaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuntajeExists(puntaje.Id))
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
            return View(puntaje);
        }

        // GET: Puntajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntaje = await _context.Puntaje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puntaje == null)
            {
                return NotFound();
            }

            return View(puntaje);
        }

        // POST: Puntajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puntaje = await _context.Puntaje.FindAsync(id);
            if (puntaje != null)
            {
                _context.Puntaje.Remove(puntaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuntajeExists(int id)
        {
            return _context.Puntaje.Any(e => e.Id == id);
        }
    }
}
