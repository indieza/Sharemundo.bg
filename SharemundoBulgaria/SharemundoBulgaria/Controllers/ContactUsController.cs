namespace SharemundoBulgaria.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SharemundoBulgaria.Services.Contact;
    using SharemundoBulgaria.ViewModels.Contact;

    public class ContactUsController : Controller
    {
        private readonly IContactService contactsService;

        public ContactUsController(IContactService contactsService)
        {
            this.contactsService = contactsService;
        }

        [BindProperty]
        public ContactInputModel Contact { get; set; }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.contactsService.SendEmail(model);
            this.TempData["Success"] = $"Your message has been sent. Be patient you will receive a reply within 1 day.";
            return this.RedirectToPage("/");
        }
    }
}