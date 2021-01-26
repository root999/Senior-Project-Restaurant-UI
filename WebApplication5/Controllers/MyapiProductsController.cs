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
    public class MyapiProductsController : Controller
    {
        private readonly dbContext _context;

        public MyapiProductsController(dbContext context)
        {
            _context = context;
        }

        // GET: MyapiProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyapiProducts.ToListAsync());
        }

        // GET: MyapiProducts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiProduct = await _context.MyapiProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiProduct == null)
            {
                return NotFound();
            }

            return View(myapiProduct);
        }

        // GET: MyapiProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyapiProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,PhotoUrl,Category,Details")] MyapiProduct myapiProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myapiProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myapiProduct);
        }

        // GET: MyapiProducts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiProduct = await _context.MyapiProducts.FindAsync(id);
            if (myapiProduct == null)
            {
                return NotFound();
            }
            return View(myapiProduct);
        }

        // POST: MyapiProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Price,PhotoUrl,Category,Details")] MyapiProduct myapiProduct)
        {
            if (id != myapiProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myapiProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyapiProductExists(myapiProduct.Id))
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
            return View(myapiProduct);
        }

        // GET: MyapiProducts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiProduct = await _context.MyapiProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiProduct == null)
            {
                return NotFound();
            }

            return View(myapiProduct);
        }

        // POST: MyapiProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var myapiProduct = await _context.MyapiProducts.FindAsync(id);
            _context.MyapiProducts.Remove(myapiProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyapiProductExists(long id)
        {
            return _context.MyapiProducts.Any(e => e.Id == id);
        }
    }
}
