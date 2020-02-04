﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResultatenSysteem.Data;

namespace ResultatenSysteem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200128195819_vakHasData-resultaatHasData-groepVakHasData")]
    partial class vakHasDataresultaatHasDatagroepVakHasData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ResultatenSysteem.Models.Groep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Groepscode")
                        .IsRequired();

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Groep");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Groepscode = "017AO-A",
                            Naam = "Applicatie/media-ontwikkelaar"
                        },
                        new
                        {
                            Id = 2,
                            Groepscode = "017AO-B",
                            Naam = "Applicatie/media-ontwikkelaar"
                        },
                        new
                        {
                            Id = 3,
                            Groepscode = "017SMW-A",
                            Naam = "Sociaal/maatschappelijk-medewerker"
                        },
                        new
                        {
                            Id = 4,
                            Groepscode = "017SMW-B",
                            Naam = "Sociaal/maatschappelijk-medewerker"
                        });
                });

            modelBuilder.Entity("ResultatenSysteem.Models.GroepVak", b =>
                {
                    b.Property<int>("GroepId");

                    b.Property<int>("VakId");

                    b.HasKey("GroepId", "VakId");

                    b.HasIndex("VakId");

                    b.ToTable("GroepVak");

                    b.HasData(
                        new
                        {
                            GroepId = 1,
                            VakId = 1
                        },
                        new
                        {
                            GroepId = 1,
                            VakId = 2
                        },
                        new
                        {
                            GroepId = 1,
                            VakId = 3
                        },
                        new
                        {
                            GroepId = 1,
                            VakId = 4
                        },
                        new
                        {
                            GroepId = 2,
                            VakId = 1
                        },
                        new
                        {
                            GroepId = 2,
                            VakId = 2
                        },
                        new
                        {
                            GroepId = 2,
                            VakId = 3
                        },
                        new
                        {
                            GroepId = 2,
                            VakId = 4
                        },
                        new
                        {
                            GroepId = 3,
                            VakId = 1
                        },
                        new
                        {
                            GroepId = 3,
                            VakId = 4
                        },
                        new
                        {
                            GroepId = 4,
                            VakId = 1
                        },
                        new
                        {
                            GroepId = 4,
                            VakId = 4
                        });
                });

            modelBuilder.Entity("ResultatenSysteem.Models.Resultaat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Beoordeling");

                    b.Property<int>("StudentId");

                    b.Property<int>("VakId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("VakId");

                    b.ToTable("Resultaat");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Beoordeling = 7.5,
                            StudentId = 1,
                            VakId = 1
                        },
                        new
                        {
                            Id = 2,
                            Beoordeling = 8.4000000000000004,
                            StudentId = 1,
                            VakId = 2
                        },
                        new
                        {
                            Id = 3,
                            Beoordeling = 6.4000000000000004,
                            StudentId = 1,
                            VakId = 3
                        },
                        new
                        {
                            Id = 4,
                            Beoordeling = 6.4000000000000004,
                            StudentId = 3,
                            VakId = 1
                        },
                        new
                        {
                            Id = 5,
                            Beoordeling = 9.5,
                            StudentId = 3,
                            VakId = 4
                        },
                        new
                        {
                            Id = 6,
                            Beoordeling = 3.3999999999999999,
                            StudentId = 5,
                            VakId = 1
                        },
                        new
                        {
                            Id = 7,
                            Beoordeling = 9.5,
                            StudentId = 6,
                            VakId = 3
                        });
                });

            modelBuilder.Entity("ResultatenSysteem.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam")
                        .IsRequired();

                    b.Property<string>("Studentnummer");

                    b.Property<string>("Tussenvoegsel");

                    b.Property<string>("Voornaam")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Achternaam = "Ruder",
                            Studentnummer = "123054",
                            Voornaam = "Omar"
                        },
                        new
                        {
                            Id = 2,
                            Achternaam = "Ruder",
                            Studentnummer = "142312",
                            Voornaam = "Issy"
                        },
                        new
                        {
                            Id = 3,
                            Achternaam = "Ruder",
                            Studentnummer = "421245",
                            Voornaam = "Ruben"
                        },
                        new
                        {
                            Id = 4,
                            Achternaam = "Goodreid",
                            Studentnummer = "236789",
                            Voornaam = "Tremaine"
                        },
                        new
                        {
                            Id = 5,
                            Achternaam = "Stiles",
                            Studentnummer = "352553",
                            Voornaam = "Douglass"
                        },
                        new
                        {
                            Id = 6,
                            Achternaam = "Blackford",
                            Studentnummer = "140443",
                            Voornaam = "Becky"
                        });
                });

            modelBuilder.Entity("ResultatenSysteem.Models.StudentGroep", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("GroepId");

                    b.HasKey("StudentId", "GroepId");

                    b.HasIndex("GroepId");

                    b.ToTable("StudentGroep");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            GroepId = 2
                        },
                        new
                        {
                            StudentId = 1,
                            GroepId = 4
                        },
                        new
                        {
                            StudentId = 2,
                            GroepId = 3
                        },
                        new
                        {
                            StudentId = 3,
                            GroepId = 3
                        },
                        new
                        {
                            StudentId = 4,
                            GroepId = 2
                        },
                        new
                        {
                            StudentId = 5,
                            GroepId = 3
                        },
                        new
                        {
                            StudentId = 5,
                            GroepId = 1
                        },
                        new
                        {
                            StudentId = 6,
                            GroepId = 1
                        });
                });

            modelBuilder.Entity("ResultatenSysteem.Models.Vak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired();

                    b.Property<string>("Vakcode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Vak");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naam = "Engels",
                            Vakcode = "EN"
                        },
                        new
                        {
                            Id = 2,
                            Naam = "Wiskunde",
                            Vakcode = "WI"
                        },
                        new
                        {
                            Id = 3,
                            Naam = "C# Programmeren",
                            Vakcode = "PRG1"
                        },
                        new
                        {
                            Id = 4,
                            Naam = "Nederlands",
                            Vakcode = "NE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ResultatenSysteem.Models.GroepVak", b =>
                {
                    b.HasOne("ResultatenSysteem.Models.Groep", "Groep")
                        .WithMany("Vakken")
                        .HasForeignKey("GroepId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ResultatenSysteem.Models.Vak", "Vak")
                        .WithMany("Groepen")
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ResultatenSysteem.Models.Resultaat", b =>
                {
                    b.HasOne("ResultatenSysteem.Models.Student", "Student")
                        .WithMany("Resultaten")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ResultatenSysteem.Models.Vak", "Vak")
                        .WithMany("Resultaten")
                        .HasForeignKey("VakId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ResultatenSysteem.Models.StudentGroep", b =>
                {
                    b.HasOne("ResultatenSysteem.Models.Groep", "Groep")
                        .WithMany("Studenten")
                        .HasForeignKey("GroepId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ResultatenSysteem.Models.Student", "Student")
                        .WithMany("Groepen")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}