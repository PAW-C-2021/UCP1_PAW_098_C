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
    public class TabelObatsController : Controller
    {
        private readonly ApotekContext _context;

        public TabelObatsController(ApotekContext context)
        {
            _context = context;
        }

        // GET: TabelObats
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabelObat.ToListAsync());
        }

        // GET: TabelObats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelObat = await _context.TabelObat
                .FirstOrDefaultAsync(m => m.IdObat == id);
            if (tabelObat == null)
            {
                return NotFound();
            }

            return View(tabelObat);
        }

        // GET: TabelObats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabelObats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObat,Harga,JenisObat,NamaObat,Quantity")] TabelObat tabelObat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelObat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelObat);
        }

        // GET: TabelObats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelObat = await _context.TabelObat.FindAsync(id);
            if (tabelObat == null)
            {
                return NotFound();
            }
            return View(tabelObat);
        }

        // POST: TabelObats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObat,Harga,JenisObat,NamaObat,Quantity")] TabelObat tabelObat)
        {
            if (id != tabelObat.IdObat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelObat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelObatExists(tabelObat.IdObat))
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
            return View(tabelObat);
        }

        // GET: TabelObats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelObat = await _context.TabelObat
                .FirstOrDefaultAsync(m => m.IdObat == id);
            if (tabelObat == null)
            {
                return NotFound();
            }

            return View(tabelObat);
        }

        // POST: TabelObats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelObat = await _context.TabelObat.FindAsync(id);
            _context.TabelObat.Remove(tabelObat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelObatExists(int id)
        {
            return _context.TabelObat.Any(e => e.IdObat == id);
        }
    }
}
