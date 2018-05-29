using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KC_Revolution.Data;
using KC_Revolution.Data.Entities;

namespace KC_Revolution.Controllers
{
    public class SmallGroupsController : Controller
    {
        private readonly RevolutionDbContext _context;

        public SmallGroupsController(RevolutionDbContext context)
        {
            _context = context;
        }

        // GET: SmallGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.SmallGroups.ToListAsync());
        }

        // GET: SmallGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smallGroup = await _context.SmallGroups
                .SingleOrDefaultAsync(m => m.Id == id);
            if (smallGroup == null)
            {
                return NotFound();
            }

            return View(smallGroup);
        }

        // GET: SmallGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SmallGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,EventTimes,PromoImg,GroupLink")] SmallGroup smallGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smallGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smallGroup);
        }

        // GET: SmallGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smallGroup = await _context.SmallGroups.SingleOrDefaultAsync(m => m.Id == id);
            if (smallGroup == null)
            {
                return NotFound();
            }
            return View(smallGroup);
        }

        // POST: SmallGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,EventTimes,PromoImg,GroupLink")] SmallGroup smallGroup)
        {
            if (id != smallGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smallGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmallGroupExists(smallGroup.Id))
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
            return View(smallGroup);
        }

        // GET: SmallGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smallGroup = await _context.SmallGroups
                .SingleOrDefaultAsync(m => m.Id == id);
            if (smallGroup == null)
            {
                return NotFound();
            }

            return View(smallGroup);
        }

        // POST: SmallGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smallGroup = await _context.SmallGroups.SingleOrDefaultAsync(m => m.Id == id);
            _context.SmallGroups.Remove(smallGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmallGroupExists(int id)
        {
            return _context.SmallGroups.Any(e => e.Id == id);
        }
    }
}
