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
    public class PamieciRamsController : Controller
    {
        private readonly Builducpu1Context _context;

        public PamieciRamsController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: PamieciRams
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.PamieciRams.Include(p => p.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: PamieciRams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pamieciRam = await _context.PamieciRams
                .Include(p => p.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (pamieciRam == null)
            {
                return NotFound();
            }

            return View(pamieciRam);
        }

        // GET: PamieciRams/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: PamieciRams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] PamieciRam pamieciRam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pamieciRam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", pamieciRam.KompatybilnoscId);
            return View(pamieciRam);
        }

        // GET: PamieciRams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pamieciRam = await _context.PamieciRams.FindAsync(id);
            if (pamieciRam == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", pamieciRam.KompatybilnoscId);
            return View(pamieciRam);
        }

        // POST: PamieciRams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] PamieciRam pamieciRam)
        {
            if (id != pamieciRam.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pamieciRam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PamieciRamExists(pamieciRam.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", pamieciRam.KompatybilnoscId);
            return View(pamieciRam);
        }

        // GET: PamieciRams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pamieciRam = await _context.PamieciRams
                .Include(p => p.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (pamieciRam == null)
            {
                return NotFound();
            }

            return View(pamieciRam);
        }

        // POST: PamieciRams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pamieciRam = await _context.PamieciRams.FindAsync(id);
            if (pamieciRam != null)
            {
                _context.PamieciRams.Remove(pamieciRam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PamieciRamExists(int id)
        {
            return _context.PamieciRams.Any(e => e.Nr == id);
        }
    }
}
