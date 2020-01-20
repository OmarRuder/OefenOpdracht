using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class StudentGroep
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Groep Groep { get; set; }
        public int GroepId { get; set; }
    }
}
