using ResultatenSysteem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public static class DataSeed
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.Groep.AddRange(
                new Groep()
                {
                    Naam = "Applicatie/Media-ontwikkelaar",
                    Groepscode = "017AO-A"
                },
                new Groep()
                {
                    Naam = "Applicatie/Media-ontwikkelaar",
                    Groepscode = "017AO-B"
                },
                new Groep()
                {
                    Naam = "Sociaal Maatschappelijk Werk",
                    Groepscode = "017SW-A"
                },
                new Groep()
                {
                    Naam = "Sociaal Maatschappelijk Werk",
                    Groepscode = "017SW-B"
                }
            );
            context.SaveChanges();
        }

        //public static async Task InsertGroep(ApplicationDbContext context)
        //{
        //    List<Groep> Groepen = new List<Groep>();
        //    Groep ao1 = new Groep
        //    {
                
        //    };
        //    Groepen.Add(ao1);
        //    Groep ao2 = new Groep
        //    {
        //        Naam = "Applicatie/Media-ontwikkelaar",
        //        Groepscode = "017AO-B",
        //    };
        //    Groepen.Add(ao2);
        //    Groep sw1 = new Groep
        //    {
        //        Naam = "Sociaal Maatschappelijk Werk",
        //        Groepscode = "017SW-A"
        //    };
        //    Groepen.Add(sw1);
        //    Groep sw2 = new Groep
        //    {
        //        Naam = "Sociaal Maatschappelijk Werk",
        //        Groepscode = "017SW-B"
        //    };
        //    Groepen.Add(sw2);

        //    foreach (var item in Groepen)
        //    {
        //        if (context.Groep.Where(g => g.Naam == item.Naam) == null)
        //        {
        //            context.Groep.Add(item);
        //        }
        //    }
        //    await context.SaveChangesAsync();
        //}


    }
}

           