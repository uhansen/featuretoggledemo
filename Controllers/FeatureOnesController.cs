using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using featuretoggledemo.Data;
using featuretoggledemo.Models;

namespace featuretoggledemo.Controllers
{
    public class FeatureOnesController : Controller
    {
        private readonly featuretoggledemoContext _context;

        public FeatureOnesController(featuretoggledemoContext context)
        {
            _context = context;
        }

        // GET: FeatureOnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeatureOne.ToListAsync());
        }

        // GET: FeatureOnes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureOne = await _context.FeatureOne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featureOne == null)
            {
                return NotFound();
            }

            return View(featureOne);
        }

        // GET: FeatureOnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeatureOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FeatureOne featureOne)
        {
            if (ModelState.IsValid)
            {
                featureOne.Id = Guid.NewGuid();
                _context.Add(featureOne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featureOne);
        }

        // GET: FeatureOnes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureOne = await _context.FeatureOne.FindAsync(id);
            if (featureOne == null)
            {
                return NotFound();
            }
            return View(featureOne);
        }

        // POST: FeatureOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] FeatureOne featureOne)
        {
            if (id != featureOne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featureOne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureOneExists(featureOne.Id))
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
            return View(featureOne);
        }

        // GET: FeatureOnes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureOne = await _context.FeatureOne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featureOne == null)
            {
                return NotFound();
            }

            return View(featureOne);
        }

        // POST: FeatureOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var featureOne = await _context.FeatureOne.FindAsync(id);
            _context.FeatureOne.Remove(featureOne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureOneExists(Guid id)
        {
            return _context.FeatureOne.Any(e => e.Id == id);
        }
    }
}
