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
    public class ResultatenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultatenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Resultaten
        public async Task<IActionResult> Index(string searchString, int groepId, int Id)
        {
            ViewData["Studenten"] = _context.Student.OrderBy(s => s.Voornaam).ToList();
            ViewData["Groepen"] = _context.Groep.Include(g => g.Studenten).ToList();

            var studentInfo = _context.Student.Join(_context.StudentGroep,
            s => s.Id,
            sg => sg.StudentId,
            (s, sg) => new { Student = s, StudentGroep = sg })
            .Where(x => x.StudentGroep.GroepId == groepId)
            .Select(x => x.Student)
            .ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewData["Studenten"] = _context.Student.Where(s => s.Voornaam.Contains(searchString)).ToList();
            }
            if (Id >= 1)
            {
                ViewData["Studenten"] = _context.Student.Where(s => s.Id == Id).ToList();
            }
            if (groepId >= 1)
            {
                ViewData["Studenten"] = studentInfo.ToList();
                if (!String.IsNullOrEmpty(searchString))
                {
                    ViewData["Studenten"] = studentInfo.Where(s => s.Voornaam.Contains(searchString) || s.Achternaam.Contains(searchString)).ToList();
                }
            }

            var applicationDbContext = _context.Resultaat.Include(r => r.Student).Include(r => r.Vak).OrderBy(r => r.VakId);
            return View(await applicationDbContext.ToListAsync());
        }


        // combined query om searchstring op te vullen met zowel voornaam als tussen voegsel als achternaam
        //(niet werkend)
        //var studentInfo = _context.Student.Join(_context.StudentGroep,
        //st => st.Id,
        //stg => stg.StudentId,
        //(st, stg) => new { Student = st, StudentGroep = stg })
        //.Where(x => x.StudentGroep.GroepId == groepId)
        //.Select(s =>
        //new
        //{
        //    s.Student,

        //    searchString = string.IsNullOrEmpty(s.Student.Tussenvoegsel)
        //       ? s.Student.Voornaam + " " + s.Student.Achternaam
        //       : s.Student.Voornaam + " " + s.Student.Tussenvoegsel + " " + s.Student.Achternaam,
        //})
        //.ToList();

        public async Task<IActionResult> Aanpassen(int studentId)
        {
            // Hier wordt viewdata student gevuld met maar 1 student, om de view dynamisch te maken (aanpassen van student x) indien de view maar 1 student betreft.
            ViewData["Student"] = _context.Student.Where(s => s.Id == studentId).ToList();

            // Hier wordt de context gevuld met alle resultaten
            var applicationDbContext = _context.Resultaat.Include(r => r.Student).Where(s => s.StudentId == studentId).Include(r => r.Vak).OrderBy(s => s.Student.Voornaam);
            if (studentId < 1) // als er een studentid meegegeven is wordt de context gevuld met alle studenten met hetzelfde id
            {
                applicationDbContext = _context.Resultaat.Include(r => r.Student).Include(r => r.Vak).OrderBy(r => r.VakId);
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // async task aanpassen maar dan filterbaar op naam

        //ViewData["Student"] = _context.Student.ToList();
        //var applicationDbContext = _context.Resultaat.Include(r => r.Student).Where(s => s.StudentId == studentId).Include(r => r.Vak).OrderBy(s => s.Student.Voornaam);

        //if (!String.IsNullOrEmpty(searchString))
        //{
        //    ViewData["Student"] = _context.Student.Where(s => s.Voornaam.Contains(searchString)).ToList();
        //    applicationDbContext = _context.Resultaat.Include(r => r.Student).Where(s => s.Student.Voornaam.Contains(searchString)).Include(r => r.Vak).OrderBy(r => r.VakId);

        //}
        //else
        //{
        //    applicationDbContext = _context.Resultaat.Include(r => r.Student).Include(r => r.Vak).OrderBy(s => s.Student.Voornaam);
        //}

        // GET: Resultaten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultaat = await _context.Resultaat
                .Include(r => r.Student)
                .Include(r => r.Vak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultaat == null)
            {
                return NotFound();
            }

            return View(resultaat);
        }

        // GET: Resultaten/Create
        public IActionResult Create(string forStudent)
        {
            var studenten = _context.Student.ToList();
            var studentInfo = _context.Student
                .Select(s =>
                new
                {
                    s.Id,
                    Naam = string.IsNullOrEmpty(s.Tussenvoegsel)
                    ? s.Voornaam + " " + s.Achternaam + " - " + s.Studentnummer
                    : s.Voornaam + " " + s.Tussenvoegsel + " " + s.Achternaam + " - " + s.Studentnummer,
                    forStudent = s.Studentnummer + "-" + s.Achternaam
                });

            ViewBag.Studenten = new SelectList(studentInfo, "Id", "Naam");
            if (!String.IsNullOrEmpty(forStudent))
            {
                ViewBag.Studenten = new SelectList(studentInfo.Where(s => s.forStudent == forStudent), "Id", "Naam");
            }
            //ViewData["Student"] = new SelectList(studentInfo, "Id", "Voornaam");
            ViewData["VakId"] = new SelectList(_context.Set<Vak>(), "Id", "Naam");
            return View();
        }

        // POST: Resultaten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(double Cijfer, [Bind("Id,Beoordeling,StudentId,VakId")] Resultaat resultaat)
        {

            resultaat.Beoordeling = Cijfer;
            if (ModelState.IsValid)
            {
                _context.Add(resultaat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Voornaam", resultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Set<Vak>(), "Id", "Naam", resultaat.VakId);
            return View(resultaat);
        }

        // GET: Resultaten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultaat = await _context.Resultaat.FindAsync(id);
            if (resultaat == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Achternaam", resultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Set<Vak>(), "Id", "Naam", resultaat.VakId);
            return View(resultaat);
        }

        // POST: Resultaten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Beoordeling,StudentId,VakId")] Resultaat resultaat)
        {
            if (id != resultaat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultaat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultaatExists(resultaat.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Achternaam", resultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Set<Vak>(), "Id", "Naam", resultaat.VakId);
            return View(resultaat);
        }

        // GET: Resultaten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultaat = await _context.Resultaat
                .Include(r => r.Student)
                .Include(r => r.Vak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultaat == null)
            {
                return NotFound();
            }

            return View(resultaat);
        }

        // POST: Resultaten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultaat = await _context.Resultaat.FindAsync(id);
            _context.Resultaat.Remove(resultaat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultaatExists(int id)
        {
            return _context.Resultaat.Any(e => e.Id == id);
        }
    }
}
