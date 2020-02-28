using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Data;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.Controllers
{
    [Authorize]
    [Area("Medewerker")]
    public class VakkenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VakkenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vakken
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vak.ToListAsync());
        }

        // GET: Vakken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // GET: Vakken/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vakken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Vakcode")] Vak vak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vak);
        }

        [HttpPost]
        public async Task<IActionResult> QuickCreate(string vakNaam, string vakCode, [Bind("Id,Naam,Vakcode")] Vak vak)
        {
            vak.Naam = vakNaam;
            vak.Vakcode = vakCode;
            if (ModelState.IsValid)
            {
                Console.WriteLine("Modelstate is valid, vak " + vak.Naam);
                _context.Add(vak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //return RedirectToAction("Index", "Dashboard");
            }
            return View();
            //return View("../Views/Dashboard/Index.cshtml");

        }

        // GET: Vakken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak.FindAsync(id);
            if (vak == null)
            {
                return NotFound();
            }
            return View(vak);
        }

        // POST: Vakken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Vakcode")] Vak vak)
        {
            if (id != vak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakExists(vak.Id))
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
            return View(vak);
        }

        // GET: Vakken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = await _context.Vak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // POST: Vakken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vak = await _context.Vak.FindAsync(id);
            _context.Vak.Remove(vak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VakExists(int id)
        {
            return _context.Vak.Any(e => e.Id == id);
        }
    }
}
