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
    public class PlytyGlownesController : Controller
    {
        private readonly Builducpu1Context _context;

        public PlytyGlownesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: PlytyGlownes
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.PlytyGlownes.Include(p => p.KompatybilnoscNavigation);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: PlytyGlownes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plytyGlowne = await _context.PlytyGlownes
                .Include(p => p.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (plytyGlowne == null)
            {
                return NotFound();
            }

            return View(plytyGlowne);
        }

        // GET: PlytyGlownes/Create
        public IActionResult Create()
        {
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id");
            return View();
        }

        // POST: PlytyGlownes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Rozmiar,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] PlytyGlowne plytyGlowne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plytyGlowne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", plytyGlowne.KompatybilnoscId);
            return View(plytyGlowne);
        }

        // GET: PlytyGlownes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plytyGlowne = await _context.PlytyGlownes.FindAsync(id);
            if (plytyGlowne == null)
            {
                return NotFound();
            }
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", plytyGlowne.KompatybilnoscId);
            return View(plytyGlowne);
        }

        // POST: PlytyGlownes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,KompatybilnoscId,Producent,Model,Cena,Rozmiar,Kompatybilnosc,Dostepnosc,Gwarancja,DodatkoweFunkcje")] PlytyGlowne plytyGlowne)
        {
            if (id != plytyGlowne.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plytyGlowne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlytyGlowneExists(plytyGlowne.Nr))
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
            ViewData["KompatybilnoscId"] = new SelectList(_context.Kompatybilnoscs, "Id", "Id", plytyGlowne.KompatybilnoscId);
            return View(plytyGlowne);
        }

        // GET: PlytyGlownes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plytyGlowne = await _context.PlytyGlownes
                .Include(p => p.KompatybilnoscNavigation)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (plytyGlowne == null)
            {
                return NotFound();
            }

            return View(plytyGlowne);
        }

        // POST: PlytyGlownes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plytyGlowne = await _context.PlytyGlownes.FindAsync(id);
            if (plytyGlowne != null)
            {
                _context.PlytyGlownes.Remove(plytyGlowne);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlytyGlowneExists(int id)
        {
            return _context.PlytyGlownes.Any(e => e.Nr == id);
        }
    }
}
