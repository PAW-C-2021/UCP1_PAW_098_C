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
    public class TableNotasController : Controller
    {
        private readonly ApotekContext _context;

        public TableNotasController(ApotekContext context)
        {
            _context = context;
        }

        // GET: TableNotas
        public async Task<IActionResult> Index()
        {
            var apotekContext = _context.TableNota.Include(t => t.IdNotaNavigation).Include(t => t.IdTransaksiNavigation);
            return View(await apotekContext.ToListAsync());
        }

        // GET: TableNotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableNota = await _context.TableNota
                .Include(t => t.IdNotaNavigation)
                .Include(t => t.IdTransaksiNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (tableNota == null)
            {
                return NotFound();
            }

            return View(tableNota);
        }

        // GET: TableNotas/Create
        public IActionResult Create()
        {
            ViewData["IdNota"] = new SelectList(_context.TabelTransaksi, "IdNota", "IdNota");
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksii, "IdTransaksii", "IdTransaksii");
            return View();
        }

        // POST: TableNotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNota,IdTransaksi,TotalHarga")] TableNota tableNota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNota"] = new SelectList(_context.TabelTransaksi, "IdNota", "IdNota", tableNota.IdNota);
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksii, "IdTransaksii", "IdTransaksii", tableNota.IdTransaksi);
            return View(tableNota);
        }

        // GET: TableNotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableNota = await _context.TableNota.FindAsync(id);
            if (tableNota == null)
            {
                return NotFound();
            }
            ViewData["IdNota"] = new SelectList(_context.TabelTransaksi, "IdNota", "IdNota", tableNota.IdNota);
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksii, "IdTransaksii", "IdTransaksii", tableNota.IdTransaksi);
            return View(tableNota);
        }

        // POST: TableNotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,IdTransaksi,TotalHarga")] TableNota tableNota)
        {
            if (id != tableNota.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableNota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableNotaExists(tableNota.IdNota))
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
            ViewData["IdNota"] = new SelectList(_context.TabelTransaksi, "IdNota", "IdNota", tableNota.IdNota);
            ViewData["IdTransaksi"] = new SelectList(_context.Transaksii, "IdTransaksii", "IdTransaksii", tableNota.IdTransaksi);
            return View(tableNota);
        }

        // GET: TableNotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableNota = await _context.TableNota
                .Include(t => t.IdNotaNavigation)
                .Include(t => t.IdTransaksiNavigation)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (tableNota == null)
            {
                return NotFound();
            }

            return View(tableNota);
        }

        // POST: TableNotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableNota = await _context.TableNota.FindAsync(id);
            _context.TableNota.Remove(tableNota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableNotaExists(int id)
        {
            return _context.TableNota.Any(e => e.IdNota == id);
        }
    }
}
