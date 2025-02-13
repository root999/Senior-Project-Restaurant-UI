﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class MenusController : Controller
    {
        private readonly dbContext _context;

        public MenusController(dbContext context)
        {
            _context = context;
        }

        // GET: Menus
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.MyapiMenus.Include(m => m.Restaurant).Include(p => p.MyapiMenuProducts).ThenInclude(pm => pm.Product);
            return View(await dbContext.ToListAsync());
        }

        // GET: Menus/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myapiMenu = await _context.MyapiMenus
                .Include(m => m.Restaurant)
                .FirstOrDefaultAsync(m => m.RestaurantId == id);
            if (myapiMenu == null)
            {
                return NotFound();
            }

            return View(myapiMenu);
        }
        // GET: Menus/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.MyapiProducts, "Id", "Name");
            return View();
        }

        // POST: Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProductId")] MyapiProduct myapiProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MyapiMenuProduct myapiMenuProduct = new MyapiMenuProduct
        //        {
                    
        //        }
        //        _context.MyapiMenuProducts.Add();
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiMenu.RestaurantId);
        //    return View(myapiMenu);
        //}

        // GET: Menus/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var myapiMenu = await _context.MyapiMenus.FindAsync(id);
        //    if (myapiMenu == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiMenu.RestaurantId);
        //    return View(myapiMenu);
        //}

        //// POST: Menus/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("RestaurantId")] MyapiMenu myapiMenu)
        //{
        //    if (id != myapiMenu.RestaurantId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(myapiMenu);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MyapiMenuExists(myapiMenu.RestaurantId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiMenu.RestaurantId);
        //    return View(myapiMenu);
        //}

        //// GET: Menus/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var myApiMenu = await _context.MyapiMenuProducts.Include(m => m.Menu).Include(pm => pm.Product).FirstOrDefaultAsync(p => p.Product.Id == id);
        //    if (myApiMenu == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(myApiMenu);
        //}

        //// POST: Menus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var myapiMenu = await _context.MyapiMenuProducts.FindAsync(id);
        //    _context.MyapiMenuProducts.Remove(myapiMenu);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MyapiMenuExists(long id)
        //{
        //    return _context.MyapiMenus.Any(e => e.RestaurantId == id);
        //}
    }
    //    // GET: Menus/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Name");
    //        return View();
    //    }

    //    // POST: Menus/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("RestaurantId")] MyapiMenu myapiMenu)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(myapiMenu);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiMenu.RestaurantId);
    //        return View(myapiMenu);
    //    }

    //    // GET: Menus/Edit/5
    //    public async Task<IActionResult> Edit(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var myapiMenu = await _context.MyapiMenus.FindAsync(id);
    //        if (myapiMenu == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiMenu.RestaurantId);
    //        return View(myapiMenu);
    //    }

    //    // POST: Menus/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(long id, [Bind("RestaurantId")] MyapiMenu myapiMenu)
    //    {
    //        if (id != myapiMenu.RestaurantId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(myapiMenu);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!MyapiMenuExists(myapiMenu.RestaurantId))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["RestaurantId"] = new SelectList(_context.MyapiRestaurants, "Id", "Address", myapiMenu.RestaurantId);
    //        return View(myapiMenu);
    //    }

    //    // GET: Menus/Delete/5
    //    public async Task<IActionResult> Delete(long? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var myapiMenu = await _context.MyapiMenus
    //            .Include(m => m.Restaurant)
    //            .FirstOrDefaultAsync(m => m.RestaurantId == id);
    //        if (myapiMenu == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(myapiMenu);
    //    }

    //    // POST: Menus/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(long id)
    //    {
    //        var myapiMenu = await _context.MyapiMenus.FindAsync(id);
    //        _context.MyapiMenus.Remove(myapiMenu);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool MyapiMenuExists(long id)
    //    {
    //        return _context.MyapiMenus.Any(e => e.RestaurantId == id);
    //    }
    //}
}
