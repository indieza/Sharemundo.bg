namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.AddSectionToPage;
    using SharemundoBulgaria.Areas.Administration.ViewModels.AddSectionToPage.InputModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class AddSectionToPageController : Controller
    {
        private readonly IAddSectionToPageService addSectionToPageService;

        public AddSectionToPageController(IAddSectionToPageService addSectionToPageService)
        {
            this.addSectionToPageService = addSectionToPageService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSectionToPage(AddSectionToPageInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.addSectionToPageService.AddSectionToPage(model);
                this.TempData["Success"] = string.Format(MessageConstants.SuccessfullyAddSectionToPage, model.SectionType.ToString().ToUpper(), model.PageType.ToString().ToUpper());
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