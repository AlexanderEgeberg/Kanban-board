using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanban_board.Data;
using Kanban_board.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Kanban_board.Controllers
{
    
    public class UserstoriesController : Controller
    {
        private readonly KanbanContext _context;

        public UserstoriesController(KanbanContext context)
        {
            _context = context;
        }

        // GET: Userstories
        [Authorize(Policy = "ObserverAccess")]
        public async Task<IActionResult> Index()
        {
            var kanbanContext = _context.Userstories.Include(u => u.Board);
            return View(await kanbanContext.ToListAsync());
        }

        // GET: Userstories/Details/5
        [Authorize(Policy = "ObserverAccess")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userstory = await _context.Userstories
                .Include(u => u.Board)
                .FirstOrDefaultAsync(m => m.UserstoryId == id);
            if (userstory == null)
            {
                return NotFound();
            }

            return View(userstory);
        }

        // GET: Userstories/Create
        [Authorize(Policy = "TeamPlayerAccess")]
        public IActionResult Create()
        {
            ViewData["boardId"] = new SelectList(_context.Boards, "Id", "Id");
            return View();
        }

        // POST: Userstories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Policy = "TeamPlayerAccess")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserstoryId,Title,Description,Status,boardId")] Userstory userstory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userstory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["boardId"] = new SelectList(_context.Boards, "Id", "Id", userstory.boardId);
            return View(userstory);
        }

        // GET: Userstories/Edit/5
        [Authorize(Policy = "TeamPlayerAccess")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userstory = await _context.Userstories.FindAsync(id);
            if (userstory == null)
            {
                return NotFound();
            }
            ViewData["boardId"] = new SelectList(_context.Boards, "Id", "Id", userstory.boardId);
            return View(userstory);
        }

        // POST: Userstories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Policy = "TeamPlayerAccess")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserstoryId,Title,Description,Status,boardId")] Userstory userstory)
        {
            if (id != userstory.UserstoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userstory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserstoryExists(userstory.UserstoryId))
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
            ViewData["boardId"] = new SelectList(_context.Boards, "Id", "Id", userstory.boardId);
            return View(userstory);
        }

        // GET: Userstories/Delete/5
        [Authorize(Policy = "TeamPlayerAccess")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userstory = await _context.Userstories
                .Include(u => u.Board)
                .FirstOrDefaultAsync(m => m.UserstoryId == id);
            if (userstory == null)
            {
                return NotFound();
            }

            return View(userstory);
        }

        // POST: Userstories/Delete/5
        [Authorize(Policy = "TeamPlayerAccess")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userstory = await _context.Userstories.FindAsync(id);
            _context.Userstories.Remove(userstory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserstoryExists(int id)
        {
            return _context.Userstories.Any(e => e.UserstoryId == id);
        }
    }
}
