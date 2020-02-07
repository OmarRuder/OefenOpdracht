using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { } 
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string Gebruikersnummer { get; set; }
        public string ImgNaam { get; set; }
    }
}
