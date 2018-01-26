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
    public class BoardGameGenresController : Controller
    {
        private readonly BoardGamesContext _context;

        public BoardGameGenresController(BoardGamesContext context)
        {
            _context = context;
        }

        // GET: BoardGameGenres
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoardGameGenre.ToListAsync());
        }

        // GET: BoardGameGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardGameGenre = await _context.BoardGameGenre
                .SingleOrDefaultAsync(m => m.Id == id);
            if (boardGameGenre == null)
            {
                return NotFound();
            }

            return View(boardGameGenre);
        }

        // GET: BoardGameGenres/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardGameGenres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Name")] BoardGameGenre boardGameGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardGameGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardGameGenre);
        }

        // GET: BoardGameGenres/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardGameGenre = await _context.BoardGameGenre.SingleOrDefaultAsync(m => m.Id == id);
            if (boardGameGenre == null)
            {
                return NotFound();
            }
            return View(boardGameGenre);
        }

        // POST: BoardGameGenres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BoardGameGenre boardGameGenre)
        {
            if (id != boardGameGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardGameGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardGameGenreExists(boardGameGenre.Id))
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
            return View(boardGameGenre);
        }

        // GET: BoardGameGenres/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardGameGenre = await _context.BoardGameGenre
                .SingleOrDefaultAsync(m => m.Id == id);
            if (boardGameGenre == null)
            {
                return NotFound();
            }

            return View(boardGameGenre);
        }

        // POST: BoardGameGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boardGameGenre = await _context.BoardGameGenre.SingleOrDefaultAsync(m => m.Id == id);
            _context.BoardGameGenre.Remove(boardGameGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardGameGenreExists(int id)
        {
            return _context.BoardGameGenre.Any(e => e.Id == id);
        }
    }
}
