﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoardGames.Models;
using Microsoft.AspNetCore.Authorization;

namespace BoardGames.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly BoardGamesContext _context;

        public ManufacturersController(BoardGamesContext context)
        {
            _context = context;
        }

        // GET: Manufacturers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manufacturers.ToListAsync());
        }

        // GET: Manufacturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturers = await _context.Manufacturers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (manufacturers == null)
            {
                return NotFound();
            }

            return View(manufacturers);
        }

        // GET: Manufacturers/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Year")] Manufacturers manufacturers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturers);
        }

        // GET: Manufacturers/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturers = await _context.Manufacturers.SingleOrDefaultAsync(m => m.Id == id);
            if (manufacturers == null)
            {
                return NotFound();
            }
            return View(manufacturers);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year")] Manufacturers manufacturers)
        {
            if (id != manufacturers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturersExists(manufacturers.Id))
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
            return View(manufacturers);
        }

        // GET: Manufacturers/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturers = await _context.Manufacturers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (manufacturers == null)
            {
                return NotFound();
            }

            return View(manufacturers);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturers = await _context.Manufacturers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Manufacturers.Remove(manufacturers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturersExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}
