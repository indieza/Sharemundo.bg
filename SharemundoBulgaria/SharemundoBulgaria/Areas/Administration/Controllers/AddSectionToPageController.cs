namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class AddSectionToPageController : Controller
    {
        private readonly IAddSectionToPageService addSectionToPageService;
        private readonly IWebHostEnvironment environment;

        public AddSectionToPageController(
            IAddSectionToPageService addSectionToPageService,
            IWebHostEnvironment environment)
        {
            this.addSectionToPageService = addSectionToPageService;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var path = Path.Combine(this.environment.WebRootPath, "Website Elements");
            AddSectionToPageViewModel viewModel = new AddSectionToPageViewModel
            {
                AllElements = this.addSectionToPageService.GetAllElements(path),
            };

            var model = new AddSectionToPageBaseModel
            {
                AddSectionToPageInputModel = new AddSectionToPageInputModel(),
                AddSectionToPageViewModel = viewModel,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSectionToPage(AddSectionToPageBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addSectionToPageService.AddSectionToPage(model.AddSectionToPageInputModel);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyAddSectionToPage,
                    model.AddSectionToPageInputModel.SectionType.ToString().ToUpper(),
                    model.AddSectionToPageInputModel.PageType.ToString().ToUpper());
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "AddSectionToPage", model);
            }

            return this.RedirectToAction("Index", "AddSectionToPage");
        }
    }
}