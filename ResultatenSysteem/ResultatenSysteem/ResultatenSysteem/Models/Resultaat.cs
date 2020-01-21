using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class Resultaat
    {
        public int Id { get; set; }
        public double Beoordeling { get; set; }

        public Student Student { get; set; }
        public int StudentId { get; set; }

        public Vak Vak { get; set; }
        public int VakId { get; set; }
    }
}
