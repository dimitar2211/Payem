using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payem.Data;
using Payem.Models;

namespace Payem.Controllers
{
    public class PaymentListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentList.ToListAsync());
        }

        // GET: PaymentLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentList = await _context.PaymentList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentList == null)
            {
                return NotFound();
            }

            return View(paymentList);
        }

        // GET: PaymentLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TotalAmount")] PaymentList paymentList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentList);
        }

        // GET: PaymentLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentList = await _context.PaymentList.FindAsync(id);
            if (paymentList == null)
            {
                return NotFound();
            }
            return View(paymentList);
        }

        // POST: PaymentLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TotalAmount")] PaymentList paymentList)
        {
            if (id != paymentList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentListExists(paymentList.Id))
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
            return View(paymentList);
        }

        // GET: PaymentLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentList = await _context.PaymentList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentList == null)
            {
                return NotFound();
            }

            return View(paymentList);
        }

        // POST: PaymentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentList = await _context.PaymentList.FindAsync(id);
            if (paymentList != null)
            {
                _context.PaymentList.Remove(paymentList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentListExists(int id)
        {
            return _context.PaymentList.Any(e => e.Id == id);
        }
    }
}
