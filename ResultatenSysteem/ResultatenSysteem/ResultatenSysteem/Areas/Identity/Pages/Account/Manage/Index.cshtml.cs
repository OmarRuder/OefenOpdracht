using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResultatenSysteem.Models;

namespace ResultatenSysteem.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;
        private static string generatedImgName;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            /*IEmailSender emailSender, */IWebHostEnvironment env)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
            _env = env;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public string ImgNaam { get; set; }

            public string StyleSheet { get; set; }
            public string[] AvailableStyleSheets = new[] { "sb-admin-2", "purple-sb-admin-2", "green-sb-admin-2", "dark-sb-admin-2" };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = user.UserName;
            var email = user.Email;
            var imgNaam = user.ImgNaam;
            var styleSheet = user.ChosenTheme;
            var phoneNumber = user.PhoneNumber;

            Username = userName;

            Input = new InputModel
            {
                Email = email,
                PhoneNumber = phoneNumber,
                ImgNaam = imgNaam,
                StyleSheet = styleSheet
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            if (Input.ImgNaam != null)
            {
                UploadFile(file, _env);
                if (user.ImgNaam != "default.png")
                {
                    DeleteFile(file, _env, user.ImgNaam, user);
                }
                user.ImgNaam = generatedImgName;
            }

            if(!Input.AvailableStyleSheets.Contains(Input.StyleSheet))
            {
                Input.StyleSheet = Input.AvailableStyleSheets[0];
            }

            user.ChosenTheme = Input.StyleSheet;
          
            await _userManager.UpdateAsync(user);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Je profiel is bewerkt!";
            return RedirectToPage();
        }

        private void UploadFile(IFormFile file, IWebHostEnvironment env)
        {
            Random random = new Random();
            string RandomString(int length)
            {
                const string allowedChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                return new string(Enumerable.Repeat(allowedChar, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            var imgName = RandomString(15) + ".png";
            generatedImgName = imgName; //private generatedImgName = generated imgname
            var path = Path.Combine(env.WebRootPath + "/userImg/" + generatedImgName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }

        private void DeleteFile(IFormFile file, IWebHostEnvironment env, string existingFile, ApplicationUser user)
        {
            Console.WriteLine("current existing file is: " + existingFile);
            Console.WriteLine("userfile is:" + user.ImgNaam);
            var path = (Path.Combine(env.WebRootPath + "/userImg/" + existingFile));
            //System.IO.File.Copy(Path.Combine(env.WebRootPath + "/userImg/", existingFile), Path.Combine(env.WebRootPath + "/userImg/", existingFile));
            System.IO.File.Delete(existingFile);
        }

        //public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }


        //    var userId = await _userManager.GetUserIdAsync(user);
        //    var email = await _userManager.GetEmailAsync(user);
        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    var callbackUrl = Url.Page(
        //        "/Account/ConfirmEmail",
        //        pageHandler: null,
        //        values: new { userId = userId, code = code },
        //        protocol: Request.Scheme);
        //    await _emailSender.SendEmailAsync(
        //        email,
        //        "Confirm your email",
        //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //    StatusMessage = "Verification email sent. Please check your email.";
        //    return RedirectToPage();
        //}
    }
}
