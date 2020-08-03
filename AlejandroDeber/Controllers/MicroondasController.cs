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
    public class MicroondasController : Controller
    {
        private readonly MainContext _context;

        public MicroondasController(MainContext context)
        {
            _context = context;
        }

        // GET: Microondas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Microonda.ToListAsync());
        }

        // GET: Microondas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microonda = await _context.Microonda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (microonda == null)
            {
                return NotFound();
            }

            return View(microonda);
        }

        // GET: Microondas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Microondas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo")] Microonda microonda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(microonda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(microonda);
        }

        // GET: Microondas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microonda = await _context.Microonda.FindAsync(id);
            if (microonda == null)
            {
                return NotFound();
            }
            return View(microonda);
        }

        // POST: Microondas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo")] Microonda microonda)
        {
            if (id != microonda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(microonda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MicroondaExists(microonda.Id))
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
            return View(microonda);
        }

        // GET: Microondas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var microonda = await _context.Microonda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (microonda == null)
            {
                return NotFound();
            }

            return View(microonda);
        }

        // POST: Microondas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var microonda = await _context.Microonda.FindAsync(id);
            _context.Microonda.Remove(microonda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MicroondaExists(int id)
        {
            return _context.Microonda.Any(e => e.Id == id);
        }
    }
}
