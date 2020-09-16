using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SharemundoBulgaria.Controllers
{
    public class OurServices : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
