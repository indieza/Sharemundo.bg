namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.RemovePart;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemovePart.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.RemovePart.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class RemovePartController : Controller
    {
        private readonly IRemovePartService removePartService;

        public RemovePartController(IRemovePartService removePartService)
        {
            this.removePartService = removePartService;
        }

        public IActionResult Index()
        {
            var viewModel = new RemovePartViewModel
            {
                AllParts = this.removePartService.GetAllParts(),
            };

            var model = new RemovePartBaseModel
            {
                RemovePartInputModel = new RemovePartInputModel(),
                RemovePartViewModel = viewModel,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePart(RemovePartBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                string partName = await this.removePartService.RemovePart(model.RemovePartInputModel.Id);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyRemovePart,
                    partName.ToUpper());
                return this.RedirectToAction("Index", "RemovePart");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "RemovePart", model);
            }
        }
    }
}