using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.ViewModels
{
    public class GroepStudentViewModel
    {
        public Groep Groep { get; set; }
        public List<StudentGroep> Student { get; set; }
    }
}
