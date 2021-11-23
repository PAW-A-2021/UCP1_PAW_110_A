using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_110.Models;

namespace UCP1_PAW_110.Controllers
{
    public class TransaksiisController : Controller
    {
        private readonly OnlineMartContext _context;

        public TransaksiisController(OnlineMartContext context)
        {
            _context = context;
        }

        // GET: Transaksiis
        public async Task<IActionResult> Index()
        {
            var onlineMartContext = _context.Transaksiis.Include(t => t.IdAdminNavigation).Include(t => t.IdBarangNavigation).Include(t => t.IdCostumerNavigation);
            return View(await onlineMartContext.ToListAsync());
        }

        // GET: Transaksiis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksiis
                .Include(t => t.IdAdminNavigation)
                .Include(t => t.IdBarangNavigation)
                .Include(t => t.IdCostumerNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksii == null)
            {
                return NotFound();
            }

            return View(transaksii);
        }

        // GET: Transaksiis/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin");
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang");
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "IdCostumer", "IdCostumer");
            return View();
        }

        // POST: Transaksiis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,IdAdmin,IdBarang,IdCostumer,Bayar,Total,Kembalian,Tanggal")] Transaksii transaksii)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksii);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", transaksii.IdAdmin);
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang", transaksii.IdBarang);
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "IdCostumer", "IdCostumer", transaksii.IdCostumer);
            return View(transaksii);
        }

        // GET: Transaksiis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksiis.FindAsync(id);
            if (transaksii == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", transaksii.IdAdmin);
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang", transaksii.IdBarang);
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "IdCostumer", "IdCostumer", transaksii.IdCostumer);
            return View(transaksii);
        }

        // POST: Transaksiis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdTransaksi,IdAdmin,IdBarang,IdCostumer,Bayar,Total,Kembalian,Tanggal")] Transaksii transaksii)
        {
            if (id != transaksii.IdTransaksi)
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
                    if (!TransaksiiExists(transaksii.IdTransaksi))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", transaksii.IdAdmin);
            ViewData["IdBarang"] = new SelectList(_context.Barangs, "IdBarang", "IdBarang", transaksii.IdBarang);
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "IdCostumer", "IdCostumer", transaksii.IdCostumer);
            return View(transaksii);
        }

        // GET: Transaksiis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksii = await _context.Transaksiis
                .Include(t => t.IdAdminNavigation)
                .Include(t => t.IdBarangNavigation)
                .Include(t => t.IdCostumerNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksii == null)
            {
                return NotFound();
            }

            return View(transaksii);
        }

        // POST: Transaksiis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transaksii = await _context.Transaksiis.FindAsync(id);
            _context.Transaksiis.Remove(transaksii);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiiExists(string id)
        {
            return _context.Transaksiis.Any(e => e.IdTransaksi == id);
        }
    }
}
