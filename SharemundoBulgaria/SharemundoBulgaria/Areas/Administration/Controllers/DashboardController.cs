namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.Dashboard;
    using SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.ViewModels;
    using SharemundoBulgaria.Constraints;
    using System.Threading.Tasks;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                AllUsers = this.dashboardService.GetAllUsers(),
                AllAdminsCount = await this.dashboardService.GetAllAdminsCount(),
                AllUsersCount = await this.dashboardService.GetAllUsersCount(),
                AllAdminsNames = await this.dashboardService.GetAllAdminsNames(),
                AllNotAdminsNames = await this.dashboardService.GetAllNotAdminsNames(),
            };

            return this.View(model);
        }
    }
}