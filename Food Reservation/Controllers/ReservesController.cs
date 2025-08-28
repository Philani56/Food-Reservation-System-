using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Food_Reservation.Data;
using Food_Reservation.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Food_Reservation.Controllers
{
    public class ReservesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reserves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reserves.ToListAsync());
        }

        // GET: Reserves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves
                .FirstOrDefaultAsync(m => m.ReserveId == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // GET: Reserves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReserveId,CustomerName,CustomerEmail,CustomerPhone,ReservationDate,Status")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserve);
                await _context.SaveChangesAsync();

                // ✅ Redirect to a confirmation view instead of looping back to Create
                return RedirectToAction(nameof(Confirmation), new { id = reserve.ReserveId });
            }
            return View(reserve);
        }

        public async Task<IActionResult> Confirmation(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null) return NotFound();

            return View(reserve); // Create a Confirmation.cshtml
        }



        // GET: Reserves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveId,CustomerName,CustomerEmail,CustomerPhone,ReservationDate,Status")] Reserve reserve)
        {
            if (id != reserve.ReserveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveExists(reserve.ReserveId))
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
            return View(reserve);
        }

        // GET: Reserves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves
                .FirstOrDefaultAsync(m => m.ReserveId == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // POST: Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve != null)
            {
                _context.Reserves.Remove(reserve);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveExists(int id)
        {
            return _context.Reserves.Any(e => e.ReserveId == id);
        }

        // GET: Reserves/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Reserves/Search
        [HttpPost]
        public async Task<IActionResult> Search(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                ViewBag.ErrorMessage = "Please enter your name to search for reservations.";
                return View();
            }

            var reservations = await _context.Reserves
                .Where(r => r.CustomerName.ToLower().Contains(customerName.ToLower()))
                .ToListAsync();

            if (reservations == null || reservations.Count == 0)
            {
                ViewBag.ErrorMessage = "No reservations found under that name.";
                return View();
            }

            return View("SearchResults", reservations);
        }
    }
}
