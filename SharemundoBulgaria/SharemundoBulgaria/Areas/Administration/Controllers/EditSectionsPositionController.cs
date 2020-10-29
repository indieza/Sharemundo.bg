namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Areas.Administration.Services.EditSectionsPosition;
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
    }
}