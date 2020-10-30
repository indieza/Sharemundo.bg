namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SharemundoBulgaria.Areas.Administration.Services.EditSectionsPosition;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.InputModels;
    using SharemundoBulgaria.Areas.Administration.ViewModels.EditSectionsPosition.ViewModels;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class EditSectionsPositionController : Controller
    {
        private readonly IEditSectionsPositionService editSectionsPositionService;

        public EditSectionsPositionController(IEditSectionsPositionService editSectionsPositionService)
        {
            this.editSectionsPositionService = editSectionsPositionService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult GetSectionsPosition(int pageType)
        {
            ICollection<GetSectionsPositionViewModel> sectionsPosition =
                this.editSectionsPositionService.GetSectionsPosition(pageType);
            return new JsonResult(sectionsPosition);
        }

        [HttpPost]
        public async Task<IActionResult> EditSectionsPosition(string json)
        {
            var allSections = JsonConvert.DeserializeObject<EditSectionsPositionInputModel[]>(json);
            await this.editSectionsPositionService.EditSectionsPosition(allSections);
            this.TempData["Success"] = MessageConstants.SuccessfullyEditSectionsPosition;
            return this.RedirectToAction("Index", "EditSectionsPosition");
        }
    }
}