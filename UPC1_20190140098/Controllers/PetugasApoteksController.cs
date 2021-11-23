using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UPC1_20190140098.Models;

namespace UPC1_20190140098.Controllers
{
    public class PetugasApoteksController : Controller
    {
        private readonly ApotekContext _context;

        public PetugasApoteksController(ApotekContext context)
        {
            _context = context;
        }

        // GET: PetugasApoteks
        public async Task<IActionResult> Index()
        {
            var apotekContext = _context.PetugasApotek.Include(p => p.IdObatNavigation).Include(p => p.IdPembeliNavigation);
            return View(await apotekContext.ToListAsync());
        }

        // GET: PetugasApoteks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petugasApotek = await _context.PetugasApotek
                .Include(p => p.IdObatNavigation)
                .Include(p => p.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdApoteker == id);
            if (petugasApotek == null)
            {
                return NotFound();
            }

            return View(petugasApotek);
        }

        // GET: PetugasApoteks/Create
        public IActionResult Create()
        {
            ViewData["IdObat"] = new SelectList(_context.TabelObat, "IdObat", "IdObat");
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli");
            return View();
        }

        // POST: PetugasApoteks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdApoteker,Password,Username,IdObat,IdPembeli")] PetugasApotek petugasApotek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petugasApotek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdObat"] = new SelectList(_context.TabelObat, "IdObat", "IdObat", petugasApotek.IdObat);
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli", petugasApotek.IdPembeli);
            return View(petugasApotek);
        }

        // GET: PetugasApoteks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petugasApotek = await _context.PetugasApotek.FindAsync(id);
            if (petugasApotek == null)
            {
                return NotFound();
            }
            ViewData["IdObat"] = new SelectList(_context.TabelObat, "IdObat", "IdObat", petugasApotek.IdObat);
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli", petugasApotek.IdPembeli);
            return View(petugasApotek);
        }

        // POST: PetugasApoteks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdApoteker,Password,Username,IdObat,IdPembeli")] PetugasApotek petugasApotek)
        {
            if (id != petugasApotek.IdApoteker)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petugasApotek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetugasApotekExists(petugasApotek.IdApoteker))
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
            ViewData["IdObat"] = new SelectList(_context.TabelObat, "IdObat", "IdObat", petugasApotek.IdObat);
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli", petugasApotek.IdPembeli);
            return View(petugasApotek);
        }

        // GET: PetugasApoteks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petugasApotek = await _context.PetugasApotek
                .Include(p => p.IdObatNavigation)
                .Include(p => p.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdApoteker == id);
            if (petugasApotek == null)
            {
                return NotFound();
            }

            return View(petugasApotek);
        }

        // POST: PetugasApoteks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petugasApotek = await _context.PetugasApotek.FindAsync(id);
            _context.PetugasApotek.Remove(petugasApotek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetugasApotekExists(int id)
        {
            return _context.PetugasApotek.Any(e => e.IdApoteker == id);
        }
    }
}
