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
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Sortowanie dla kolumn
            ViewData["ProducentSortParam"] = String.IsNullOrEmpty(sortOrder) ? "producent_desc" : "";
            ViewData["ModelSortParam"] = sortOrder == "model" ? "model_desc" : "model";
            ViewData["CenaSortParam"] = sortOrder == "cena" ? "cena_desc" : "cena";
            ViewData["WydajnoscSortParam"] = sortOrder == "wydajnosc" ? "wydajnosc_desc" : "wydajnosc";
            ViewData["KompatybilnoscSortParam"] = sortOrder == "kompatybilnosc" ? "kompatybilnosc_desc" : "kompatybilnosc";
            ViewData["DostepnoscSortParam"] = sortOrder == "dostepnosc" ? "dostepnosc_desc" : "dostepnosc";
            ViewData["GwarancjaSortParam"] = sortOrder == "gwarancja" ? "gwarancja_desc" : "gwarancja";
            ViewData["FunkcjeSortParam"] = sortOrder == "funkcje" ? "funkcje_desc" : "funkcje";

            var chlodzenia = from c in _context.Zasilaczes.Include(c => c.KompatybilnoscNavigation)
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
                case "kompatybilnosc":
                    chlodzenia = chlodzenia.OrderBy(c => c.Kompatybilnosc);
                    break;
                case "kompatybilnosc_desc":
                    chlodzenia = chlodzenia.OrderByDescending(c => c.Kompatybilnosc);
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
