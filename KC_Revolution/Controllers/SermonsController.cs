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
    public class SermonsController : Controller
    {
        private readonly RevolutionDbContext _context;

        public SermonsController(RevolutionDbContext context)
        {
            _context = context;
        }

        // GET: Sermons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sermons.ToListAsync());
        }

        // GET: Sermons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sermon = await _context.Sermons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sermon == null)
            {
                return NotFound();
            }

            return View(sermon);
        }

        // GET: Sermons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sermons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SermonName,SermonDescription,SermonFileLocation,SeriesTitle,SeriesId,CreatedDate")] Sermon sermon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sermon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sermon);
        }

        // GET: Sermons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sermon = await _context.Sermons.SingleOrDefaultAsync(m => m.Id == id);
            if (sermon == null)
            {
                return NotFound();
            }
            return View(sermon);
        }

        // POST: Sermons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SermonName,SermonDescription,SermonFileLocation,SeriesTitle,SeriesId,CreatedDate")] Sermon sermon)
        {
            if (id != sermon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sermon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SermonExists(sermon.Id))
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
            return View(sermon);
        }

        // GET: Sermons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sermon = await _context.Sermons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sermon == null)
            {
                return NotFound();
            }

            return View(sermon);
        }

        // POST: Sermons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sermon = await _context.Sermons.SingleOrDefaultAsync(m => m.Id == id);
            _context.Sermons.Remove(sermon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SermonExists(int id)
        {
            return _context.Sermons.Any(e => e.Id == id);
        }
    }
}
