using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.ViewModels
{
    public class ResultatenStudentViewModel
    {
        public List<Vak> Vak { get; set; }
        public List<Resultaat> Resultaat { get; set; }
        public List<Student> Student { get; set; }
    }
}
