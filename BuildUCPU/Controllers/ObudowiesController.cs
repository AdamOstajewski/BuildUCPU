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
    public class ObudowiesController : Controller
    {
        private readonly Builducpu1Context _context;

        public ObudowiesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: Obudowies
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.Obudowies.Include(o => o.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: Obudowies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obudowy = await _context.Obudowies
                .Include(o => o.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (obudowy == null)
            {
                return NotFound();
            }

            return View(obudowy);
        }

        // GET: Obudowies/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: Obudowies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Obudowy obudowy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obudowy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", obudowy.KompatybilnoscId);
            return View(obudowy);
        }

        // GET: Obudowies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obudowy = await _context.Obudowies.FindAsync(id);
            if (obudowy == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", obudowy.KompatybilnoscId);
            return View(obudowy);
        }

        // POST: Obudowies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] Obudowy obudowy)
        {
            if (id != obudowy.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obudowy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObudowyExists(obudowy.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", obudowy.KompatybilnoscId);
            return View(obudowy);
        }

        // GET: Obudowies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obudowy = await _context.Obudowies
                .Include(o => o.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (obudowy == null)
            {
                return NotFound();
            }

            return View(obudowy);
        }

        // POST: Obudowies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obudowy = await _context.Obudowies.FindAsync(id);
            if (obudowy != null)
            {
                _context.Obudowies.Remove(obudowy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObudowyExists(int id)
        {
            return _context.Obudowies.Any(e => e.Nr == id);
        }
    }
}
