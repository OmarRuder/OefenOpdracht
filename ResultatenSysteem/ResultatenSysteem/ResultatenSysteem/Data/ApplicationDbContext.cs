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
        }

        public DbSet<ResultatenSysteem.Models.Student> Student { get; set; }

        public DbSet<ResultatenSysteem.Models.Groep> Groep{ get; set; }

        public DbSet<ResultatenSysteem.Models.Resultaat> Resultaat { get; set; }

        public DbSet<ResultatenSysteem.Models.Vak> Vak { get; set; }

    }
}
