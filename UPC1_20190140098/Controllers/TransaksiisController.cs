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
    public class TransaksiisController : Controller
    {
        private readonly ApotekContext _context;

        public TransaksiisController(ApotekContext context)
        {
            _context = context;
        }

        // GET: Transaksiis
        public async Task<IActionResult> Index()
        {
            var apotekContext = _context.Transaksii.Include(t => t.IdPembeliNavigation);
            return View(await apotekContext.ToListAsync());
        }

        // GET: Transaksiis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksii
                .Include(t => t.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksii == id);
            if (transaksii == null)
            {
                return NotFound();
            }

            return View(transaksii);
        }

        // GET: Transaksiis/Create
        public IActionResult Create()
        {
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli");
            return View();
        }

        // POST: Transaksiis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksii,IdObat,IdPembeli,TglTransaksi,TotalHarga")] Transaksii transaksii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli", transaksii.IdPembeli);
            return View(transaksii);
        }

        // GET: Transaksiis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksii.FindAsync(id);
            if (transaksii == null)
            {
                return NotFound();
            }
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli", transaksii.IdPembeli);
            return View(transaksii);
        }

        // POST: Transaksiis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksii,IdObat,IdPembeli,TglTransaksi,TotalHarga")] Transaksii transaksii)
        {
            if (id != transaksii.IdTransaksii)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksii);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiiExists(transaksii.IdTransaksii))
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
            ViewData["IdPembeli"] = new SelectList(_context.Konsumen, "IdPembeli", "IdPembeli", transaksii.IdPembeli);
            return View(transaksii);
        }

        // GET: Transaksiis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksii
                .Include(t => t.IdPembeliNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksii == id);
            if (transaksii == null)
            {
                return NotFound();
            }

            return View(transaksii);
        }

        // POST: Transaksiis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksii = await _context.Transaksii.FindAsync(id);
            _context.Transaksii.Remove(transaksii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiiExists(int id)
        {
            return _context.Transaksii.Any(e => e.IdTransaksii == id);
        }
    }
}
