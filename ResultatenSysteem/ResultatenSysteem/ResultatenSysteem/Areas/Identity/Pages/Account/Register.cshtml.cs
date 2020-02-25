using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ResultatenSysteem.Data;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.Areas.Identity.Pages.Account
{
    [Area("Medewerker")]
    [Authorize(Roles = "Medewerker")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [EmailAddress]
            [Display(Name = "E-Mail")]
            public string Email { get; set; }

            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Wachtwoord")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Wachtwoord herhalen")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Voornaam")]
            public string Voornaam { get; set; }
            
            [Display(Name = "Tussenvoegsel")]
            public string Tussenvoegsel { get; set; }

            [Display(Name = "Tussenvoegsel")]
            public string Achternaam { get; set; }
            
        }

        public void OnGet(string actie, string voorNaam, string tussenVoegsel, string achterNaam, string aanvraagOpmerking, string returnUrl = null)
        {

            ViewData["Actie"] = actie;
            ViewData["Voornaam"] = voorNaam;
            ViewData["Tussenvoegsel"] = tussenVoegsel;
            ViewData["Achternaam"] = achterNaam;
            ViewData["Opmerking"] = aanvraagOpmerking;

            ViewData["Groepen"] = _context.Groep.ToList();
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(int[] GroepId, string returnUrl = null)
        {
            ViewData["Groepen"] = _context.Groep.ToList();

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string rs = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 2);
                Random generator = new Random();
                int ri = generator.Next(9999, 99999);
                var sgNummer = rs + ri.ToString();
                string password = "P@$$w0rd!";
                var email = sgNummer + "@wrx.sdt";
                //string username = Input.Voornaam + " " + Input.Achternaam;
                var user = new ApplicationUser { UserName = email, Email = email, Gebruikersnummer = sgNummer};
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    List<StudentGroep> UpdateList = new List<StudentGroep>();
                    foreach (var groep in GroepId)
                    {
                        StudentGroep sg = new StudentGroep
                        {
                            GroepId = groep
                        };
                        UpdateList.Add(sg);
                    }
                    var student = new Student { Voornaam = Input.Voornaam, Tussenvoegsel = Input.Tussenvoegsel, Achternaam = Input.Achternaam, Email = email, Studentnummer = sgNummer };
                    student.Groepen = UpdateList;
                    _context.Student.Add(student);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Bevestig je account door <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>hier</a> te klikken.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
