namespace SharemundoBulgaria.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}