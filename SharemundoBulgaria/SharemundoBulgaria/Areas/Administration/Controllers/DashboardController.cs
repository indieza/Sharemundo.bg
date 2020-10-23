namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.Dashboard;
    using SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.Dashboard.ViewModels;
    using SharemundoBulgaria.Constraints;

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

        [HttpPost]
        public async Task<IActionResult> RemoveAdministrator(DashboardViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                await this.dashboardService.RemoveAdministrator(model.AddRemoveAdminInputModel.Username);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyRemoveAdministrator,
                    model.AddRemoveAdminInputModel.Username.ToUpper(),
                    Constants.AdministratorRole.ToUpper());
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> AddAdministrator(DashboardViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.dashboardService.AddAdministrator(model.AddRemoveAdminInputModel.Username);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyAddAdministrator,
                    model.AddRemoveAdminInputModel.Username.ToUpper(),
                    Constants.AdministratorRole.ToUpper());
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}