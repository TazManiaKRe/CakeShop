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
    public class CategoriesController : Controller
    {
        private readonly CakeShopContext _context;

        public CategoriesController(CakeShopContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Milky()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 1).ToListAsync());
        }

        public async Task<IActionResult> Parve()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 2).ToListAsync());
        }


        public async Task<IActionResult> NoEggs()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 3).ToListAsync());
        }

        public async Task<IActionResult> Special()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 4).ToListAsync());
        }

        public async Task<IActionResult> TheBestSelling()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 5).ToListAsync());
        }

        public async Task<IActionResult> Vegan()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 6).ToListAsync());
        }
        public async Task<IActionResult> WithoutBaking()
        {

            return View(await _context.Cake.Where(x => x.CategoryId == 7).ToListAsync());
        }

        public async Task<IActionResult> AllCakes()
        {
            try
            {
                var cakes =
                    from category in _context.Category
                    join prod in _context.Cake on category.Id equals prod.CategoryId
                    orderby category.Id
                    select prod;

                return View(await cakes.ToListAsync());
            }
            catch { return RedirectToAction("PageNotFound", "Home"); }
        }
    }
}
