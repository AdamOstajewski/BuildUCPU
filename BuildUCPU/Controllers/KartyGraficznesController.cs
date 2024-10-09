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
    public class KartyGraficznesController : Controller
    {
        private readonly Builducpu1Context _context;

        public KartyGraficznesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: KartyGraficznes
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.KartyGraficznes.Include(k => k.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: KartyGraficznes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartyGraficzne = await _context.KartyGraficznes
                .Include(k => k.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (kartyGraficzne == null)
            {
                return NotFound();
            }

            return View(kartyGraficzne);
        }

        // GET: KartyGraficznes/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: KartyGraficznes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] KartyGraficzne kartyGraficzne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kartyGraficzne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", kartyGraficzne.KompatybilnoscId);
            return View(kartyGraficzne);
        }

        // GET: KartyGraficznes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartyGraficzne = await _context.KartyGraficznes.FindAsync(id);
            if (kartyGraficzne == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", kartyGraficzne.KompatybilnoscId);
            return View(kartyGraficzne);
        }

        // POST: KartyGraficznes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] KartyGraficzne kartyGraficzne)
        {
            if (id != kartyGraficzne.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kartyGraficzne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartyGraficzneExists(kartyGraficzne.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", kartyGraficzne.KompatybilnoscId);
            return View(kartyGraficzne);
        }

        // GET: KartyGraficznes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartyGraficzne = await _context.KartyGraficznes
                .Include(k => k.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (kartyGraficzne == null)
            {
                return NotFound();
            }

            return View(kartyGraficzne);
        }

        // POST: KartyGraficznes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kartyGraficzne = await _context.KartyGraficznes.FindAsync(id);
            if (kartyGraficzne != null)
            {
                _context.KartyGraficznes.Remove(kartyGraficzne);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartyGraficzneExists(int id)
        {
            return _context.KartyGraficznes.Any(e => e.Nr == id);
        }
    }
}
