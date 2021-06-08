using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CakeShop.Data;
using CakeShop.Models;

namespace CakeShop.Controllers
{
    public class CakesController : Controller
    {
        private readonly CakeShopContext _context;

        public CakesController(CakeShopContext context)
        {
            _context = context;
        }

        // GET: Cakes
        public async Task<IActionResult> Index()
        {
            var cakeShopContext = _context.Cake.Include(c => c.Category);
            return View(await cakeShopContext.ToListAsync());
        }

        // GET: Cakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // GET: Cakes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id");
            return View();
        }

        // POST: Cakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Body,CategoryId")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", cake.CategoryId);
            return View(cake);
        }

        // GET: Cakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", cake.CategoryId);
            return View(cake);
        }

        // POST: Cakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,CategoryId")] Cake cake)
        {
            if (id != cake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeExists(cake.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Id", cake.CategoryId);
            return View(cake);
        }

        // GET: Cakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cake = await _context.Cake
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }
        public async Task<IActionResult> Search(string queryTitle, string queryBody)
        {
            var q = from a in _context.Cake.Include(a => a.Category)
                    where (a.Title.Contains(queryTitle) && a.Body.Contains(queryBody))
                    orderby a.Title descending
                    select a;

            var CakeShophContext = _context.Cake.Include(a => a.Category).Where(a => (a.Title.Contains(queryTitle) || queryTitle == null) && (a.Body.Contains(queryBody) || queryBody == null));
            return View("Index", await CakeShophContext.ToListAsync());
        }

        // POST: Cakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cake = await _context.Cake.FindAsync(id);
            _context.Cake.Remove(cake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeExists(int id)
        {
            return _context.Cake.Any(e => e.Id == id);
        }
    }

}
