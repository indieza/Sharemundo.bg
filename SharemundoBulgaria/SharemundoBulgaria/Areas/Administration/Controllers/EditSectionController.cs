namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.EditSection;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSection.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class EditSectionController : Controller
    {
        private readonly IEditSectionService editSectionService;

        public EditSectionController(IEditSectionService editSectionService)
        {
            this.editSectionService = editSectionService;
        }

        public IActionResult Index()
        {
            var viewModel = new EditSectionViewModel
            {
                AllSections = this.editSectionService.GetAllSections(),
            };

            var model = new EditSectionBaseModel
            {
                EditSectionInputModel = new EditSectionInputModel(),
                EditSectionViewModel = viewModel,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSection(EditSectionBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.editSectionService.EditSection(model.EditSectionInputModel);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyEditSection,
                    model.EditSectionInputModel.Name);
                return this.RedirectToAction("Index", "EditSection");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "EditSection", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSectionData(string sectionId)
        {
            GetSectionDataViewModel section = await this.editSectionService.GetSectionById(sectionId);
            return new JsonResult(section);
        }
    }
}