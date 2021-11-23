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
    public class KonsumenController : Controller
    {
        private readonly ApotekContext _context;

        public KonsumenController(ApotekContext context)
        {
            _context = context;
        }

        // GET: Konsumen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Konsumen.ToListAsync());
        }

        // GET: Konsumen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konsumen = await _context.Konsumen
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (konsumen == null)
            {
                return NotFound();
            }

            return View(konsumen);
        }

        // GET: Konsumen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konsumen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembeli,PasswordPembei,UsernamePembeli")] Konsumen konsumen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konsumen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konsumen);
        }

        // GET: Konsumen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konsumen = await _context.Konsumen.FindAsync(id);
            if (konsumen == null)
            {
                return NotFound();
            }
            return View(konsumen);
        }

        // POST: Konsumen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembeli,PasswordPembei,UsernamePembeli")] Konsumen konsumen)
        {
            if (id != konsumen.IdPembeli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konsumen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonsumenExists(konsumen.IdPembeli))
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
            return View(konsumen);
        }

        // GET: Konsumen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konsumen = await _context.Konsumen
                .FirstOrDefaultAsync(m => m.IdPembeli == id);
            if (konsumen == null)
            {
                return NotFound();
            }

            return View(konsumen);
        }

        // POST: Konsumen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konsumen = await _context.Konsumen.FindAsync(id);
            _context.Konsumen.Remove(konsumen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonsumenExists(int id)
        {
            return _context.Konsumen.Any(e => e.IdPembeli == id);
        }
    }
}
