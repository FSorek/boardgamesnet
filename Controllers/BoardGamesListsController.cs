using System;
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
    public class BoardGamesListsController : Controller
    {
        private readonly BoardGamesContext _context;

        public BoardGamesListsController(BoardGamesContext context)
        {
            _context = context;
        }

        // GET: BoardGamesLists
        public async Task<IActionResult> Index()
        {
            var bgContext = _context.BoardGamesList.Include(s => s.Genre);
            return View(await bgContext.ToListAsync());
        }

        // GET: BoardGamesLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardGamesList = await _context.BoardGamesList
                .Include(bg => bg.Genre)
                .SingleOrDefaultAsync(bg => bg.Id == id);
            if (boardGamesList == null)
            {
                return NotFound();
            }

            return View(boardGamesList);
        }

        // GET: BoardGamesLists/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.BoardGameGenre, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: BoardGamesLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Title,GenreId,Price,Available,ManufacurerId")] BoardGamesList boardGamesList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardGamesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.BoardGameGenre, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            return View(boardGamesList);
        }

        // GET: BoardGamesLists/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var boardGamesList = await _context.BoardGamesList.SingleOrDefaultAsync(m => m.Id == id);
            if (boardGamesList == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.BoardGameGenre, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            return View(boardGamesList);
        }

        // POST: BoardGamesLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,GenreId,Price,Available,ManufacurerId")] BoardGamesList boardGamesList)
        {
            if (id != boardGamesList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardGamesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardGamesListExists(boardGamesList.Id))
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
            ViewData["GenreId"] = new SelectList(_context.BoardGameGenre, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            return View(boardGamesList);
        }

        // GET: BoardGamesLists/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardGamesList = await _context.BoardGamesList
                .SingleOrDefaultAsync(m => m.Id == id);
            if (boardGamesList == null)
            {
                return NotFound();
            }

            return View(boardGamesList);
        }

        // POST: BoardGamesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boardGamesList = await _context.BoardGamesList.SingleOrDefaultAsync(m => m.Id == id);
            _context.BoardGamesList.Remove(boardGamesList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardGamesListExists(int id)
        {
            return _context.BoardGamesList.Any(e => e.Id == id);
        }
    }
}
