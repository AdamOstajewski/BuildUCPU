using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuildUCPU;

namespace BuildUCPU.Controllers
{
    public class ProcesoriesController : Controller
    {
        private readonly Builducpu1Context _context;

        public ProcesoriesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: Procesories
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.Procesories.Include(p => p.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: Procesories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesory = await _context.Procesories
                .Include(p => p.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (procesory == null)
            {
                return NotFound();
            }

            return View(procesory);
        }

        // GET: Procesories/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: Procesories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Procesory procesory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", procesory.KompatybilnoscId);
            return View(procesory);
        }

        // GET: Procesories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesory = await _context.Procesories.FindAsync(id);
            if (procesory == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", procesory.KompatybilnoscId);
            return View(procesory);
        }

        // POST: Procesories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Procesory procesory)
        {
            if (id != procesory.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesoryExists(procesory.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", procesory.KompatybilnoscId);
            return View(procesory);
        }

        // GET: Procesories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesory = await _context.Procesories
                .Include(p => p.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (procesory == null)
            {
                return NotFound();
            }

            return View(procesory);
        }

        // POST: Procesories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesory = await _context.Procesories.FindAsync(id);
            if (procesory != null)
            {
                _context.Procesories.Remove(procesory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesoryExists(int id)
        {
            return _context.Procesories.Any(e => e.Nr == id);
        }
    }
}
