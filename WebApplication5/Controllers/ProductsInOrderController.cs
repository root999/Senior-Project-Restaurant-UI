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
    public class ProductsInOrderController : Controller
    {
        private readonly dbContext _context;

        public ProductsInOrderController(dbContext context)
        {
            _context = context;
        }

        // GET: ProductsInOrder
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.MyapiProductsinorders.Include(m => m.Order).Include(m => m.Product);
            return View(await dbContext.ToListAsync());
        }

        // GET: ProductsInOrder/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiProductsinorder = await _context.MyapiProductsinorders
                .Include(m => m.Order)
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiProductsinorder == null)
            {
                return NotFound();
            }

            return View(myapiProductsinorder);
        }

        // GET: ProductsInOrder/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.MyapiOrders, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category");
            return View();
        }

        // POST: ProductsInOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductCount,OrderId,ProductId")] MyapiProductsinorder myapiProductsinorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myapiProductsinorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.MyapiOrders, "Id", "Id", myapiProductsinorder.OrderId);
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category", myapiProductsinorder.ProductId);
            return View(myapiProductsinorder);
        }

        // GET: ProductsInOrder/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiProductsinorder = await _context.MyapiProductsinorders.FindAsync(id);
            if (myapiProductsinorder == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.MyapiOrders, "Id", "Id", myapiProductsinorder.OrderId);
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category", myapiProductsinorder.ProductId);
            return View(myapiProductsinorder);
        }

        // POST: ProductsInOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProductCount,OrderId,ProductId")] MyapiProductsinorder myapiProductsinorder)
        {
            if (id != myapiProductsinorder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myapiProductsinorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyapiProductsinorderExists(myapiProductsinorder.Id))
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
            ViewData["OrderId"] = new SelectList(_context.MyapiOrders, "Id", "Id", myapiProductsinorder.OrderId);
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Category", myapiProductsinorder.ProductId);
            return View(myapiProductsinorder);
        }

        // GET: ProductsInOrder/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiProductsinorder = await _context.MyapiProductsinorders
                .Include(m => m.Order)
                .Include(m => m.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiProductsinorder == null)
            {
                return NotFound();
            }

            return View(myapiProductsinorder);
        }

        // POST: ProductsInOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var myapiProductsinorder = await _context.MyapiProductsinorders.FindAsync(id);
            _context.MyapiProductsinorders.Remove(myapiProductsinorder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyapiProductsinorderExists(long id)
        {
            return _context.MyapiProductsinorders.Any(e => e.Id == id);
        }
    }
}
