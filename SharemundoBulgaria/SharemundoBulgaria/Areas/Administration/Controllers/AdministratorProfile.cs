using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharemundoBulgaria.Constraints;

namespace SharemundoBulgaria.Areas.Administration.Controllers
{
    [Area(Constants.AdministrationArea)]
    public class AdministratorProfile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}