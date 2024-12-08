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
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Sortowanie dla kolumn
            ViewData["ProducentSortParam"] = String.IsNullOrEmpty(sortOrder) ? "producent_desc" : "";
            ViewData["ModelSortParam"] = sortOrder == "model" ? "model_desc" : "model";
            ViewData["CenaSortParam"] = sortOrder == "cena" ? "cena_desc" : "cena";
            ViewData["WydajnoscSortParam"] = sortOrder == "wydajnosc" ? "wydajnosc_desc" : "wydajnosc";
            ViewData["DostepnoscSortParam"] = sortOrder == "dostepnosc" ? "dostepnosc_desc" : "dostepnosc";
            ViewData["GwarancjaSortParam"] = sortOrder == "gwarancja" ? "gwarancja_desc" : "gwarancja";
            ViewData["FunkcjeSortParam"] = sortOrder == "funkcje" ? "funkcje_desc" : "funkcje";

            var chlodzenia = from c in _context.KartyGraficznes.Include(c => c.KompatybilnoscNavigation)
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
                case "wydajnosc":
                    chlodzenia = chlodzenia.OrderBy(c => c.Wydajnosc);
                    break;
                case "wydajnosc_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Wydajnosc);
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
