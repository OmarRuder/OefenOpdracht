using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class GroepVak
    {
        public Groep Groep { get; set; }
        public int GroepId { get; set; }

        public Vak Vak { get; set; }
        public int VakId { get; set; }
    }
}
