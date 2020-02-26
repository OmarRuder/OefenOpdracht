using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Data;
using ResultatenSysteem.Models;
using ResultatenSysteem.ViewModels;

namespace ResultatenSysteem.Areas.Medewerker.Controllers
{
    [Area("Medewerker")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
            DashboardViewModel dvm = new DashboardViewModel
            {
                Groepen = _context.Groep.Include(g => g.Studenten).ToList(),
                Resultaten = _context.Resultaat.ToList(),
                Aanvragen = _context.OpleidingAanvraag.ToList(),
                Studenten = _context.Student.ToList()
            };

            return View(dvm);
        }
    }
}

