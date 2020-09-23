namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}