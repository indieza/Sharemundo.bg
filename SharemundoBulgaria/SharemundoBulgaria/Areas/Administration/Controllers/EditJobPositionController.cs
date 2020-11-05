namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.EditJobPosition;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditJobPosition.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class EditJobPositionController : Controller
    {
        private readonly IEditJobPositionService editJobPositionService;

        public EditJobPositionController(IEditJobPositionService editJobPositionService)
        {
            this.editJobPositionService = editJobPositionService;
        }

        public IActionResult Index()
        {
            var model = new EditJobPositionBaseModel
            {
                EditJobPositionInputModel = new EditJobPositionInputModel(),
                EditJobPositionViewModels = this.editJobPositionService.GetAllJobsPositions(),
            };

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetJobPositionData(string positionId)
        {
            GetJobPositionDataViewModel job = await this.editJobPositionService.GetJobPositionById(positionId);
            return new JsonResult(job);
        }

        [HttpPost]
        public async Task<IActionResult> EditJobPosition(EditJobPositionBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editJobPositionService.EditJobPosition(model.EditJobPositionInputModel);
                this.TempData["Success"] = MessageConstants.SuccessfullyEditJobPosition;
                return this.RedirectToAction("Index", "EditJobPosition");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "EditJobPosition", model);
            }
        }
    }
}