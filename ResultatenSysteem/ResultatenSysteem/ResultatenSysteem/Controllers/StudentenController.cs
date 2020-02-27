using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Data;
using ResultatenSysteem.Models;
using ResultatenSysteem.ViewModels;

namespace ResultatenSysteem.Controllers
{
    [Authorize]
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

            //ViewData["Groepen"] = _context.Groep.Include(s => s.Studenten).Where(sg => sg.Id == id).ToList();
            ViewData["Groepen"] = _context.StudentGroep.Where(sg => sg.StudentId == id).Include(s => s.Groep).Where(g => g.Groep.Id == g.GroepId).ToList();
            ViewData["Resultaten"] = _context.Resultaat.Where(r => r.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Studenten/Create
        public IActionResult Create()
        {
            //var student = _context.Student.ToList();
       
            ViewData["Groepen"] = _context.Groep.ToList();
            return View();
        }


        //public static string RandomPassword()
        //{
        //    string rs = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 2);
        //    Random generator = new Random();
        //    int ri = generator.Next(9999, 99999);
        //    string pass = rs + ri.ToString();
        //    return pass;
        //}

        // POST: Studenten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int [] GroepId, [Bind("Id,Voornaam,Achternaam,Tussenvoegsel,Studentnummer")] Student student)
        {
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

            List<StudentGroep> UpdateList = new List<StudentGroep>();
            foreach (var groep in GroepId)
            {
                StudentGroep sg = new StudentGroep
                {
                    GroepId = groep
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
                        StudentGroep sg = new StudentGroep
                        {
                            GroepId = item
                        };
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

        public async Task<IActionResult> DeleteStudent(int? id)
        {
            var student = await _context.Student
                .FirstOrDefaultAsync(s => s.Id == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
