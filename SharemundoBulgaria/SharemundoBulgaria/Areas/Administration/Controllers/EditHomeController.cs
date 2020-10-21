namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Constraints;

    [Area(Constants.AdministrationArea)]
    public class EditHomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}