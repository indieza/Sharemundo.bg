namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    [Authorize(Roles = Constants.AdministratorRole)]
    public class EditSectionController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}