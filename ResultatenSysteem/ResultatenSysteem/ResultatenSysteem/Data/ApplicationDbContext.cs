using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentGroep>().HasKey(sg => new { sg.StudentId, sg.GroepId });
            modelBuilder.Entity<GroepVak>().HasKey(gv => new { gv.GroepId, gv.VakId });

            modelBuilder.Entity<Groep>().HasData(
                new Groep { Id = 1, Groepscode = "017AO-A", Naam = "Applicatie/media-ontwikkelaar" },
                new Groep { Id = 2, Groepscode = "017AO-B", Naam = "Applicatie/media-ontwikkelaar" },
                new Groep { Id = 3, Groepscode = "017SMW-A", Naam = "Sociaal/maatschappelijk-medewerker" },
                new Groep { Id = 4, Groepscode = "017SMW-B", Naam = "Sociaal/maatschappelijk-medewerker" });

            modelBuilder.Entity<Vak>().HasData(
                new Vak { Id = 1, Vakcode = "EN", Naam = "Engels" },
                new Vak { Id = 2, Vakcode = "WI", Naam = "Wiskunde" },
                new Vak { Id = 3, Vakcode = "PRG1", Naam = "C# Programmeren" },
                new Vak { Id = 4, Vakcode = "NE", Naam = "Nederlands" });

            modelBuilder.Entity<GroepVak>().HasData(
                new GroepVak { GroepId = 1, VakId = 1 },
                new GroepVak { GroepId = 1, VakId = 2 },
                new GroepVak { GroepId = 1, VakId = 3 },
                new GroepVak { GroepId = 1, VakId = 4 },
                new GroepVak { GroepId = 2, VakId = 1 },
                new GroepVak { GroepId = 2, VakId = 2 },
                new GroepVak { GroepId = 2, VakId = 3 },
                new GroepVak { GroepId = 2, VakId = 4 },
                new GroepVak { GroepId = 3, VakId = 1 },
                new GroepVak { GroepId = 3, VakId = 4 },
                new GroepVak { GroepId = 4, VakId = 1 },
                new GroepVak { GroepId = 4, VakId = 4 });


            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Voornaam = "Omar", Achternaam = "Ruder", Studentnummer = "123054"},
                new Student { Id = 2, Voornaam = "Issy", Achternaam = "Ruder", Studentnummer = "142312"},
                new Student { Id = 3, Voornaam = "Ruben", Achternaam = "Ruder", Studentnummer = "421245"},
                new Student { Id = 4, Voornaam = "Tremaine", Achternaam = "Goodreid", Studentnummer = "236789"},
                new Student { Id = 5, Voornaam = "Douglass", Achternaam = "Stiles", Studentnummer = "352553"},
                new Student { Id = 6, Voornaam = "Becky", Achternaam = "Blackford", Studentnummer = "140443"}
                );

            modelBuilder.Entity<Resultaat>().HasData(
                new Resultaat { Id = 1, Beoordeling = 7.5, StudentId = 1, VakId = 1},
                new Resultaat { Id = 2, Beoordeling = 8.4, StudentId = 1, VakId = 2 },
                new Resultaat { Id = 3, Beoordeling = 6.4, StudentId = 1, VakId = 3 },
                new Resultaat { Id = 4, Beoordeling = 6.4, StudentId = 3, VakId = 1 },
                new Resultaat { Id = 5, Beoordeling = 9.5, StudentId = 3, VakId = 4 },
                new Resultaat { Id = 6, Beoordeling = 3.4, StudentId = 5, VakId = 1 },
                new Resultaat { Id = 7, Beoordeling = 9.5, StudentId = 6, VakId = 3 });


            modelBuilder.Entity<StudentGroep>().HasData(
                new StudentGroep { StudentId = 1, GroepId = 2},
                new StudentGroep { StudentId = 1, GroepId = 4 },
                new StudentGroep { StudentId = 2, GroepId = 3 },
                new StudentGroep { StudentId = 3, GroepId = 3 },
                new StudentGroep { StudentId = 4, GroepId = 2 },
                new StudentGroep { StudentId = 5, GroepId = 3 },
                new StudentGroep { StudentId = 5, GroepId = 1 },
                new StudentGroep { StudentId = 6, GroepId = 1 });
        }



        public DbSet<ResultatenSysteem.Models.Student> Student { get; set; }
        public DbSet<ResultatenSysteem.Models.StudentGroep> StudentGroep { get; set; }
        public DbSet<ResultatenSysteem.Models.Groep> Groep{ get; set; }
        public DbSet<ResultatenSysteem.Models.Resultaat> Resultaat { get; set; }
        public DbSet<ResultatenSysteem.Models.Vak> Vak { get; set; }

    }
}
