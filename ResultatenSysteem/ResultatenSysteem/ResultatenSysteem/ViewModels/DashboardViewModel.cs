using ResultatenSysteem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.ViewModels
{
    public class DashboardViewModel
    {
        public List<Groep> Groepen { get; set; }
        public List<Student> Studenten { get; set; }
        public List<Resultaat> Resultaten { get; set; }
        public List<OpleidingAanvraag> Aanvragen { get; set; }
    }
}
