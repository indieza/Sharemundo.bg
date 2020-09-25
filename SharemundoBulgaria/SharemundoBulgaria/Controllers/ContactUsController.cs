namespace SharemundoBulgaria.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}