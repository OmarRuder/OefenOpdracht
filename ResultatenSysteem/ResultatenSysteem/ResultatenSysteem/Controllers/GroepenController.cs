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
            ViewData["Vakken"] = _context.Vak.ToList();
            var applicationDbContext = _context.Vak.Include(v => v.Groepen);
            return View(await _context.Groep.ToListAsync());
        }

        public ViewResult Overzicht(int? id, int[] StudentId)
        {
            GroepStudentViewModel gsvm = new GroepStudentViewModel()
            {
                Groep = _context.Groep.Include(g => g.Studenten).FirstOrDefault(sg => sg.Id == id),
                Student = _context.Student.Include(s => s.Groepen).ToList(),
                Vak = _context.Vak.Include(v => v.Groepen).ToList()
            };
            ViewData["Studenten"] = _context.Student.ToList();
            return View(gsvm);
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
        public IActionResult ResultaatInvoeren()
        {
            ViewData["Vakken"] = _context.Vak.ToList();

            return View();
        }

        // GET: Groepen/Create
        public IActionResult Create()
        {
            ViewData["Vakken"] = _context.Vak.ToList();
            return View();
        }

        // POST: Groepen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int[] VakId, [Bind("Id,Naam,Groepscode")] Groep groep)
        {
            List<GroepVak> UpdateList = new List<GroepVak>();

            foreach ( var item in VakId)
            {
                GroepVak gv = new GroepVak
                {
                    VakId = item
                };
                UpdateList.Add(gv);
            }
            groep.Vakken = UpdateList;
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
            ViewData["Vakken"] = _context.Vak.ToList();
            var existingGroep = _context.Groep.Include(gv => gv.Vakken).FirstOrDefault(gv => gv.Id == id);
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
        public async Task<IActionResult> Edit(int id, int[] VakId, [Bind("Id,Naam,Groepscode")] Groep groep)
        {
            if (id != groep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Groep existingGroep = _context.Groep.Include(gv => gv.Vakken).FirstOrDefault(gv => gv.Id == id);
                    existingGroep.Vakken.Clear();

                    foreach (var item in VakId)
                    {
                        GroepVak gv = new GroepVak
                        {
                            VakId = item,
                        };
                        existingGroep.Vakken.Add(gv);
                    }
                    existingGroep.Naam = groep.Naam;
                    existingGroep.Groepscode = groep.Groepscode;
                    existingGroep.Studenten = groep.Studenten;
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
