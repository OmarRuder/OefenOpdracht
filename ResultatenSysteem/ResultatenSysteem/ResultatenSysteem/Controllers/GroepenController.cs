using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Data;
using ResultatenSysteem.Models;
using ResultatenSysteem.ViewModels;

namespace ResultatenSysteem.Controllers
{
    [Area("Medewerker")]
    public class GroepenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroepenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groepen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Groep.ToListAsync());
        }

        public  ViewResult Overzicht(int? id, int[] StudentId)
        {
            GroepStudentViewModel groepStudentViewModel = new GroepStudentViewModel()
            {
                Groep = _context.Groep.Include(g => g.Studenten).FirstOrDefault(sg => sg.Id == id),
            };
            ViewData["Groepen"] = _context.Groep.ToList();
            ViewData["Studenten"] = _context.Student.ToList();
            return View(groepStudentViewModel);

        }

        // GET: Groepen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groep = await _context.Groep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groep == null)
            {
                return NotFound();
            }

            return View(groep);
        }

        // GET: Groepen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groepen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Groepscode")] Groep groep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groep);
        }

        // GET: Groepen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groep = await _context.Groep.FindAsync(id);
            if (groep == null)
            {
                return NotFound();
            }
            return View(groep);
        }

        // POST: Groepen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Groepscode")] Groep groep)
        {
            if (id != groep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroepExists(groep.Id))
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
            return View(groep);
        }

        // GET: Groepen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groep = await _context.Groep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groep == null)
            {
                return NotFound();
            }

            return View(groep);
        }

        // POST: Groepen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groep = await _context.Groep.FindAsync(id);
            _context.Groep.Remove(groep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroepExists(int id)
        {
            return _context.Groep.Any(e => e.Id == id);
        }
    }
}
