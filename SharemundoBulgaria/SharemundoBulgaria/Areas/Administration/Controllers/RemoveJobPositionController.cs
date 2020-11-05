namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.RemoveJobPosition;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveJobPosition.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class RemoveJobPositionController : Controller
    {
        private readonly IRemoveJobService removeJobService;

        public RemoveJobPositionController(IRemoveJobService removeJobService)
        {
            this.removeJobService = removeJobService;
        }

        public IActionResult Index()
        {
            var model = new RemoveJobPositionBaseModel
            {
                RemoveJobPositionInputModel = new RemoveJobPositionInputModel(),
                AllJobsPositions = this.removeJobService.GetAllJobsPositions(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveJobPosition(RemoveJobPositionBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.removeJobService.DeleteJobPosition(model.RemoveJobPositionInputModel.Id);
                this.TempData["Success"] = MessageConstants.SuccessfullyDeleteJobPosition;
                return this.RedirectToAction("Index", "RemoveJobPosition");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "RemoveJobPosition", model);
            }
        }
    }
}