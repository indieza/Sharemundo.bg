namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.AddJobPosition;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddJobPosition.InputModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class AddJobPositionController : Controller
    {
        private readonly IAddJobPositionService addJobPositionService;

        public AddJobPositionController(IAddJobPositionService addJobPositionService)
        {
            this.addJobPositionService = addJobPositionService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJobPosition(AddJobPositionInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addJobPositionService.AddJobPosition(model);
                this.TempData["Success"] = MessageConstants.SuccessfullyAddJobPosition;
                return this.RedirectToAction("Index", "AddJobPosition");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "AddJobPosition", model);
            }
        }
    }
}