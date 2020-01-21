using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class Vak
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Vakcode { get; set; }

        public List<Resultaat> Resultaten { get; set; }
        public List<GroepVak> Groepen { get; set; }
    }
}
