namespace SharemundoBulgaria.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Models;
    using SharemundoBulgaria.Models.User;
    using SharemundoBulgaria.Services.Home;
    using SharemundoBulgaria.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHomeService homeServices;

        public HomeController(UserManager<ApplicationUser> userManager, IHomeService homeServices)
        {
            this.userManager = userManager;
            this.homeServices = homeServices;
        }

        public async Task<IActionResult> Index()
        {
            await this.homeServices.SubmitAllRoles();

            var model = new HomeViewModel
            {
                HasAdmin = await this.homeServices.HasAdministrator(),
                AllSections = await this.homeServices.GetAllHomeSections(),
            };

            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> MakeYourselfAdmin()
        {
            var hasAdmin = await this.homeServices.HasAdministrator();

            if (hasAdmin)
            {
                return this.BadRequest();
            }

            var currentUser = await this.userManager.GetUserAsync(this.User);
            await this.homeServices.MakeYourselfAdmin(currentUser);
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