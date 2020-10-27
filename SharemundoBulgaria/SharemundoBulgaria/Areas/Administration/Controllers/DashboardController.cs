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
            var viewModel = new DashboardViewModel
            {
                AllUsers = this.dashboardService.GetAllUsers(),
                AllAdminsCount = await this.dashboardService.GetAllAdminsCount(),
                AllUsersCount = await this.dashboardService.GetAllUsersCount(),
                AllAdminsNames = await this.dashboardService.GetAllAdminsNames(),
                AllNotAdminsNames = await this.dashboardService.GetAllNotAdminsNames(),
            };

            var model = new DashboardBaseModel
            {
                DashboardViewModel = viewModel,
                AddRemoveAdminInputModel = new AddRemoveAdminInputModel(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdministrator(DashboardBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.dashboardService.RemoveAdministrator(model.AddRemoveAdminInputModel.Username);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyRemoveAdministrator,
                    model.AddRemoveAdminInputModel.Username.ToUpper(),
                    Constants.AdministratorRole.ToUpper());
                return this.RedirectToAction("Index", "Dashboard");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "Dashboard", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAdministrator(DashboardBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.dashboardService.AddAdministrator(model.AddRemoveAdminInputModel.Username);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyAddAdministrator,
                    model.AddRemoveAdminInputModel.Username.ToUpper(),
                    Constants.AdministratorRole.ToUpper());
                return this.RedirectToAction("Index", "Dashboard");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "Dashboard", model);
            }
        }
    }
}