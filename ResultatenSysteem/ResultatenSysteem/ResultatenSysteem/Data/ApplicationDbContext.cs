using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //dataseed
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
                new Student { Id = 1, Voornaam = "Omar", Achternaam = "Ruder", Studentnummer = "140553", Email = "omarruder@wrx.hgs"},
                new Student { Id = 2, Voornaam = "Issy", Achternaam = "Ruder", Studentnummer = "142312", Email = "issyruder@wrx.sdt"},
                new Student { Id = 3, Voornaam = "Wiibe", Achternaam = "Bruins", Studentnummer = "421245", Email = "wiibebruins@wrx.sdt" },
                new Student { Id = 4, Voornaam = "Othman", Achternaam = "Otay", Studentnummer = "134902", Email = "othmanotay@wrx.sdt" },
                new Student { Id = 5, Voornaam = "Zahira", Achternaam = "Rafik", Studentnummer = "352553", Email = "zahirarafik@wrx.sdt" },
                new Student { Id = 6, Voornaam = "Dave", Achternaam = "Roeder", Studentnummer = "drA231", Email = "daveroeder@wrx.sdt" },
                new Student { Id = 7, Voornaam = "Lesley", Achternaam = "Vlaar", Studentnummer = "691420", Email = "lesleyvlaar@wrx.sdt" },
                new Student { Id = 8, Voornaam = "Janno", Achternaam = "Bijl", Studentnummer = "132431", Email = "jannobijl@wrx.sdt" } );

            modelBuilder.Entity<Resultaat>().HasData(
                new Resultaat { Id = 1, Beoordeling = 7.5, StudentId = 1, VakId = 1, InvoerDatum = DateTime.Now},
                new Resultaat { Id = 2, Beoordeling = 8.4, StudentId = 1, VakId = 2, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 3, Beoordeling = 6.4, StudentId = 1, VakId = 3, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 4, Beoordeling = 6.4, StudentId = 3, VakId = 1, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 5, Beoordeling = 9.5, StudentId = 3, VakId = 4, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 6, Beoordeling = 3.4, StudentId = 5, VakId = 1, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 7, Beoordeling = 9.5, StudentId = 6, VakId = 2, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 8, Beoordeling = 4.3, StudentId = 7, VakId = 3, InvoerDatum = DateTime.Now },
                new Resultaat { Id = 9, Beoordeling = 5.5, StudentId = 8, VakId = 4, InvoerDatum = DateTime.Now }
                );


            modelBuilder.Entity<StudentGroep>().HasData(
                new StudentGroep { StudentId = 1, GroepId = 2 },
                new StudentGroep { StudentId = 1, GroepId = 4 },
                new StudentGroep { StudentId = 2, GroepId = 3 },
                new StudentGroep { StudentId = 3, GroepId = 3 },
                new StudentGroep { StudentId = 4, GroepId = 2 },
                new StudentGroep { StudentId = 5, GroepId = 3 },
                new StudentGroep { StudentId = 5, GroepId = 1 },
                new StudentGroep { StudentId = 6, GroepId = 1 },
                new StudentGroep { StudentId = 7, GroepId = 2 },
                new StudentGroep { StudentId = 7, GroepId = 4 },
                new StudentGroep { StudentId = 8, GroepId = 3 });

        }

        public DbSet<ResultatenSysteem.Models.Student> Student { get; set; }
        public DbSet<ResultatenSysteem.Models.StudentGroep> StudentGroep { get; set; }
        public DbSet<ResultatenSysteem.Models.Groep> Groep{ get; set; }
        public DbSet<ResultatenSysteem.Models.Resultaat> Resultaat { get; set; }
        public DbSet<ResultatenSysteem.Models.Vak> Vak { get; set; }
        public DbSet<ResultatenSysteem.Models.OpleidingAanvraag> OpleidingAanvraag { get; set; }

    }
}
