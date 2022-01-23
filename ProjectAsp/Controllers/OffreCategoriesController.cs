using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAsp.Data;
using ProjectAsp.Models;

namespace ProjectAsp.Controllers
{
    public class OffreCategoriesController : Controller
    {
        private readonly ProjectAspContext _context;

        public OffreCategoriesController(ProjectAspContext context)
        {
            _context = context;
        }

        // GET: OffreCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.OffreCategory.ToListAsync());
        }

        // GET: OffreCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offreCategory = await _context.OffreCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offreCategory == null)
            {
                return NotFound();
            }

            return View(offreCategory);
        }

        // GET: OffreCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OffreCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] OffreCategory offreCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offreCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offreCategory);
        }

        // GET: OffreCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offreCategory = await _context.OffreCategory.FindAsync(id);
            if (offreCategory == null)
            {
                return NotFound();
            }
            return View(offreCategory);
        }

        // POST: OffreCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] OffreCategory offreCategory)
        {
            if (id != offreCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offreCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OffreCategoryExists(offreCategory.Id))
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
            return View(offreCategory);
        }

        // GET: OffreCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offreCategory = await _context.OffreCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offreCategory == null)
            {
                return NotFound();
            }

            return View(offreCategory);
        }

        // POST: OffreCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offreCategory = await _context.OffreCategory.FindAsync(id);
            _context.OffreCategory.Remove(offreCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OffreCategoryExists(int id)
        {
            return _context.OffreCategory.Any(e => e.Id == id);
        }
    }
}
