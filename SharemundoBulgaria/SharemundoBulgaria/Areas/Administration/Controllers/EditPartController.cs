namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.EditPart;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditPart.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class EditPartController : Controller
    {
        private readonly IEditPartService editPartService;

        public EditPartController(IEditPartService editPartService)
        {
            this.editPartService = editPartService;
        }

        public IActionResult Index()
        {
            var viewModel = new EditPartViewModel
            {
                AllParts = this.editPartService.GetAllParts(),
                AllSections = this.editPartService.GetAllSections(),
            };

            var model = new EditPartBaseModel
            {
                EditPartInputModel = new EditPartInputModel(),
                EditPartViewModel = viewModel,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPart(EditPartBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editPartService.EditPart(model.EditPartInputModel);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyEditPart,
                    model.EditPartInputModel.Name);
                return this.RedirectToAction("Index", "EditPart");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "EditPart", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPartData(string partId)
        {
            GetPartDataViewModel part = await this.editPartService.GetPartById(partId);
            return new JsonResult(part);
        }
    }
}