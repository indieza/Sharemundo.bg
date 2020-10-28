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
    using Microsoft.AspNetCore.Mvc.Formatters;
    using SharemundoBulgaria.Areas.Administration.Services.AddPartToSection;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddPartToSection.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class AddPartToSectionController : Controller
    {
        private readonly IAddPartToSectionService addPartToSectionService;
        private readonly IWebHostEnvironment environment;

        public AddPartToSectionController(
            IAddPartToSectionService addPartToSectionService,
            IWebHostEnvironment environment)
        {
            this.addPartToSectionService = addPartToSectionService;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            var path = Path.Combine(this.environment.WebRootPath, "Website Elements");
            var viewModel = new AddPartToSectionViewModel
            {
                AllSections = this.addPartToSectionService.GetAllSections(),
                AllElements = this.addPartToSectionService.GetAllElements(path),
            };

            var model = new AddPartToSectionBaseModel
            {
                AddPartToSectionInputModel = new AddPartToSectionInputModel(),
                AddPartToSectionViewModel = viewModel,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPartToSection(AddPartToSectionBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                string sectionName = await this.addPartToSectionService.AddPartToSection(model.AddPartToSectionInputModel);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyAddPartToSection,
                    model.AddPartToSectionInputModel.Name.ToUpper(),
                    sectionName.ToUpper());
                return this.RedirectToAction("Index", "AddPartToSection");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "AddPartToSection", model);
            }
        }
    }
}