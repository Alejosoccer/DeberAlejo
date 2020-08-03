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
    public class LavadorasController : Controller
    {
        private readonly MainContext _context;

        public LavadorasController(MainContext context)
        {
            _context = context;
        }

        // GET: Lavadoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lavadora.ToListAsync());
        }

        // GET: Lavadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lavadora = await _context.Lavadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lavadora == null)
            {
                return NotFound();
            }

            return View(lavadora);
        }

        // GET: Lavadoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lavadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo")] Lavadora lavadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lavadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lavadora);
        }

        // GET: Lavadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lavadora = await _context.Lavadora.FindAsync(id);
            if (lavadora == null)
            {
                return NotFound();
            }
            return View(lavadora);
        }

        // POST: Lavadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo")] Lavadora lavadora)
        {
            if (id != lavadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lavadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LavadoraExists(lavadora.Id))
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
            return View(lavadora);
        }

        // GET: Lavadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lavadora = await _context.Lavadora
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lavadora == null)
            {
                return NotFound();
            }

            return View(lavadora);
        }

        // POST: Lavadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lavadora = await _context.Lavadora.FindAsync(id);
            _context.Lavadora.Remove(lavadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LavadoraExists(int id)
        {
            return _context.Lavadora.Any(e => e.Id == id);
        }
    }
}
