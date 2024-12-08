using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuildUCPU;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index(string sortOrder)
        {
            // Sortowanie dla kolumn
            ViewData["ProducentSortParam"] = String.IsNullOrEmpty(sortOrder) ? "producent_desc" : "";
            ViewData["ModelSortParam"] = sortOrder == "model" ? "model_desc" : "model";
            ViewData["CenaSortParam"] = sortOrder == "cena" ? "cena_desc" : "cena";
            ViewData["DostepnoscSortParam"] = sortOrder == "dostepnosc" ? "dostepnosc_desc" : "dostepnosc";
            ViewData["GwarancjaSortParam"] = sortOrder == "gwarancja" ? "gwarancja_desc" : "gwarancja";
            ViewData["FunkcjeSortParam"] = sortOrder == "funkcje" ? "funkcje_desc" : "funkcje";

            var chlodzenia = from c in _context.Chlodzenies.Include(c => c.KompatybilnoscNavigation)
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

        // Pozostałe metody kontrolera są takie same
        // (Details, Create, Edit, Delete)
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

        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

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
    }
}


