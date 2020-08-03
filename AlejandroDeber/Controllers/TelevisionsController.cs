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
    public class TelevisionsController : Controller
    {
        private readonly MainContext _context;

        public TelevisionsController(MainContext context)
        {
            _context = context;
        }

        // GET: Televisions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Televison.ToListAsync());
        }

        // GET: Televisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var television = await _context.Televison
                .FirstOrDefaultAsync(m => m.Id == id);
            if (television == null)
            {
                return NotFound();
            }

            return View(television);
        }

        // GET: Televisions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Televisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo")] Television television)
        {
            if (ModelState.IsValid)
            {
                _context.Add(television);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(television);
        }

        // GET: Televisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var television = await _context.Televison.FindAsync(id);
            if (television == null)
            {
                return NotFound();
            }
            return View(television);
        }

        // POST: Televisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo")] Television television)
        {
            if (id != television.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(television);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelevisionExists(television.Id))
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
            return View(television);
        }

        // GET: Televisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var television = await _context.Televison
                .FirstOrDefaultAsync(m => m.Id == id);
            if (television == null)
            {
                return NotFound();
            }

            return View(television);
        }

        // POST: Televisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var television = await _context.Televison.FindAsync(id);
            _context.Televison.Remove(television);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelevisionExists(int id)
        {
            return _context.Televison.Any(e => e.Id == id);
        }
    }
}
