﻿using System;
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
    public class SocietesController : Controller
    {
        private readonly ProjectAspContext _context;

        public SocietesController(ProjectAspContext context)
        {
            _context = context;
        }

        // GET: Societes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Societe.ToListAsync());
        }

        // GET: Societes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = await _context.Societe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // GET: Societes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Societes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Logo,Name,Description")] Societe societe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(societe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(societe);
        }

        // GET: Societes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = await _context.Societe.FindAsync(id);
            if (societe == null)
            {
                return NotFound();
            }
            return View(societe);
        }

        // POST: Societes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Societe societe)
        {
            if (id != societe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(societe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocieteExists(societe.Id))
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
            return View(societe);
        }

        // GET: Societes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var societe = await _context.Societe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (societe == null)
            {
                return NotFound();
            }

            return View(societe);
        }

        // POST: Societes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var societe = await _context.Societe.FindAsync(id);
            _context.Societe.Remove(societe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocieteExists(int id)
        {
            return _context.Societe.Any(e => e.Id == id);
        }
    }
}
