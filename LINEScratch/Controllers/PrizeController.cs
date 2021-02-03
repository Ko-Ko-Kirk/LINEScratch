using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LINEScratch.Models;

namespace LINEScratch.Controllers
{
    public class PrizeController : Controller
    {
        private readonly DBContext _context;

        public PrizeController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Prize.OrderBy(x => x.PrizeId).ToListAsync();
            ViewBag.count = model.Count();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrizeId,PrizeName,PrizePic")] Prize prize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prize);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _context.Prize.FindAsync(id);
            if (prize == null)
            {
                return NotFound();
            }
            return View(prize);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrizeId,PrizeName,PrizePic")] Prize prize)
        {
            if (id != prize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!prizeExists(prize.Id))
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
            return View(prize);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _context.Prize
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prize == null)
            {
                return NotFound();
            }

            return View(prize);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prize = await _context.Prize.FindAsync(id);
            _context.Prize.Remove(prize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool prizeExists(int id)
        {
            return _context.Prize.Any(e => e.Id == id);
        }
    }
}
