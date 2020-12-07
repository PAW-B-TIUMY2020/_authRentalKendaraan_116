using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_116.Models;

namespace RentalKendaraan_116.Controllers
{
    public class CostumersController : Controller
    {
        private readonly RentalKendaraanContext _context;

        public CostumersController(RentalKendaraanContext context)
        {
            _context = context;
        }

        // GET: Costumers
        public async Task<IActionResult> Index(string ktsd, string searchString, string sortOrder, string currentFilter, int? pageNumbe)
        {
            var rentalKendaraanContext = _context.Costumer.Include(c => c.IdGenderNavigation);
            return View(await rentalKendaraanContext.ToListAsync());
        }

        // GET: Costumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumer
                .Include(c => c.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCostumer == id);
            if (costumer == null)
            {
                return NotFound();
            }

            return View(costumer);
        }

        // GET: Costumers/Create
        public IActionResult Create()
        {
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender");
            return View();
        }

        // POST: Costumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCostumer,NamaCostumer,Nik,Alamat,NoHp,IdGender")] Costumer costumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", costumer.IdGender);
            return View(costumer);
        }

        // GET: Costumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumer.FindAsync(id);
            if (costumer == null)
            {
                return NotFound();
            }
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", costumer.IdGender);
            return View(costumer);
        }

        // POST: Costumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCostumer,NamaCostumer,Nik,Alamat,NoHp,IdGender")] Costumer costumer)
        {
            if (id != costumer.IdCostumer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostumerExists(costumer.IdCostumer))
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
            ViewData["IdGender"] = new SelectList(_context.Gender, "IdGender", "IdGender", costumer.IdGender);
            return View(costumer);
        }

        // GET: Costumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumer
                .Include(c => c.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCostumer == id);
            if (costumer == null)
            {
                return NotFound();
            }

            return View(costumer);
        }

        // POST: Costumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costumer = await _context.Costumer.FindAsync(id);
            _context.Costumer.Remove(costumer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostumerExists(int id)
        {
            return _context.Costumer.Any(e => e.IdCostumer == id);
        }
    }
}
