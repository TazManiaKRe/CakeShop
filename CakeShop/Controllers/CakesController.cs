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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var CakeShopContext = _context.Cake.Include(p => p.Category);
                return View(await CakeShopContext.ToListAsync());
            }
            catch { return RedirectToAction("PageNotFound", "Home"); }
        }

        ////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////
        ///  ////////////////////////////////////////////////////////////////
        ///   ////////////////////////////////////////////////////////////////
        ///   
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SearchPtable(string query)
        {
            try
            {
                var CakeShopContext = _context.Cake.Include(p => p.Category);
                return PartialView(await CakeShopContext.Where(p => p.Name.Contains(query)).ToListAsync());
            }
            catch { return RedirectToAction("PageNotFound", "Home"); }
        }


        //Search Product
        public async Task<IActionResult> Search(string productName, string price, string category)
        {
            try
            {
                int p = Int32.Parse(price);
                var CakeShopContext = _context.Product.Include(a => a.Category).Where(a => a.Name.Contains(productName) && a.Category.Name.Equals(category) && a.Price <= p);
                return View("searchlist", await CakeShopContext.ToListAsync());
            }
            catch { return RedirectToAction("PageNotFound", "Home"); }
        }

        ////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id");
            return View();
        }

        // POST: Cakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Body,Category,CategoryId,PhotosUrl1,PhotosUrl2,PhotosUrl3,PhotosUrl4,Price")] Cake cake)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cake);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", product.CategoryId);
                return View(product);
            }
            catch { return RedirectToAction("PageNotFound", "Home"); }
        }

        //search

        public async Task<IActionResult> Search(string queryTitle, string queryBody)
        {
            var q = from a in _context.Cake.Include(a => a.Category)
                    where (a.Title.Contains(queryTitle) || a.Body.Contains(queryBody))
                    orderby a.Title descending
                    select a; // new { Id = a.Id, Summary = a.Title + a.Body.Substring(0, 50) };

            var CakeShopContext = _context.Cake.Include(a => a.Category).Where(a => (a.Title.Contains(queryTitle) || queryTitle == null) && (a.Body.Contains(queryBody) || queryBody == null));
            return View("Index", await CakeShopContext.ToListAsync());
        }

        //need to change
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", cake.CategoryId);
            return View(cake);
        }

        // POST: Cakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,CategoryId,Price")] Cake cake)
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Id", cake.CategoryId);
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


        public async Task<IActionResult> allCakes()
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
            catch { return RedirectToAction("Index", "Home"); }
        }

        [HttpPost]
        public IActionResult GroupByPrice()
        {
            try
            {
                var groups = from p in _context.Cake.ToList()
                             group p by p.Price
                into g
                             orderby g.Key
                             select g;

                List<Cake> cakes = new List<Cake>();
                foreach (var prod in groups)
                {
                    for (int i = 0; i < prod.ToList().Count; i++)
                    {
                        cakes.Add(prod.ElementAt(i));
                    }
                }

                return View("AllCakes", cakes);
            }
            catch { return RedirectToAction("PageNotFound", "Home"); }
        }
    }
}
public class Stat
{
    public string Key;
    public int Values;
    public Stat(string key, int values)
    {
        Key = key;
        Values = values;
    }
}
