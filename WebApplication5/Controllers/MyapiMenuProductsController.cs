using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class MyapiMenuProductsController : Controller
    {
        private readonly dbContext _context;

        public MyapiMenuProductsController(dbContext context)
        {
            _context = context;
        }

        // GET: MyapiMenuProducts
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.MyapiMenuProducts.Include(m => m.Menu).Include(m => m.Product);
            return View(await dbContext.ToListAsync());
        }

        // GET: MyapiMenuProducts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiMenuProduct = await _context.MyapiMenuProducts
                .Include(m => m.Menu)
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiMenuProduct == null)
            {
                return NotFound();
            }

            return View(myapiMenuProduct);
        }

        // GET: MyapiMenuProducts/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.MyapiMenus, "RestaurantId", "RestaurantId");
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category");
            return View();
        }

        // POST: MyapiMenuProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MenuId,ProductId")] MyapiMenuProduct myapiMenuProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myapiMenuProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.MyapiMenus, "RestaurantId", "RestaurantId", myapiMenuProduct.MenuId);
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category", myapiMenuProduct.ProductId);
            return View(myapiMenuProduct);
        }

        // GET: MyapiMenuProducts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiMenuProduct = await _context.MyapiMenuProducts.FindAsync(id);
            if (myapiMenuProduct == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.MyapiMenus, "RestaurantId", "RestaurantId", myapiMenuProduct.MenuId);
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category", myapiMenuProduct.ProductId);
            return View(myapiMenuProduct);
        }

        // POST: MyapiMenuProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,MenuId,ProductId")] MyapiMenuProduct myapiMenuProduct)
        {
            if (id != myapiMenuProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myapiMenuProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyapiMenuProductExists(myapiMenuProduct.Id))
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
            ViewData["MenuId"] = new SelectList(_context.MyapiMenus, "RestaurantId", "RestaurantId", myapiMenuProduct.MenuId);
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category", myapiMenuProduct.ProductId);
            return View(myapiMenuProduct);
        }

        // GET: MyapiMenuProducts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiMenuProduct = await _context.MyapiMenuProducts
                .Include(m => m.Menu)
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiMenuProduct == null)
            {
                return NotFound();
            }

            return View(myapiMenuProduct);
        }

        // POST: MyapiMenuProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var myapiMenuProduct = await _context.MyapiMenuProducts.FindAsync(id);
            _context.MyapiMenuProducts.Remove(myapiMenuProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyapiMenuProductExists(long id)
        {
            return _context.MyapiMenuProducts.Any(e => e.Id == id);
        }
    }
}
