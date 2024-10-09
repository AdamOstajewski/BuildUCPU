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
    public class ChlodzeniesController : Controller
    {
        private readonly Builducpu1Context _context;

        public ChlodzeniesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: Chlodzenies
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.Chlodzenies.Include(c => c.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: Chlodzenies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chlodzenie = await _context.Chlodzenies
                .Include(c => c.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (chlodzenie == null)
            {
                return NotFound();
            }

            return View(chlodzenie);
        }

        // GET: Chlodzenies/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: Chlodzenies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Chlodzenie chlodzenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chlodzenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", chlodzenie.KompatybilnoscId);
            return View(chlodzenie);
        }

        // GET: Chlodzenies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chlodzenie = await _context.Chlodzenies.FindAsync(id);
            if (chlodzenie == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", chlodzenie.KompatybilnoscId);
            return View(chlodzenie);
        }

        // POST: Chlodzenies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Chlodzenie chlodzenie)
        {
            if (id != chlodzenie.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chlodzenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChlodzenieExists(chlodzenie.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", chlodzenie.KompatybilnoscId);
            return View(chlodzenie);
        }

        // GET: Chlodzenies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chlodzenie = await _context.Chlodzenies
                .Include(c => c.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (chlodzenie == null)
            {
                return NotFound();
            }

            return View(chlodzenie);
        }

        // POST: Chlodzenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chlodzenie = await _context.Chlodzenies.FindAsync(id);
            if (chlodzenie != null)
            {
                _context.Chlodzenies.Remove(chlodzenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChlodzenieExists(int id)
        {
            return _context.Chlodzenies.Any(e => e.Nr == id);
        }
    }
}
