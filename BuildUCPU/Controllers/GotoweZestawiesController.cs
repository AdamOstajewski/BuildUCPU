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
    public class GotoweZestawiesController : Controller
    {
        private readonly Builducpu1Context _context;

        public GotoweZestawiesController(Builducpu1Context context)
        {
            _context = context;
        }

        // GET: GotoweZestawies
        public async Task<IActionResult> Index()
        {
            var builducpu1Context = _context.GotoweZestawies.Include(g => g.Chlodzenie).Include(g => g.DyskiTwarde).Include(g => g.KartyGraficzne).Include(g => g.Obudowy).Include(g => g.PamieciRam).Include(g => g.PlytyGlowne).Include(g => g.Procesory).Include(g => g.Zasilacze);
            return View(await builducpu1Context.ToListAsync());
        }

        // GET: GotoweZestawies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gotoweZestawy = await _context.GotoweZestawies
                .Include(g => g.Chlodzenie)
                .Include(g => g.DyskiTwarde)
                .Include(g => g.KartyGraficzne)
                .Include(g => g.Obudowy)
                .Include(g => g.PamieciRam)
                .Include(g => g.PlytyGlowne)
                .Include(g => g.Procesory)
                .Include(g => g.Zasilacze)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (gotoweZestawy == null)
            {
                return NotFound();
            }

            return View(gotoweZestawy);
        }

        // GET: GotoweZestawies/Create
        public IActionResult Create()
        {
            ViewData["ChlodzenieId"] = new SelectList(_context.Chlodzenies, "Nr", "Nr");
            ViewData["DyskiTwardeId"] = new SelectList(_context.DyskiTwardes, "Nr", "Nr");
            ViewData["KartyGraficzneId"] = new SelectList(_context.KartyGraficznes, "Nr", "Nr");
            ViewData["ObudowyId"] = new SelectList(_context.Obudowies, "Nr", "Nr");
            ViewData["PamieciRamId"] = new SelectList(_context.PamieciRams, "Nr", "Nr");
            ViewData["PlytyGlowneId"] = new SelectList(_context.PlytyGlownes, "Nr", "Nr");
            ViewData["ProcesoryId"] = new SelectList(_context.Procesories, "Nr", "Nr");
            ViewData["ZasilaczeId"] = new SelectList(_context.Zasilaczes, "Nr", "Nr");
            return View();
        }

        // POST: GotoweZestawies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr,Sekcja,ChlodzenieId,DyskiTwardeId,KartyGraficzneId,ObudowyId,PamieciRamId,PlytyGlowneId,ProcesoryId,ZasilaczeId")] GotoweZestawy gotoweZestawy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gotoweZestawy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChlodzenieId"] = new SelectList(_context.Chlodzenies, "Nr", "Nr", gotoweZestawy.ChlodzenieId);
            ViewData["DyskiTwardeId"] = new SelectList(_context.DyskiTwardes, "Nr", "Nr", gotoweZestawy.DyskiTwardeId);
            ViewData["KartyGraficzneId"] = new SelectList(_context.KartyGraficznes, "Nr", "Nr", gotoweZestawy.KartyGraficzneId);
            ViewData["ObudowyId"] = new SelectList(_context.Obudowies, "Nr", "Nr", gotoweZestawy.ObudowyId);
            ViewData["PamieciRamId"] = new SelectList(_context.PamieciRams, "Nr", "Nr", gotoweZestawy.PamieciRamId);
            ViewData["PlytyGlowneId"] = new SelectList(_context.PlytyGlownes, "Nr", "Nr", gotoweZestawy.PlytyGlowneId);
            ViewData["ProcesoryId"] = new SelectList(_context.Procesories, "Nr", "Nr", gotoweZestawy.ProcesoryId);
            ViewData["ZasilaczeId"] = new SelectList(_context.Zasilaczes, "Nr", "Nr", gotoweZestawy.ZasilaczeId);
            return View(gotoweZestawy);
        }

        // GET: GotoweZestawies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gotoweZestawy = await _context.GotoweZestawies.FindAsync(id);
            if (gotoweZestawy == null)
            {
                return NotFound();
            }
            ViewData["ChlodzenieId"] = new SelectList(_context.Chlodzenies, "Nr", "Nr", gotoweZestawy.ChlodzenieId);
            ViewData["DyskiTwardeId"] = new SelectList(_context.DyskiTwardes, "Nr", "Nr", gotoweZestawy.DyskiTwardeId);
            ViewData["KartyGraficzneId"] = new SelectList(_context.KartyGraficznes, "Nr", "Nr", gotoweZestawy.KartyGraficzneId);
            ViewData["ObudowyId"] = new SelectList(_context.Obudowies, "Nr", "Nr", gotoweZestawy.ObudowyId);
            ViewData["PamieciRamId"] = new SelectList(_context.PamieciRams, "Nr", "Nr", gotoweZestawy.PamieciRamId);
            ViewData["PlytyGlowneId"] = new SelectList(_context.PlytyGlownes, "Nr", "Nr", gotoweZestawy.PlytyGlowneId);
            ViewData["ProcesoryId"] = new SelectList(_context.Procesories, "Nr", "Nr", gotoweZestawy.ProcesoryId);
            ViewData["ZasilaczeId"] = new SelectList(_context.Zasilaczes, "Nr", "Nr", gotoweZestawy.ZasilaczeId);
            return View(gotoweZestawy);
        }

        // POST: GotoweZestawies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nr,Sekcja,ChlodzenieId,DyskiTwardeId,KartyGraficzneId,ObudowyId,PamieciRamId,PlytyGlowneId,ProcesoryId,ZasilaczeId")] GotoweZestawy gotoweZestawy)
        {
            if (id != gotoweZestawy.Nr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gotoweZestawy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GotoweZestawyExists(gotoweZestawy.Nr))
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
            ViewData["ChlodzenieId"] = new SelectList(_context.Chlodzenies, "Nr", "Nr", gotoweZestawy.ChlodzenieId);
            ViewData["DyskiTwardeId"] = new SelectList(_context.DyskiTwardes, "Nr", "Nr", gotoweZestawy.DyskiTwardeId);
            ViewData["KartyGraficzneId"] = new SelectList(_context.KartyGraficznes, "Nr", "Nr", gotoweZestawy.KartyGraficzneId);
            ViewData["ObudowyId"] = new SelectList(_context.Obudowies, "Nr", "Nr", gotoweZestawy.ObudowyId);
            ViewData["PamieciRamId"] = new SelectList(_context.PamieciRams, "Nr", "Nr", gotoweZestawy.PamieciRamId);
            ViewData["PlytyGlowneId"] = new SelectList(_context.PlytyGlownes, "Nr", "Nr", gotoweZestawy.PlytyGlowneId);
            ViewData["ProcesoryId"] = new SelectList(_context.Procesories, "Nr", "Nr", gotoweZestawy.ProcesoryId);
            ViewData["ZasilaczeId"] = new SelectList(_context.Zasilaczes, "Nr", "Nr", gotoweZestawy.ZasilaczeId);
            return View(gotoweZestawy);
        }

        // GET: GotoweZestawies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gotoweZestawy = await _context.GotoweZestawies
                .Include(g => g.Chlodzenie)
                .Include(g => g.DyskiTwarde)
                .Include(g => g.KartyGraficzne)
                .Include(g => g.Obudowy)
                .Include(g => g.PamieciRam)
                .Include(g => g.PlytyGlowne)
                .Include(g => g.Procesory)
                .Include(g => g.Zasilacze)
                .FirstOrDefaultAsync(m => m.Nr == id);
            if (gotoweZestawy == null)
            {
                return NotFound();
            }

            return View(gotoweZestawy);
        }

        // POST: GotoweZestawies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gotoweZestawy = await _context.GotoweZestawies.FindAsync(id);
            if (gotoweZestawy != null)
            {
                _context.GotoweZestawies.Remove(gotoweZestawy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GotoweZestawyExists(int id)
        {
            return _context.GotoweZestawies.Any(e => e.Nr == id);
        }
    }
}
