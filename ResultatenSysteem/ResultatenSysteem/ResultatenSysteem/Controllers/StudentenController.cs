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
    [Area("Medewerker")]
    public class StudentenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Studenten
        public async Task<IActionResult> Index()
        {
            long studentnummer = DateTime.MaxValue.Ticks;
            Console.WriteLine(studentnummer);
            return View(await _context.Student.ToListAsync());
        }

        // GET: Studenten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);

            //ViewData["Groepen"] = _context.Groep.Include(s => s.Groepen).Where(sg => sg.Id == id).ToList();
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Studenten/Create
        public IActionResult Create()
        {
            var student = _context.Student.ToList();
       
            ViewData["Groepen"] = _context.Groep.ToList();
            return View();
        }

        // POST: Studenten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int [] GroepId, [Bind("Id,Voornaam,Achternaam,Tussenvoegsel,Studentnummer")] Student student)
        {
            List<StudentGroep> UpdateList = new List<StudentGroep>();
            string rs = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 2);
            Random generator = new Random();
            int ri = generator.Next(9999, 99999);
            var studentnummer = rs + ri.ToString();
            if ( _context.Student.Where(s => s.Studentnummer == studentnummer) == null )
            {
                student.Studentnummer = studentnummer;
            } else
            {
                student.Studentnummer = ri.ToString() + rs;
            }
            foreach (var item in GroepId)
            {
                StudentGroep sg = new StudentGroep
                {
                    GroepId = item
                };
                //sg.StudentId = student.Id;
                UpdateList.Add(sg);
            }

            student.Groepen = UpdateList;

            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Studenten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            ViewData["Groepen"] = _context.Groep.ToList();
            var existingStudent =  _context.Student.Include(sg => sg.Groepen).FirstOrDefault(sg => sg.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Studenten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int[] GroepId, [Bind("Id,Voornaam,Achternaam,Tussenvoegsel,Studentnummer")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }
       
            if (ModelState.IsValid)
            {
                try
                {
                    Student existingStudent = _context.Student.Include(s => s.Groepen).FirstOrDefault(s => s.Id == id);
                    existingStudent.Groepen.Clear();
                    foreach (var item in GroepId)
                    {
                        StudentGroep sg = new StudentGroep();
                        sg.GroepId = item;
                        existingStudent.Groepen.Add(sg);
                    }
                    existingStudent.Voornaam = student.Voornaam;
                    existingStudent.Tussenvoegsel = student.Tussenvoegsel;
                    existingStudent.Achternaam = student.Achternaam;
                    existingStudent.Studentnummer = student.Studentnummer;


                    //_context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Studenten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Studenten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
