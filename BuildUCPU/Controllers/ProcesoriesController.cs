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

            var chlodzenia = from c in _context.Procesories.Include(c => c.KompatybilnoscNavigation)
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
