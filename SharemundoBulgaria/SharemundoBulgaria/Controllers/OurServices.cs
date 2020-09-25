namespace SharemundoBulgaria.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OurServices : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}