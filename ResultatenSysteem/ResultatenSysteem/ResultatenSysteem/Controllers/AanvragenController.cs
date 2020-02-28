using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Data;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.Controllers
{
    public class AanvragenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AanvragenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aanvragen
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpleidingAanvraag.ToListAsync());
        }

        // GET: Aanvragen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opleidingAanvraag = await _context.OpleidingAanvraag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opleidingAanvraag == null)
            {
                return NotFound();
            }

            return View(opleidingAanvraag);
        }

        // GET: Aanvragen/Create
        public IActionResult Create()
        {
            ViewData["Groepen"] = _context.Groep.ToList();
            return View();
        }

        // POST: Aanvragen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Voornaam,Tussenvoegsel,Achternaam,Opmerking,AanvraagStatus")] OpleidingAanvraag opleidingAanvraag)
        {
            opleidingAanvraag.AanvraagStatus = OpleidingAanvraag.Status.Aangevraagd;
            opleidingAanvraag.AanvraagDatum = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(opleidingAanvraag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opleidingAanvraag);
        }

        // GET: Aanvragen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opleidingAanvraag = await _context.OpleidingAanvraag.FindAsync(id);
            if (opleidingAanvraag == null)
            {
                return NotFound();
            }
            return View(opleidingAanvraag);
        }

        // POST: Aanvragen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Voornaam,Tussenvoegsel,Achternaam,Opmerking,opleiding-aanvragen_aanvraag-status")] OpleidingAanvraag opleidingAanvraag)
        {
            if (id != opleidingAanvraag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opleidingAanvraag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpleidingAanvraagExists(opleidingAanvraag.Id))
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
            return View(opleidingAanvraag);
        }

        // GET: Aanvragen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opleidingAanvraag = await _context.OpleidingAanvraag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opleidingAanvraag == null)
            {
                return NotFound();
            }

            return View(opleidingAanvraag);
        }

        // POST: Aanvragen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opleidingAanvraag = await _context.OpleidingAanvraag.FindAsync(id);
            _context.OpleidingAanvraag.Remove(opleidingAanvraag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpleidingAanvraagExists(int id)
        {
            return _context.OpleidingAanvraag.Any(e => e.Id == id);
        }
    }
}
