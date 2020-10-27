namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
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

        public AddPartToSectionController(IAddPartToSectionService addPartToSectionService)
        {
            this.addPartToSectionService = addPartToSectionService;
        }

        public IActionResult Index()
        {
            var model = new AddPartToSectionBaseModel
            {
                AddPartToSectionInputModel = new AddPartToSectionInputModel(),
                AddPartToSectionViewModel = this.addPartToSectionService.GetAllSections(),
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