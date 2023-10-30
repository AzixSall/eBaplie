using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eBaplie.Data;
using eBaplie.Models;
using Microsoft.AspNetCore.Authorization;

namespace eBaplie.Controllers
{
    public class VoyagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoyagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voyages
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Voyage.Include(v => v.VesselNavigation);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: Voyages/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    var voyage = await _context.Voyage
        //        .Include(v => v.VesselNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(voyage);
        //}

        // GET: Voyages/Create
        //public IActionResult Create(int vesselId)
        //{
        //    ViewBag.VesselId = vesselId;
        //    return View();
        //}

        // POST: Voyages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,VoygeNumber,VesselId")] Voyage voyage, IFormFile BaplieFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (BaplieFile.Length > 0)
        //        {
        //            using (var ms = new MemoryStream())
        //            {
        //                BaplieFile.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                voyage.BaplieFile = fileBytes;
        //            }
        //        }
        //        _context.Add(voyage);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Details), "Vessels", new {id = voyage.VesselId});
        //    }
        //    ViewData["VesselId"] = new SelectList(_context.Vessels, "Id", "Id", voyage.VesselId);
        //    return View(voyage);
        //}

        //// GET: Voyages/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    var voyage = await _context.Voyage.FindAsync(id);
        //    if (voyage == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["VesselId"] = new SelectList(_context.Vessels, "Id", "Id", voyage.VesselId);
        //    return View(voyage);
        //}

        // POST: Voyages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoygeNumber,VesselId,BaplieFile")] Voyage voyage)
        {
            if (id != voyage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voyage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoyageExists(voyage.Id))
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
            ViewData["VesselId"] = new SelectList(_context.Vessels, "Id", "Id", voyage.VesselId);
            return View(voyage);
        }

        // GET: Voyages/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    var voyage = await _context.Voyage
        //        .Include(v => v.VesselNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (voyage == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(voyage);
        //}

        // POST: Voyages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voyage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voyage'  is null.");
            }
            var voyage = await _context.Voyage.FindAsync(id);
            if (voyage != null)
            {
                _context.Voyage.Remove(voyage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoyageExists(int id)
        {
          return _context.Voyage.Any(e => e.Id == id);
        }
    }
}
