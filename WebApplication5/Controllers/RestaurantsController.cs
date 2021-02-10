using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly dbContext _context;

        public RestaurantsController(dbContext context)
        {
            _context = context;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {

            var name = User.Claims.Where(c => c.Type == ClaimTypes.Name)
           .Select(c => c.Value).SingleOrDefault();
            var dbContext = _context.MyapiRestaurants.Where(r => r.Name == name);
            return View(await dbContext.ToListAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiRestaurant = await _context.MyapiRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiRestaurant == null)
            {
                return NotFound();
            }

            return View(myapiRestaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,LogoUrl")] MyapiRestaurant myapiRestaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myapiRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myapiRestaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiRestaurant = await _context.MyapiRestaurants.FindAsync(id);
            if (myapiRestaurant == null)
            {
                return NotFound();
            }
            return View(myapiRestaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Address,LogoUrl")] MyapiRestaurant myapiRestaurant)
        {
            if (id != myapiRestaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myapiRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyapiRestaurantExists(myapiRestaurant.Id))
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
            return View(myapiRestaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiRestaurant = await _context.MyapiRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiRestaurant == null)
            {
                return NotFound();
            }

            return View(myapiRestaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var myapiRestaurant = await _context.MyapiRestaurants.FindAsync(id);
            _context.MyapiRestaurants.Remove(myapiRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyapiRestaurantExists(long id)
        {
            return _context.MyapiRestaurants.Any(e => e.Id == id);
        }
    }
}
