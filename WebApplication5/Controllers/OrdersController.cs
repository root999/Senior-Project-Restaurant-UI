using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    
    public class OrdersController : Controller
    {
        private readonly dbContext _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public OrdersController(dbContext context)
        {
            _context = context;
        // _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var name = User.Claims.Where(c => c.Type == ClaimTypes.Name)
            .Select(c => c.Value).SingleOrDefault();
            var dbContext = _context.MyapiOrders.Include(m => m.Customer).Include(m => m.Restaurant).Include(p => p.MyapiProductsinorders).ThenInclude(po => po.Product).Where(d => d.Restaurant.Name == name & d.Status =="Active") ;
            //System.Diagnostics.Debug.WriteLine(getUserId());
            return View(await dbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiOrder = await _context.MyapiOrders.Include(m => m.Customer)
                .Include(m => m.Restaurant)
                .Include(p => p.MyapiProductsinorders)
                .ThenInclude(po => po.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiOrder == null)
            {
                return NotFound();
            }

            return View(myapiOrder);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.MyapiCustomers, "Id", "Email");
            ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IssueTime,CustomerId,RestaurantId,IssueDate,PlannedTime,PlannedDate")] MyapiOrder myapiOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myapiOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.MyapiCustomers, "Id", "Email", myapiOrder.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiOrder.RestaurantId);
            return View(myapiOrder);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiOrder = await _context.MyapiOrders.FindAsync(id);
            if (myapiOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.MyapiCustomers, "Id", "Email", myapiOrder.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiOrder.RestaurantId);
            return View(myapiOrder);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IssueTime,CustomerId,RestaurantId,IssueDate,PlannedTime,PlannedDate")] MyapiOrder myapiOrder)
        {
            if (id != myapiOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myapiOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyapiOrderExists(myapiOrder.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.MyapiCustomers, "Id", "Email", myapiOrder.CustomerId);
            ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiOrder.RestaurantId);
            return View(myapiOrder);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiOrder = await _context.MyapiOrders
                .Include(m => m.Customer)
                .Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myapiOrder == null)
            {
                return NotFound();
            }

            return View(myapiOrder);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var myapiOrder = await _context.MyapiOrders.FindAsync(id);
            _context.MyapiOrders.Remove(myapiOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyapiOrderExists(long id)
        {
            return _context.MyapiOrders.Any(e => e.Id == id);
        }
        //private int getUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
