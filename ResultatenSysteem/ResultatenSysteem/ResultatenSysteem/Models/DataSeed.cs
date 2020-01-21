using ResultatenSysteem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class DataSeed
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            await InsertGroep(context);
        }

        public static async Task InsertGroep(ApplicationDbContext context)
        {
            List<Groep> Groepen = new List<Groep>();
            Groep ao1 = new Groep
            {
                Naam = "Applicatie/Media-ontwikkelaar",
                Groepscode = "017AO-A",
            };
            Groepen.Add(ao1);
            Groep ao2 = new Groep
            {
                Naam = "Applicatie/Media-ontwikkelaar",
                Groepscode = "017AO-B",
            };
            Groepen.Add(ao2);
            Groep sw1 = new Groep
            {
                Naam = "Sociaal Maatschappelijk Werk",
                Groepscode = "017SW-A"
            };
            Groepen.Add(sw1);
            Groep sw2 = new Groep
            {
                Naam = "Sociaal Maatschappelijk Werk",
                Groepscode = "017SW-B"
            };
            Groepen.Add(sw2);

            foreach (var item in Groepen)
            {
                if (context.Groep.Where(g => g.Naam == item.Naam) == null)
                {
                    context.Groep.Add(item);
                }
            }
            await context.SaveChangesAsync();
        }


    }
}

           