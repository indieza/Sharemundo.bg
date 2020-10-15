﻿namespace SharemundoBulgaria.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Models;
    using SharemundoBulgaria.Models.User;
    using SharemundoBulgaria.Services.Home;
    using SharemundoBulgaria.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHomeServices homeServices;

        public HomeController(UserManager<ApplicationUser> userManager, IHomeServices homeServices)
        {
            this.userManager = userManager;
            this.homeServices = homeServices;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            await this.homeServices.SubmitAllRoles();

            var model = new HomeViewModel
            {
                HasAdmin = await this.homeServices.HasAdministrator(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> MakeYourselfAdmin(string username)
        {
            var hasAdmin = await this.homeServices.HasAdministrator();

            if (!hasAdmin)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier,
            });
        }
    }
}