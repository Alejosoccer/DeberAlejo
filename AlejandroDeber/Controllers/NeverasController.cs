using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlejandroDeber.Data;
using AlejandroDeber.Models;

namespace AlejandroDeber.Controllers
{
    public class NeverasController : Controller
    {
        private readonly MainContext _context;

        public NeverasController(MainContext context)
        {
            _context = context;
        }

        // GET: Neveras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nevera.ToListAsync());
        }

        // GET: Neveras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nevera = await _context.Nevera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nevera == null)
            {
                return NotFound();
            }

            return View(nevera);
        }

        // GET: Neveras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Neveras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo")] Nevera nevera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nevera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nevera);
        }

        // GET: Neveras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nevera = await _context.Nevera.FindAsync(id);
            if (nevera == null)
            {
                return NotFound();
            }
            return View(nevera);
        }

        // POST: Neveras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo")] Nevera nevera)
        {
            if (id != nevera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nevera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeveraExists(nevera.Id))
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
            return View(nevera);
        }

        // GET: Neveras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nevera = await _context.Nevera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nevera == null)
            {
                return NotFound();
            }

            return View(nevera);
        }

        // POST: Neveras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nevera = await _context.Nevera.FindAsync(id);
            _context.Nevera.Remove(nevera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeveraExists(int id)
        {
            return _context.Nevera.Any(e => e.Id == id);
        }
    }
}
