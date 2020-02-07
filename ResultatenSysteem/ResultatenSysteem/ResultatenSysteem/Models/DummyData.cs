using Microsoft.AspNetCore.Identity;
using ResultatenSysteem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResultatenSysteem.Models
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                                            UserManager<ApplicationUser> userManager,                            
                                            RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string medewerkerId = "";
            string medewerker = "Medewerker";
            string medewerkerDesc = "Medewerker van WRX Hogere School";

            string student = "Student";
            string studentDesc = "Student van WRX Hogere School";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(medewerker) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(medewerker, medewerkerDesc));
            }
            if (await roleManager.FindByNameAsync(student) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(student, studentDesc));
            }

            if (await userManager.FindByNameAsync("omarruder@wrx.hgs") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "omarruder@wrx.hgs",
                    Email = "omarruder@wrx.hgs",
                    Voornaam = "Omar",
                    Achternaam = "Ruder",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "140553"
                };

                Console.WriteLine("omarruder@wrx.hgs bestaat nog niet en we zitten nu in de functie!");

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    Console.WriteLine("het is gelukt");
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, medewerker);
                }
                medewerkerId = user.Id;
            }

            if (await userManager.FindByNameAsync("issyruder@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "issyruder@wrx.sdt",
                    Email = "issyruder@wrx.sdt",
                    Voornaam = "Issy",
                    Achternaam = "Ruder",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "142312"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }

            if (await userManager.FindByNameAsync("wiibebruins@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "wiibebruins@wrx.sdt",
                    Email = "wiibebruins@wrx.sdt",
                    Voornaam = "Wiibe",
                    Achternaam = "Bruins",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "421245"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }


            if (await userManager.FindByNameAsync("othmanotay@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "othmanotay@wrx.sdt",
                    Email = "othmanotay@wrx.sdt",
                    Voornaam = "Othman",
                    Achternaam = "Otay",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "134902"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }

            if (await userManager.FindByNameAsync("zahirarafik@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "zahirarafik@wrx.sdt",
                    Email = "zahirarafik@wrx.sdt",
                    Voornaam = "Zahira",
                    Achternaam = "Rafik",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "352553"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }

            if (await userManager.FindByNameAsync("daveroeder@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "daveroeder@wrx.sdt",
                    Email = "daveroeder@wrx.sdt",
                    Voornaam = "Dave",
                    Achternaam = "Roeder",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "drA231"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }

            if (await userManager.FindByNameAsync("lesleyvlaar@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "lesleyvlaar@wrx.sdt",
                    Email = "lesleyvlaar@wrx.sdt",
                    Voornaam = "Lesley",
                    Achternaam = "Vlaar",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "691420"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }


            if (await userManager.FindByNameAsync("jannobijl@wrx.sdt") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "jannobijl@wrx.sdt",
                    Email = "jannobijl@wrx.sdt",
                    Voornaam = "Janno",
                    Achternaam = "Bijl",
                    ImgNaam = "default.png",
                    Gebruikersnummer = "132431"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, student);
                }
            }

        }
    }
}
