using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CakeShop.Data;
using CakeShop.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CakeShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly CakeShopContext _context;

        public UsersController(CakeShopContext context)
        {
            _context = context;
        }


        //Logout Option
        public async Task<IActionResult> Logout()
        {
            //HttpContext.Session.Clear();

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

       


        //LogIn Option
        public IActionResult Login()
        {
            return View();
        }


        //You Don't have premotion..
        public IActionResult AccessDenied()
        {
            return View();
        }


        public async Task<IActionResult> EditUsers(User user)
        {
            UserType temp = user.Type;
            int x = (int)temp;
            if (x != 3)
                return RedirectToAction(nameof(AccessDenied), "Users"); //if you dont allowed

            return View(User);
        }

       // POST: Users/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Id,UserName,PassWord")] User user)
        {
            if (ModelState.IsValid)
            {
                var q = from u in _context.User
                        where u.Username == user.Username && u.Username == user.Username
                        select u;

                // var q = _context.User.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (q.Count() > 0)
                {
                     HttpContext.Session.SetString("username", q.First().Username);

                    Signin(q.First());

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewData["Error"] = "Username and/or password are incorrect.";
                }
            }
            return View(user);
        }


        private async void Signin(User account)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim(ClaimTypes.Role, account.Type.ToString()),
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }


        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Username,Password,Firstname,Lastname,Address,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                var q = _context.User.FirstOrDefault(u => u.Username == user.Username);

                var w = _context.User.FirstOrDefault(s => s.Address == user.Address);


                if (q == null && w == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();

                    var u = _context.User.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                    Signin(u);

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewData["Error"] = "Unable to comply; cannot register this user.";
                }
            }
            return View(user);
        }
    }
}







































/*
// POST: Users/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Username,Password,Type,Firstname,Lastname,Address,Phone")] User user)
{
    if (ModelState.IsValid)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(user);
}

// GET: Users/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var user = await _context.User.FindAsync(id);
    if (user == null)
    {
        return NotFound();
    }
    return View(user);
}

// POST: Users/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Type,Firstname,Lastname,Address,Phone")] User user)
{
    if (id != user.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(user.Id))
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
    return View(user);
}

// GET: Users/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var user = await _context.User
        .FirstOrDefaultAsync(m => m.Id == id);
    if (user == null)
    {
        return NotFound();
    }

    return View(user);
}

// POST: Users/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var user = await _context.User.FindAsync(id);
    _context.User.Remove(user);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool UserExists(int id)
{
    return _context.User.Any(e => e.Id == id);
}
}
}*/


/*
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }
        */
// GET: Users/Details/5
/*
public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var user = await _context.User
        .FirstOrDefaultAsync(m => m.Id == id);
    if (user == null)
    {
        return NotFound();
    }

    return View(user);
}*/
/*
// GET: Users/Create
public IActionResult Create()
{
    return View();
}*/