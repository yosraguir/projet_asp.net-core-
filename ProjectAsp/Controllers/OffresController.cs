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
    public class OffresController : Controller
    {
        private readonly ProjectAspContext _context;

        public OffresController(ProjectAspContext context)
        {
            _context = context;
        }

        // GET: Offres
        public async Task<IActionResult> Index()
        {
            var projectAspContext = _context.Offre.Include(o => o.OffreCategory).Include(o => o.Societe);
            return View(await projectAspContext.ToListAsync());
        }

        // GET: Offres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offre = await _context.Offre
                .Include(o => o.OffreCategory)
                .Include(o => o.Societe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offre == null)
            {
                return NotFound();
            }

            return View(offre);
        }

        // GET: Offres/Create
        public IActionResult Create()
        {
            ViewData["OffreCategoryId"] = new SelectList(_context.Set<OffreCategory>(), "Id", "Id");
            //ViewData["SocieteId"] = new SelectList(_context.Societe, "Id", "NomSociete");
            return View();
        }

        // POST: Offres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageURL,StartDate,EndDate,OffreCategoryId,SocieteId,MangaerId")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OffreCategoryId"] = new SelectList(_context.Set<OffreCategory>(), "Id", "Id", offre.OffreCategoryId);
            //ViewData["SocieteId"] = new SelectList(_context.Societe, "Id", "NomSociete", offre.SocieteId);
            return View(offre);
        }

        // GET: Offres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offre = await _context.Offre.FindAsync(id);
            if (offre == null)
            {
                return NotFound();
            }
            ViewData["OffreCategoryId"] = new SelectList(_context.Set<OffreCategory>(), "Id", "Id", offre.OffreCategoryId);
            ViewData["SocieteId"] = new SelectList(_context.Set<Societe>(), "Id", "Id", offre.SocieteId);
            return View(offre);
        }

        // POST: Offres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageURL,StartDate,EndDate,OffreCategoryId,SocieteId,MangaerId")] Offre offre)
        {
            if (id != offre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OffreExists(offre.Id))
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
            ViewData["OffreCategoryId"] = new SelectList(_context.Set<OffreCategory>(), "Id", "Id", offre.OffreCategoryId);
            ViewData["SocieteId"] = new SelectList(_context.Set<Societe>(), "Id", "Id", offre.SocieteId);
            return View(offre);
        }

        // GET: Offres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offre = await _context.Offre
                .Include(o => o.OffreCategory)
                .Include(o => o.Societe)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offre == null)
            {
                return NotFound();
            }

            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offre = await _context.Offre.FindAsync(id);
            _context.Offre.Remove(offre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OffreExists(int id)
        {
            return _context.Offre.Any(e => e.Id == id);
        }
    }
}
