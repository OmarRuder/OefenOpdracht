using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Studentnummer { get; set; }

        public List<Resultaat> Resultaten { get; set; }
        public List<StudentGroep> Groepen { get; set; }
    }
}
