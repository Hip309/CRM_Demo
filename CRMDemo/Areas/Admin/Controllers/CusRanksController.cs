using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRMDemo.Models;

namespace CRMDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CusRanksController : Controller
    {
        private readonly CrmDBContext _context;

        public CusRanksController(CrmDBContext context)
        {
            _context = context;
        }

        // GET: Admin/CusRanks
        public async Task<IActionResult> Index()
        {
              return View(await _context.CusRanks.ToListAsync());
        }

        // GET: Admin/CusRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CusRanks == null)
            {
                return NotFound();
            }

            var cusRank = await _context.CusRanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cusRank == null)
            {
                return NotFound();
            }

            return View(cusRank);
        }

        // GET: Admin/CusRanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CusRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RankName,Condition")] CusRank cusRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cusRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cusRank);
        }

        // GET: Admin/CusRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CusRanks == null)
            {
                return NotFound();
            }

            var cusRank = await _context.CusRanks.FindAsync(id);
            if (cusRank == null)
            {
                return NotFound();
            }
            return View(cusRank);
        }

        // POST: Admin/CusRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RankName,Condition")] CusRank cusRank)
        {
            if (id != cusRank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cusRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CusRankExists(cusRank.Id))
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
            return View(cusRank);
        }

        // GET: Admin/CusRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CusRanks == null)
            {
                return NotFound();
            }

            var cusRank = await _context.CusRanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cusRank == null)
            {
                return NotFound();
            }

            return View(cusRank);
        }

        // POST: Admin/CusRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CusRanks == null)
            {
                return Problem("Entity set 'CrmDBContext.CusRanks'  is null.");
            }
            var cusRank = await _context.CusRanks.FindAsync(id);
            if (cusRank != null)
            {
                _context.CusRanks.Remove(cusRank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CusRankExists(int id)
        {
          return _context.CusRanks.Any(e => e.Id == id);
        }
    }
}
