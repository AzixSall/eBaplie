using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eBaplie.Data;
using eBaplie.Models;
using eBaplie.Helpers;
using System.Text;

namespace eBaplie.Controllers
{
    public class VesselsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VesselsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vessels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vessels.ToListAsync());
        }

        // GET: Vessels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vessels == null)
            {
                return NotFound();
            }

            var vessel = await _context.Vessels.Include(v => v.VoyagesNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vessel == null)
            {
                return NotFound();
            }

            return View(vessel);
        }

        // GET: Vessels/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Vessel vessel, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        vessel.Image = fileBytes;
                    }
                }

                _context.Add(vessel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vessel);
        }

        // GET: Vessels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vessels == null)
            {
                return NotFound();
            }

            var vessel = await _context.Vessels.FindAsync(id);
            if (vessel == null)
            {
                return NotFound();
            }
            return View(vessel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Vessel vessel, IFormFile image)
        {
            if (id != vessel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        vessel.Image = fileBytes;
                    }
                }
                try
                {
                    _context.Update(vessel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VesselExists(vessel.Id))
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
            return View(vessel);
        }

        public async Task<IActionResult> VesselStowage(int voyageId)
        {
            Voyage? voyage = await _context.Voyage.FindAsync(voyageId);

            if(voyage == null)
            {
                return NotFound();
            }
            string text = Encoding.UTF8.GetString(voyage.BaplieFile);

            var baplieData = Parser.ProcessFileSegments(text);

            List<PortColor> portColors = new List<PortColor>();

            foreach (var port in baplieData.Ports)
            {
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                PortColor portColor = new PortColor
                {
                    Color = color,
                    Name = port.Name
                };

                portColors.Add(portColor);
            }

            ViewBag.PortColor = portColors;
            ViewBag.Containers = baplieData.Containers.ToArray();
            return View(baplieData);
        }

        // GET: Vessels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vessels == null)
            {
                return NotFound();
            }

            var vessel = await _context.Vessels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vessel == null)
            {
                return NotFound();
            }

            return View(vessel);
        }

        // POST: Vessels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vessels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vessels'  is null.");
            }
            var vessel = await _context.Vessels.FindAsync(id);
            if (vessel != null)
            {
                _context.Vessels.Remove(vessel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VesselExists(int id)
        {
          return _context.Vessels.Any(e => e.Id == id);
        }
    }
}
