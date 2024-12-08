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
    public class DyskiTwardesController : Controller
    {
        private readonly Builducpu1Context _context;

        public DyskiTwardesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: DyskiTwardes
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Sortowanie dla kolumn
            ViewData["ProducentSortParam"] = String.IsNullOrEmpty(sortOrder) ? "producent_desc" : "";
            ViewData["ModelSortParam"] = sortOrder == "model" ? "model_desc" : "model";
            ViewData["CenaSortParam"] = sortOrder == "cena" ? "cena_desc" : "cena";
            ViewData["DostepnoscSortParam"] = sortOrder == "dostepnosc" ? "dostepnosc_desc" : "dostepnosc";
            ViewData["GwarancjaSortParam"] = sortOrder == "gwarancja" ? "gwarancja_desc" : "gwarancja";
            ViewData["FunkcjeSortParam"] = sortOrder == "funkcje" ? "funkcje_desc" : "funkcje";

            var chlodzenia = from c in _context.DyskiTwardes.Include(c => c.KompatybilnoscNavigation)
                             select c;

            // Logika sortowania
            switch (sortOrder)
            {
                case "producent_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Producent);
                    break;
                case "model":
                    chlodzenia = chlodzenia.OrderBy(c => c.Model);
                    break;
                case "model_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Model);
                    break;
                case "cena":
                    chlodzenia = chlodzenia.OrderBy(c => c.Cena);
                    break;
                case "cena_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Cena);
                    break;
                case "dostepnosc":
                    chlodzenia = chlodzenia.OrderBy(c => c.Dostepnosc);
                    break;
                case "dostepnosc_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Dostepnosc);
                    break;
                case "gwarancja":
                    chlodzenia = chlodzenia.OrderBy(c => c.Gwarancja);
                    break;
                case "gwarancja_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Gwarancja);
                    break;
                case "funkcje":
                    chlodzenia = chlodzenia.OrderBy(c => c.DodatkoweFunkcje);
                    break;
                case "funkcje_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.DodatkoweFunkcje);
                    break;
                default:
                    chlodzenia = chlodzenia.OrderBy(c => c.Producent);
                    break;
            }

            return View(await chlodzenia.ToListAsync());
        }

        // GET: DyskiTwardes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dyskiTwarde = await _context.DyskiTwardes
                .Include(d => d.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (dyskiTwarde == null)
            {
                return NotFound();
            }

            return View(dyskiTwarde);
        }

        // GET: DyskiTwardes/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: DyskiTwardes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] DyskiTwarde dyskiTwarde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dyskiTwarde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", dyskiTwarde.KompatybilnoscId);
            return View(dyskiTwarde);
        }

        // GET: DyskiTwardes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dyskiTwarde = await _context.DyskiTwardes.FindAsync(id);
            if (dyskiTwarde == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", dyskiTwarde.KompatybilnoscId);
            return View(dyskiTwarde);
        }

        // POST: DyskiTwardes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Wydajnosc,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] DyskiTwarde dyskiTwarde)
        {
            if (id != dyskiTwarde.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dyskiTwarde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DyskiTwardeExists(dyskiTwarde.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", dyskiTwarde.KompatybilnoscId);
            return View(dyskiTwarde);
        }

        // GET: DyskiTwardes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dyskiTwarde = await _context.DyskiTwardes
                .Include(d => d.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (dyskiTwarde == null)
            {
                return NotFound();
            }

            return View(dyskiTwarde);
        }

        // POST: DyskiTwardes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dyskiTwarde = await _context.DyskiTwardes.FindAsync(id);
            if (dyskiTwarde != null)
            {
                _context.DyskiTwardes.Remove(dyskiTwarde);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DyskiTwardeExists(int id)
        {
            return _context.DyskiTwardes.Any(e => e.Nr == id);
        }
    }
}
