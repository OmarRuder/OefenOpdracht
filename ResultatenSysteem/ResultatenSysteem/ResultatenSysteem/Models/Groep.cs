using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class Groep
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Groepscode { get; set; }

        public List<GroepVak> Vakken { get; set; }
        public List<StudentGroep> Studenten { get; set; }
    }
}
