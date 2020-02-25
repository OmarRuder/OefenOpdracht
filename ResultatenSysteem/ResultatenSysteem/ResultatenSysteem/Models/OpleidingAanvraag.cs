using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class OpleidingAanvraag
    {
        public enum Status
        {
            Aangevraagd,
            InAfwachting,
            Goedgekeurd
        }
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Opmerking { get; set; }
        public DateTime AanvraagDatum { get; set; }
        public Status AanvraagStatus { get; set; }
        public List<Groep> Groepen { get; set; }
    }
}
