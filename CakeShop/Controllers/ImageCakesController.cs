/*using System;
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
    public class ImageCakesController : Controller
    {
        private readonly CakeShopContext _context;

        public ImageCakesController(CakeShopContext context)
        {
            _context = context;
        }

        // GET: ImageCakes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImageCake.ToListAsync());
        }

        // GET: ImageCakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageCake = await _context.ImageCake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageCake == null)
            {
                return NotFound();
            }

            return View(imageCake);
        }

        // GET: ImageCakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImageCakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,URL")] ImageCake imageCake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imageCake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageCake);
        }

        // GET: ImageCakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageCake = await _context.ImageCake.FindAsync(id);
            if (imageCake == null)
            {
                return NotFound();
            }
            return View(imageCake);
        }

        // POST: ImageCakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,URL")] ImageCake imageCake)
        {
            if (id != imageCake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageCake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageCakeExists(imageCake.Id))
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
            return View(imageCake);
        }

        // GET: ImageCakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageCake = await _context.ImageCake
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imageCake == null)
            {
                return NotFound();
            }

            return View(imageCake);
        }

        // POST: ImageCakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageCake = await _context.ImageCake.FindAsync(id);
            _context.ImageCake.Remove(imageCake);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageCakeExists(int id)
        {
            return _context.ImageCake.Any(e => e.Id == id);
        }
    }
}
*/