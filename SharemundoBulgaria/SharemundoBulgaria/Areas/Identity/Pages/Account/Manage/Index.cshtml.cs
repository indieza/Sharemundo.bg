namespace SharemundoBulgaria.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SharemundoBulgaria.Models.User;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    this.StatusMessage = "Unexpected error when trying to set phone number.";
                    return this.RedirectToPage();
                }
            }

            if (this.Input.FirstName != user.FirstName)
            {
                user.FirstName = this.Input.FirstName;
            }

            if (this.Input.LastName != user.LastName)
            {
                user.LastName = this.Input.LastName;
            }

            if (this.Input.CompanyName != user.CompanyName)
            {
                user.CompanyName = this.Input.CompanyName;
            }

            if (this.Input.PositionInCompany != user.PositionInCompany)
            {
                user.PositionInCompany = this.Input.PositionInCompany;
            }

            if (this.Input.Country != user.Country)
            {
                user.Country = this.Input.Country;
            }

            if (this.Input.City != user.City)
            {
                user.City = this.Input.City;
            }

            if (this.Input.Address != user.Address)
            {
                user.Address = this.Input.Address;
            }

            if (this.Input.PostCode != user.PostCode)
            {
                user.PostCode = this.Input.PostCode;
            }

            if (this.Input.AboutMe != user.AboutMe)
            {
                user.AboutMe = this.Input.AboutMe;
            }

            await this.userManager.UpdateAsync(user);
            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            var currentUser = await this.userManager.GetUserAsync(this.User);

            this.Username = userName;

            this.Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                AboutMe = currentUser.AboutMe,
                Address = currentUser.Address,
                City = currentUser.City,
                CompanyName = currentUser.CompanyName,
                Country = currentUser.Country,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                PositionInCompany = currentUser.PositionInCompany,
                PostCode = currentUser.PostCode,
                RegisteredOn = DateTime.Parse(currentUser.RegisteredOn.ToString("dd-MMMM-yyyy")).ToLocalTime(),
            };
        }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [MaxLength(30)]
            [Display(Name = "Company Name")]
            public string CompanyName { get; set; }

            [MaxLength(30)]
            [Display(Name = "Position in company")]
            public string PositionInCompany { get; set; }

            [MaxLength(15)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [MaxLength(15)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [MaxLength(50)]
            public string Address { get; set; }

            [MaxLength(20)]
            public string City { get; set; }

            [MaxLength(20)]
            public string Country { get; set; }

            [Display(Name = "Post Code")]
            public int PostCode { get; set; }

            [MaxLength(700)]
            [Display(Name = "About Me")]
            public string AboutMe { get; set; }

            [Display(Name = "Registered On")]
            public DateTime RegisteredOn { get; set; }
        }
    }
}