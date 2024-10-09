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
    public class ZasilaczesController : Controller
    {
        private readonly Builducpu1Context _context;

        public ZasilaczesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: Zasilaczes
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.Zasilaczes.Include(z => z.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: Zasilaczes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zasilacze = await _context.Zasilaczes
                .Include(z => z.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (zasilacze == null)
            {
                return NotFound();
            }

            return View(zasilacze);
        }

        // GET: Zasilaczes/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: Zasilaczes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Zasilacze zasilacze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zasilacze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", zasilacze.KompatybilnoscId);
            return View(zasilacze);
        }

        // GET: Zasilaczes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zasilacze = await _context.Zasilaczes.FindAsync(id);
            if (zasilacze == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", zasilacze.KompatybilnoscId);
            return View(zasilacze);
        }

        // POST: Zasilaczes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Zasilacze zasilacze)
        {
            if (id != zasilacze.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zasilacze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZasilaczeExists(zasilacze.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", zasilacze.KompatybilnoscId);
            return View(zasilacze);
        }

        // GET: Zasilaczes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zasilacze = await _context.Zasilaczes
                .Include(z => z.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (zasilacze == null)
            {
                return NotFound();
            }

            return View(zasilacze);
        }

        // POST: Zasilaczes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zasilacze = await _context.Zasilaczes.FindAsync(id);
            if (zasilacze != null)
            {
                _context.Zasilaczes.Remove(zasilacze);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZasilaczeExists(int id)
        {
            return _context.Zasilaczes.Any(e => e.Nr == id);
        }
    }
}
