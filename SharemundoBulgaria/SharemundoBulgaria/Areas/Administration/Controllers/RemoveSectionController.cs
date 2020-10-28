namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.RemoveSection;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemoveSection.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class RemoveSectionController : Controller
    {
        private readonly IRemoveSectionService removeSectionService;

        public RemoveSectionController(IRemoveSectionService removeSectionService)
        {
            this.removeSectionService = removeSectionService;
        }

        public IActionResult Index()
        {
            var viewModel = new RemoveSectionViewModel
            {
                AllSections = this.removeSectionService.GetAllSections(),
            };

            var model = new RemoveSectionBaseModel
            {
                RemoveSectionInputModel = new RemoveSectionInputModel(),
                RemoveSectionViewModel = viewModel,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSection(RemoveSectionBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                Tuple<string, int> removedSection =
                    await this.removeSectionService.RemoveSection(model.RemoveSectionInputModel.Id);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyRemoveSection,
                    removedSection.Item1.ToUpper(),
                    removedSection.Item2);
                return this.RedirectToAction("Index", "RemoveSection");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "RemoveSection", model);
            }
        }
    }
}