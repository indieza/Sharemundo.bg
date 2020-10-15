namespace SharemundoBulgaria.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Models;
    using SharemundoBulgaria.Services.Home;

    public class HomeController : Controller
    {
        private readonly IHomeServices homeServices;

        public HomeController(IHomeServices homeServices)
        {
            this.homeServices = homeServices;
        }

        public async Task<IActionResult> Index()
        {
            await this.homeServices.SubmitAllRoles();
            return this.View();
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